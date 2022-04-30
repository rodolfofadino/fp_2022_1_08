using fiapweb2022.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace fiapweb2022.Persistence.Contexts
{
    public class CopaContext: DbContext
    {
        public CopaContext(DbContextOptions<CopaContext> options): base(options)
        {

        }
        public DbSet<TokenStore> TokensStores { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Jogador> Jogadores{ get; set; }

        protected override void OnModelCreating( ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jogador>().Property(a => a.Posicao).HasColumnName("PosicaoDoTime");
        }
    }
}
