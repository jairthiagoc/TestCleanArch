using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task Create(CLienteDTO clienteDto)
        {
            clienteDto.Id = Guid.NewGuid();
            var entity = _mapper.Map<Cliente>(clienteDto);
            await _clienteRepository.Create(entity);
        }

        public async Task<CLienteDTO> GetById(Guid? id)
        {
            var entity = await _clienteRepository.GetById(id);
            return _mapper.Map<CLienteDTO>(entity);
        }

        public async Task<IEnumerable<CLienteDTO>> GetClientes()
        {
            var entity = await _clienteRepository.GetClientes();
            return _mapper.Map<IEnumerable<CLienteDTO>>(entity);
        }

        public async Task Remove(Guid? id)
        {
            var entity = await _clienteRepository.GetById(id);
            await _clienteRepository.Remove(entity);
        }

        public async Task Update(CLienteDTO clienteDto)
        {
            var entity = _mapper.Map<Cliente>(clienteDto);

            await _clienteRepository.Update(entity);
        }
    }
}
