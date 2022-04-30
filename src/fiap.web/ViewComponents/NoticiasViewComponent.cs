using fiapweb2022.Application.Services;
using fiapweb2022.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace fiapweb2022.ViewComponents
{

    public class NoticiasViewComponent : ViewComponent
    {
        private INoticiaService _noticiaService;

        public NoticiasViewComponent(INoticiaService noticiaService)
        {
            _noticiaService = noticiaService;

        }

        public async Task<IViewComponentResult> InvokeAsync(int total, bool noticiasUrgentes = false)
        {
            string view = "noticias";

            if (total > 3 && noticiasUrgentes)
            {
                view = "noticiasurgentes";
            }

            var items = _noticiaService.Load(total);

            return View(view, items);
        }

        private IEnumerable<Noticia> GetNoticias(int total)
        {
            //simulando acesso a api ou DB
            for (int i = 0; i < total; i++)
            {
                yield return new Noticia() { Id = i, Titulo = $"Noticia sobre {i}", Link = $"https//{i}" };
            }
        }
    }
}
