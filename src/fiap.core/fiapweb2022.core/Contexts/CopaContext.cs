using fiapweb2022.core.Models;
using Microsoft.EntityFrameworkCore;

namespace fiapweb2022.core.Contexts
{
    public class CopaContext: DbContext
    {
        public CopaContext(DbContextOptions<CopaContext> options): base(options)
        {

        }
        public DbSet<Time> Times { get; set; }
        public DbSet<Jogador> Jogadores{ get; set; }

        protected override void OnModelCreating( ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jogador>().Property(a => a.Posicao).HasColumnName("PosicaoDoTime");
        }
    }
}
