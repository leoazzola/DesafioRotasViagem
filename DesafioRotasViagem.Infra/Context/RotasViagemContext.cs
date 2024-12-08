using DesafioRotasViagem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioRotasViagem.Infra.Context
{
    public class RotasViagemContext : DbContext
    {
        public RotasViagemContext() { }

        public RotasViagemContext(DbContextOptions<RotasViagemContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=rotasviagem.db");
            }
        }

        public virtual DbSet<Rota> Rotas { get; set; }

        public static void SeedDatabase(RotasViagemContext context)
        {
            if (!context.Rotas.Any())
            {
                var rotas = new List<Rota>
            {
                new Rota { Origem = "GRU", Destino = "BRC", Custo = 10.0m },
                new Rota { Origem = "BRC", Destino = "SCL", Custo = 5.00m },
                new Rota { Origem = "GRU", Destino = "CDG", Custo = 75.00m },
                new Rota { Origem = "GRU", Destino = "SCL", Custo = 20.00m },
                new Rota { Origem = "GRU", Destino = "ORL", Custo = 56.00m },
                new Rota { Origem = "ORL", Destino = "CDG", Custo = 5.00m },
                new Rota { Origem = "SCL", Destino = "ORL", Custo = 20.00m }
            };

                context.Rotas.AddRange(rotas);
                context.SaveChanges();
            }
        }
    }
}
