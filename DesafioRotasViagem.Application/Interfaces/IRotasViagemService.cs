using DesafioRotasViagem.Domain.Entities;

namespace DesafioRotasViagem.Application.Interfaces
{
    public interface IRotasViagemService
    {
        Task<IEnumerable<Rota>> GetRotasAsync();
        Task<Rota?> GetRotasByIdAsync(int id);
        Task<string?> GetMelhorRotaAsync(string origem, string destino);
        Task AddRotaAsync(Rota rota);
        Task UpdateRotaAsync(Rota rota);
        Task DeleteRotaAsync(int id);
    }
}
