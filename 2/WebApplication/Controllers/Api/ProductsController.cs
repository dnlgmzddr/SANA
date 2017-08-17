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

    public class ProductsController : BaseApiController
    { 

        [HttpGet]
        public IHttpActionResult Get()
        {
            var products = GetStorage(Request).GetRecords<ProductEntity>();
            return Ok(products);
        }
    }
}
