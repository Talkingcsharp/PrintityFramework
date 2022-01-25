using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrintityFramework;
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
            var output = input.ToDocument().CreateDocument();
            
                return File(output, "application/pdf", "document.pdf");
            
        }
    }
}
