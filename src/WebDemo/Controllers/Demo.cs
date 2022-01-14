using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrintityFramework;

namespace WebDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Demo : ControllerBase
    {
        [HttpPost]
        public ActionResult Post([FromBody] PFW_Document input)
        {
            var output = input.CreateDocument();
            return File(output, "application/pdf", "document.pdf");
        }
    }
}
