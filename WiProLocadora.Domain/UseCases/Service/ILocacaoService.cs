using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WiProLocadora.Domain.UseCases.DTO;

namespace WiProLocadora.Domain.UseCases.Service
{
    public interface ILocacaoService
    {
        Task<FilmeDTO> VeriricarEstoqueFilme (int id);
        Task<FilmeDTO> ClienteDevolverFilme(int idCliente, FilmeDTO filmeDTO);
    }
}
