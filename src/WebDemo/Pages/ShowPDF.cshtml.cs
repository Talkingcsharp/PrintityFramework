using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebDemo.Cache;

namespace WebDemo.Pages
{
    public class ShowPDFModel : PageModel
    {
        private readonly CacheHandler _cacheHandler;

        public ShowPDFModel(CacheHandler cacheHandler)
        {
            _cacheHandler = cacheHandler;
        }

        public IActionResult OnGet()
        {
            var cachId = Request.RouteValues["id"]?.ToString()?? "";
            var cacheString = _cacheHandler.GetCachedItem(cachId);
            var bytes = Convert.FromBase64String(cacheString);
            return File(bytes, "application/octet-stream", "document.pdf");
        }
    }
}
