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
    [Route("api/products")]

    public class ProductsController : ApiController
    { 

        [HttpGet]
        public IHttpActionResult Get()
        {
            var products = MemoryStorage.Instance.GetRecords<ProductEntity>();
            return Ok(products);
        }
    }
}
