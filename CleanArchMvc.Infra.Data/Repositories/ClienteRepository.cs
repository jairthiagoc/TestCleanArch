using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Cliente> Create(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> GetById(Guid? id)
        {
            return await _context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _context.Clientes.OrderByDescending(x => x.Name).ToListAsync();
        }

        public async Task<Cliente> Remove(Cliente cliente)
        {
            _context.Remove(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> Update(Cliente cliente)
        {
            _context.Update(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }
    }
}
