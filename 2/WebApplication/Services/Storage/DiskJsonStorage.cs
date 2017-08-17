using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using WebApplication.Services.Entities;

namespace WebApplication.Services.Storage
{
    public class DiskJsonStorage : IStorage
    {

        private static readonly Lazy<DiskJsonStorage> lazy =
            new Lazy<DiskJsonStorage>(() => new DiskJsonStorage());

        public static DiskJsonStorage Instance => lazy.Value;

        private DiskJsonStorage()
        {


            LoadRecords();
            
        }

        private Dictionary<string, Dictionary<long, object>> _storage;

        private object _lock = new object();

        public void AddOrUpdateRecord<T>(T record) where T : IEntity
        {
            lock (_lock)
            {
                var key = typeof(T).FullName;
                if (!_storage.ContainsKey(key)) InitStorageForNewType(key);
                if (!RecordExist(record, key))
                {
                    InsertNewRecord(record, key);
                }
                else
                {
                    UpdateRecord(record, key);
                }
                PersistDatToDisk();
            }

        }

        private void PersistDatToDisk()
        {
            string json = JsonConvert.SerializeObject(_storage);
            System.IO.File.WriteAllText("data.json", json);
        }


        public void LoadRecords()
        {
            lock (_lock)
            {
                if (!System.IO.File.Exists("data.json"))
                {
                    _storage = new Dictionary<string, Dictionary<long, object>>();
                    return;
                }
                var rawData = System.IO.File.ReadAllText("data.json");


                _storage = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<long, object>>>(rawData);
            }
        }

        private void UpdateRecord<T>(T record, string key) where T : IEntity
        {
            _storage[key][record.GetKey()] = record;
        }

        private bool RecordExist<T>(T record, string key) where T : IEntity
        {
            return _storage[key].ContainsKey(record.GetKey());
        }

        private void InsertNewRecord<T>(T record, string key) where T : IEntity
        {
            _storage[key].Add(record.GetKey(), record);
        }

        private void InitStorageForNewType(string key)
        {
            _storage.Add(key, new Dictionary<long, object>());
        }

        public IEnumerable<T> GetRecords<T>() where T : IEntity
        {
            var key = typeof(T).FullName;
            if (!_storage.ContainsKey(key)) InitStorageForNewType(key);
            return _storage[key].Select(c => (T)c.Value);
        }
    }
}