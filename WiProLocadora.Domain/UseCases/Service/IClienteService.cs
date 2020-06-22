using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WiProLocadora.Domain.UseCases.DTO;

namespace WiProLocadora.Domain.UseCases.Service
{
    public interface IClienteService
    {
        Task<List<ClienteDTO>> ObterTodosClientes();
        Task<ClienteDTO> ObterClientePorId(int id);
        Task<ClienteDTO> InserirCliente(ClienteDTO clienteDTO);
        Task<ClienteDTO> AtualizarCliente(ClienteDTO clienteDTO);
    }
}
