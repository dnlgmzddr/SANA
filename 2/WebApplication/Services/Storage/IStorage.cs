using System.Collections.Generic;
using System.Runtime.Serialization;
using WebApplication.Services.Entities;

namespace WebApplication.Services.Storage
{
    public interface IStorage
    {
        void AddOrUpdateRecord<T>(T record) where T : IEntity;

        IEnumerable<T> GetRecords<T>() where T : IEntity;
    }
}