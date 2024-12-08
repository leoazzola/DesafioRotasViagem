using DesafioRotasViagem.Application.Interfaces;
using DesafioRotasViagem.Domain.Entities;
using DesafioRotasViagem.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioRotasViagem.Infra
{
    public class RotasViagemRepository : IRotasViagemRepository
    {
        private readonly RotasViagemContext _context;

        public RotasViagemRepository(RotasViagemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rota>> GetRotasAsync()
        {
            return await _context.Rotas.ToListAsync();
        }

        public async Task<Rota?> GetRotasByIdAsync(int id)
        {
            return await _context.Rotas.FindAsync(id);
        }

        public async Task<IEnumerable<Rota?>> GetMelhorRotaAsync(string origem, string destino)
        {
            var rotas = await _context.Rotas.ToListAsync();

            if (!rotas.Any()) return null;

            return rotas;
        }

        public async Task AddRotaAsync(Rota rota)
        {
            await _context.Rotas.AddAsync(rota);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRotaAsync(Rota rota)
        {
            _context.Rotas.Update(rota);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRotaAsync(int id)
        {
            var rota = await _context.Rotas.FindAsync(id);
            if (rota != null)
            {
                _context.Rotas.Remove(rota);
                await _context.SaveChangesAsync();
            }
        }
    }
}
