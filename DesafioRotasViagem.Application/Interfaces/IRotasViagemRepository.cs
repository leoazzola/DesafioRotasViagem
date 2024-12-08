using DesafioRotasViagem.Domain.Entities;

namespace DesafioRotasViagem.Application.Interfaces
{
    public interface IRotasViagemRepository
    {
        Task<IEnumerable<Rota>> GetRotasAsync();
        Task<Rota?> GetRotasByIdAsync(int id);
        Task<IEnumerable<Rota?>> GetMelhorRotaAsync(string origem, string destino);
        Task AddRotaAsync(Rota rota);
        Task UpdateRotaAsync(Rota rota);
        Task DeleteRotaAsync(int id);
    }
}
