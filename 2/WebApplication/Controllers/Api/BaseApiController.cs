using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using WebApplication.Services.Storage;

namespace WebApplication.Controllers.Api
{
    public class BaseApiController : ApiController
    {

        private static Dictionary<string, IStorage> _storageProviders;

        static BaseApiController()
        {
            // Improvment handle reconsilition while swapping providers.
            _storageProviders = new Dictionary<string, IStorage>
            {
                {"memory", MemoryStorage.Instance },
                {"disk", DiskJsonStorage.Instance }
            };
        }

        protected IStorage GetStorage(HttpRequestMessage request)
        {
            IEnumerable<string> headerValues = request.Headers.GetValues("storage");
            var providerName = headerValues.First();

            return _storageProviders[providerName];

        }

    }
}