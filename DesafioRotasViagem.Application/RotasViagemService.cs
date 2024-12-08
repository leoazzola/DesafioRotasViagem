using DesafioRotasViagem.Application.Interfaces;
using DesafioRotasViagem.Domain.Entities;

namespace DesafioRotasViagem.Application
{
    public class RotasViagemService : IRotasViagemService
    {
        private readonly IRotasViagemRepository _routeRepository;

        public RotasViagemService(IRotasViagemRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<IEnumerable<Rota>> GetRotasAsync()
        {
            return await _routeRepository.GetRotasAsync();
        }

        public async Task<Rota?> GetRotasByIdAsync(int id)
        {
            return await _routeRepository.GetRotasByIdAsync(id);
        }

        public async Task<string?> GetMelhorRotaAsync(string origem, string destino)
        {
            origem = origem.ToUpper();
            destino = destino.ToUpper();

            var rotas = await _routeRepository.GetMelhorRotaAsync(origem, destino);

            var melhorRota = DijkstraAlgorithm(rotas, origem, destino);

            return melhorRota;
        }

        public async Task AddRotaAsync(Rota rota)
        {
            await _routeRepository.AddRotaAsync(rota);
        }

        public async Task UpdateRotaAsync(Rota rota)
        {
            await _routeRepository.UpdateRotaAsync(rota);
        }

        public async Task DeleteRotaAsync(int id)
        {
            await _routeRepository.DeleteRotaAsync(id);
        }

        public static string DijkstraAlgorithm(IEnumerable<Rota?> rotas, string origem, string destino)
        {
            var graph = new Dictionary<string, List<Tuple<string, decimal>>>();

            foreach (var rota in rotas)
            {
                if (!graph.ContainsKey(rota.Origem))
                {
                    graph[rota.Origem] = new List<Tuple<string, decimal>>();
                }

                if (!graph.ContainsKey(rota.Destino))
                {
                    graph[rota.Destino] = new List<Tuple<string, decimal>>();
                }

                graph[rota.Origem].Add(Tuple.Create(rota.Destino, rota.Custo));
            }

            var distancias = new Dictionary<string, decimal>();
            var anteriores = new Dictionary<string, string>();
            var priorityQueue = new SortedSet<(decimal Distancia, string Nodo)>(Comparer<(decimal Distancia, string Nodo)>.Create((a, b) => a.Distancia == b.Distancia ? a.Nodo.CompareTo(b.Nodo) : a.Distancia.CompareTo(b.Distancia)));
            var visitados = new HashSet<string>();

            foreach (var node in graph.Keys)
            {
                distancias[node] = decimal.MaxValue;
                anteriores[node] = null;
            }
            distancias[origem] = 0;
            priorityQueue.Add((0, origem));

            while (priorityQueue.Count > 0)
            {
                var (distanciaAtual, nodoAtual) = priorityQueue.Min;
                priorityQueue.Remove(priorityQueue.Min);

                if (nodoAtual == destino)
                {
                    var caminho = new List<string>();
                    while (anteriores[nodoAtual] != null)
                    {
                        caminho.Insert(0, nodoAtual);
                        nodoAtual = anteriores[nodoAtual];
                    }
                    caminho.Insert(0, origem);
                    return $"{string.Join(" → ", caminho)}, com um custo total de {distanciaAtual:F2}.";
                }

                if (visitados.Contains(nodoAtual))
                {
                    continue;
                }
                visitados.Add(nodoAtual);

                foreach (var vizinho in graph[nodoAtual])
                {
                    var (nextNode, weight) = vizinho;
                    decimal distancia = distanciaAtual + weight;

                    if (distancia < distancias[nextNode])
                    {
                        if (priorityQueue.Contains((distancias[nextNode], nextNode)))
                        {
                            priorityQueue.Remove((distancias[nextNode], nextNode));
                        }
                        distancias[nextNode] = distancia;
                        anteriores[nextNode] = nodoAtual;
                        priorityQueue.Add((distancia, nextNode));
                    }
                }
            }

            return $"Não há caminho disponível de {origem} para {destino}.";
        }
    }
}
