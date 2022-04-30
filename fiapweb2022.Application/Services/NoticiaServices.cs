using fiapweb2022.Application.Interfaces;
using fiapweb2022.Domain.Models;
using Microsoft.Extensions.Caching.Memory;

namespace fiapweb2022.Application.Services
{
    public class NoticiaService : INoticiaService
    {
        private IMemoryCache _memoryCache;
        private IRssClient _rssClient;

        public NoticiaService(IMemoryCache memoryCache, IRssClient rssClient)
        {
            _memoryCache = memoryCache;
            _rssClient = rssClient;
        }

        public List<Noticia> Load(int totalDeNoticias)
        {
            var key = $"noticias_cache";

            if (!_memoryCache.TryGetValue(key, out List<Noticia> noticias))
            {
                noticias = _rssClient.Load();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(30));

            
                _memoryCache.Set(key, noticias, cacheEntryOptions);

            }

            return noticias;
        }

    }
}
