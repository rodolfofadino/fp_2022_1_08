using fiapweb2022.Domain.Models;

namespace fiapweb2022.Application.Services
{
    public interface INoticiaService
    {
        List<Noticia> Load(int totalDeNoticias);
    }
}