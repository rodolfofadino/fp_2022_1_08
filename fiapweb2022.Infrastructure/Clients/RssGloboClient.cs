using CodeHollow.FeedReader;
using fiapweb2022.Application.Interfaces;
using fiapweb2022.Domain.Models;

namespace fiapweb2022.Infrastructure.Clients
{
    public class RssGloboClient : IRssClient
    {
        public List<Noticia> Load()
        {
            var noticias = new List<Noticia>();
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

            return noticias;

        }
    }
}
