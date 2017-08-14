using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication.Services;
using WebApplication.Services.Entities;
using WebApplication.Services.Storage;

namespace WebApplication.Tests.Services.Storage
{

    [TestClass]
    public class MemoryStorageTest
    {

        [TestMethod]
        public void MemoryStorage_AddUpdateRecord_Ok()
        {
            MemoryStorage.Instance.AddOrUpdateRecord(new ProductEntity()
            {
                ProductNumber = 1,
                Price = 1,
                Title = "test 001"
            });
            Assert.IsTrue(MemoryStorage.Instance.GetRecords<ProductEntity>().Any());
        }

    }
}