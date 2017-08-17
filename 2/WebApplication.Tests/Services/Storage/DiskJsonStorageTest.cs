using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication.Services;
using WebApplication.Services.Entities;
using WebApplication.Services.Storage;

namespace WebApplication.Tests.Services.Storage
{

    [TestClass]
    public class DiskJsonStorageTest
    {

        [TestMethod]
        public void DiskJsonStorage_AddUpdateRecord_Ok()
        {
            DiskJsonStorage.Instance.AddOrUpdateRecord(new ProductEntity()
            {
                ProductNumber = 1,
                Price = 1,
                Title = "test 001"
            });
            Assert.IsTrue(DiskJsonStorage.Instance.GetRecords<ProductEntity>().Any());
        }

    }
}