using fiapweb2022.Domain.Models;

namespace fiapweb2022.Application.Interfaces
{
    public interface IRssClient
    {
        public List<Noticia> Load();

    }
}
