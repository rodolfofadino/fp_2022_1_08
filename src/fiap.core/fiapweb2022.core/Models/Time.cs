

namespace fiapweb2022.core.Models
{
    public class Time
    {
       
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Bandeira { get; set; }
        public bool Publicado { get; set; }

        public List<Jogador>? Jogadores { get; set; }
    }
}
