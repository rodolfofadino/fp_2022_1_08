﻿namespace fiapweb2022.Domain.Models
{
    public class Time
    {
       
        public int Id { get; set; }
        //[JsonPropertyName("NomeZao")]
        public string Nome { get; set; }
        public string Bandeira { get; set; }
        public bool Publicado { get; set; }

        public List<Jogador>? Jogadores { get; set; }
    }
}
