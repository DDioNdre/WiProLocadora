using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WiProLocadora.Domain.Entity;
using WiProLocadora.Domain.UseCases.DTO;
using WiProLocadora.Domain.UseCases.Repository;
using WiProLocadora.Domain.UseCases.Service;

namespace WiProLocadora.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository iClienteRepository;
        private readonly IMapper iMapper;

        public ClienteService(IClienteRepository iClienteRepository, IMapper iMapper)
        {
            this.iClienteRepository = iClienteRepository;
            this.iMapper = iMapper;
        }

        public async Task<ClienteDTO> AtualizarCliente(ClienteDTO clienteDTO)
        {
            if (await iClienteRepository.GetByIdAsync(clienteDTO.Id) == null)
                return null;

            ClienteEntity clienteEntity = iMapper.Map<ClienteEntity>(clienteDTO);
            clienteEntity = await iClienteRepository.Update(clienteEntity);

            return iMapper.Map<ClienteDTO>(clienteEntity);
        }

        public async Task<ClienteDTO> InserirCliente(ClienteDTO clienteDTO)
        {
            if (await iClienteRepository.GetByAsync(a => a.CPF == clienteDTO.CPF) != null)
                return null;

            ClienteEntity clienteEntity = iMapper.Map<ClienteEntity>(clienteDTO);
            clienteEntity = await iClienteRepository.Insert(clienteEntity);

            return iMapper.Map<ClienteDTO>(clienteEntity);
        }

        public async Task<ClienteDTO> ObterClientePorId(int id)
        {
            ClienteEntity clienteEntity = await iClienteRepository.GetByIdAsync(id);

            return iMapper.Map<ClienteDTO>(clienteEntity);
        }

        public async Task<List<ClienteDTO>> ObterTodosClientes()
        {
            IEnumerable<ClienteEntity> clienteEntities = await iClienteRepository.GetAllAsync();

            return iMapper.Map<List<ClienteDTO>>(clienteEntities);
        }
    }
}
