using Microsoft.AspNetCore.Mvc;

namespace fiapweb2022.Models
{
    public class Time
    {
        [HiddenInput]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Bandeira { get; set; }
        public bool Publicado { get; set; }
    }
}
