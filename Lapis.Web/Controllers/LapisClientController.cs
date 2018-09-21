using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http.Headers;

namespace Lapis.Web.Controllers
{
    public class LapisClientController : Controller
    {
        public IHostingEnvironment HostingEnv { get; }

        public LapisClientController(IHostingEnvironment env)
        {
            HostingEnv = env;
        }


        [HttpGet]
        public IActionResult RedirectIndex()
        {
            return new PhysicalFileResult(
                Path.Combine(HostingEnv.WebRootPath, "index.html"),
                new MediaTypeHeaderValue("text/html").MediaType
            );
        }
    }
}
