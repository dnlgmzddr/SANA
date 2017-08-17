using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Services.Entities;

namespace WebApplication.Services.Storage
{
    public class MemoryStorage : IStorage
    {

        private static readonly Lazy<MemoryStorage> lazy =
            new Lazy<MemoryStorage>(() => new MemoryStorage());

        public static MemoryStorage Instance => lazy.Value;

        private MemoryStorage()
        {
            _storage = new Dictionary<string, Dictionary<long, IEntity>>();
        }

        private  Dictionary<string, Dictionary<long, IEntity>> _storage;

        public void AddOrUpdateRecord<T>(T record) where T : IEntity
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
        }

        private  void UpdateRecord<T>(T record, string key) where T : IEntity
        {
            _storage[key][record.GetKey()] = record;
        }

        private  bool RecordExist<T>(T record, string key) where T : IEntity
        {
            return _storage[key].ContainsKey(record.GetKey());
        }

        private void InsertNewRecord<T>(T record, string key) where T : IEntity
        {
            _storage[key].Add(record.GetKey(), record);
        }

        private  void InitStorageForNewType(string key)
        {
            _storage.Add(key, new Dictionary<long, IEntity>());
        }

        public IEnumerable<T> GetRecords<T>() where T : IEntity
        {
            var key = typeof(T).FullName;
            if (!_storage.ContainsKey(key)) InitStorageForNewType(key);
            return _storage[key].Select(c => (T)c.Value);
        }
    }
}