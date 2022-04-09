using CodeHollow.FeedReader;
using fiapweb2022.core.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiapweb2022.core.Services
{
    public class NoticiaService
    {
        private IMemoryCache _memoryCache;

        public NoticiaService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public List<Noticia> Load(int totalDeNoticias)
        {
            var key = $"noticias_cache";


            //if (_memoryCache.TryGetValue(key, out List<Noticia> noticias))
            //    return noticias;



            if (!_memoryCache.TryGetValue(key, out List<Noticia> noticias))
            {
                noticias= new List<Noticia>();

                var feed = FeedReader.ReadAsync("https://g1.globo.com/rss/g1/turismo-e-viagem/").Result;

                foreach (var item in feed.Items)
                {
                    var feedItem = item.SpecificItem as CodeHollow.FeedReader.Feeds.MediaRssFeedItem;
                    var media = feedItem.Media;
                    var url = "";
                    if (media.Any())
                        url = media.FirstOrDefault().Url;
                    noticias.Add(new Noticia() { Id = 1, Titulo = item.Title, Link = item.Link, Imagem = url });
                }

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(30));

                //var cacheEntryOptions = new MemoryCacheEntryOptions()
                //  .SetSlidingExpiration();


                _memoryCache.Set(key, noticias, cacheEntryOptions);

            }

            return noticias;
        }

    }
}
