using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WebApplication.Services.Storage
{
    public interface IStorage
    {
        void AddRecord<T>(T record) where T : ISerializable;

        IEnumerable<T> GetRecords<T>() where T : ISerializable;
    }
}