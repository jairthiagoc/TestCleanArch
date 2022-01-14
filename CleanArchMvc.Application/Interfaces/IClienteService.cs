using CleanArchMvc.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<CLienteDTO>> GetClientes();
        Task<CLienteDTO> GetById(Guid? id);
        Task Create(CLienteDTO clienteDto);
        Task Update(CLienteDTO clienteDto);
        Task Remove(Guid? id);
    }
}
