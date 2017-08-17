using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.Services.Entities;
using WebApplication.Services.Storage;

namespace WebApplication.Controllers.Api
{
    [Route("api/product")]

    public class ProductController : ApiController
    { 

        [HttpPost]
        public IHttpActionResult Create(ProductEntity product)
        {
            product.ProductNumber = DateTime.UtcNow.Ticks;
            MemoryStorage.Instance.AddOrUpdateRecord(product);
            return Ok(product);
        }
    }
}
