using System;
using System.Net;
using System.Web.Http;
using WebApplication.Services.Entities;

namespace WebApplication.Controllers.Api
{
    [Route("api/product")]

    public class ProductController : BaseApiController
    { 

        [HttpPost]
        public IHttpActionResult Create(ProductEntity product)
        {

            
            product.ProductNumber = DateTime.UtcNow.Ticks;

            // Improvement: Use an action filter to inject the storage provider
            GetStorage(Request).AddOrUpdateRecord(product);
            return Ok(product);
        }
    }
}
