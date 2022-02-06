using Microsoft.AspNetCore.Mvc;
using WebDemo.Data.PFWDOCUMENTVM;

namespace WebDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Demo : ControllerBase
    {
        [HttpPost]
        public ActionResult Post([FromBody] PFW_DocumentViewModel input)
        {
            var document = input.ToDocument();
            var output = document.CreateDocument();
            return File(output, "application/pdf", "document.pdf");
        }
    }
}
