using DesafioRotasViagem.Application;
using DesafioRotasViagem.Domain.Entities;
using Xunit;

namespace DesafioRotasViagem.Tests
{
    public class RotasViagemTest
    {
        [Fact]
        public void TestRotaMaisBarata()
        {
            var rotas = new List<Rota>
        {
            new Rota { Origem = "GRU", Destino = "BRC", Custo = 10.00m },
            new Rota { Origem = "BRC", Destino = "SCL", Custo = 5.00m },
            new Rota { Origem = "GRU", Destino = "CDG", Custo = 75.00m },
            new Rota { Origem = "GRU", Destino = "SCL", Custo = 20.00m },
            new Rota { Origem = "GRU", Destino = "ORL", Custo = 56.00m },
            new Rota { Origem = "ORL", Destino = "CDG", Custo = 5.00m },
            new Rota { Origem = "SCL", Destino = "ORL", Custo = 20.00m }
        };

            var resultado = RotasViagemService.DijkstraAlgorithm(rotas, "GRU", "CDG");
            Assert.Equal("GRU → BRC → SCL → ORL → CDG, com um custo total de 40,00.", resultado);
        }

        [Fact]
        public void TestRotaDireta()
        {
            var rotas = new List<Rota>
        {
            new Rota { Origem = "BRC", Destino = "SCL", Custo = 5.00m }
        };

            var resultado = RotasViagemService.DijkstraAlgorithm(rotas, "BRC", "SCL");
            Assert.Equal("BRC → SCL, com um custo total de 5,00.", resultado);
        }

        [Fact]
        public void TestRotaInexistente()
        {
            var rotas = new List<Rota>
        {
            new Rota { Origem = "GRU", Destino = "BRC", Custo = 10.00m },
            new Rota { Origem = "BRC", Destino = "SCL", Custo = 5.00m }
        };

            var resultado = RotasViagemService.DijkstraAlgorithm(rotas, "GRU", "XYZ");
            Assert.Equal("Não há caminho disponível de GRU para XYZ.", resultado);
        }
    }
}