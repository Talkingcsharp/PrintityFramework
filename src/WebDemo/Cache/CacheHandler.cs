using Microsoft.Extensions.Caching.Memory;
using System.Text;

namespace WebDemo.Cache
{
    public class CacheHandler
    {
        private readonly MemoryCache _cache;

        public CacheHandler(MemoryCache cache)
        {
            _cache = cache;
        }

        public string CreateNewCachedItem(MemoryStream input)
        {
            var stringItem = Convert.ToBase64String(input.ToArray());
            var stringKey = Guid.NewGuid().ToString().Replace("-", "");
            _cache.Set<string>(stringKey, stringItem, DateTime.Now.AddMinutes(5));
            return stringKey;
        }

        public 
    }
}
