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
    public class LocacaoService : ILocacaoService
    {
        private readonly IFilmeRepository iFilmeRepository;
        private readonly IFilmeEstoqueRepository iFilmeEstoqueRepository;
        private readonly IClienteLocacaoRepository iClienteLocacaoRepository;
        private readonly IMapper iMapper;

        public LocacaoService(IFilmeRepository iFilmeRepository, IFilmeEstoqueRepository iFilmeEstoqueRepository, IClienteLocacaoRepository iClienteLocacaoRepository IMapper iMapper)
        {
            this.iFilmeRepository = iFilmeRepository;
            this.iFilmeEstoqueRepository = iFilmeEstoqueRepository;
            this.iClienteLocacaoRepository = iClienteLocacaoRepository;
            this.iMapper = iMapper;
        }

        public async Task<FilmeDTO> ClienteDevolverFilme(int idCliente, FilmeDTO filmeDTO)
        {
            IEnumerable<ClienteLocacaoEntity> clienteLocacaoEntities = await iClienteLocacaoRepository
                .GetByAsync(a =>
                    a.ClienteId == idCliente
                    && a.FilmeId == filmeDTO.Id
                    && a.DataDevolucao < DateTime.Today
                );

            if (clienteLocacaoEntities != null)
                return null;

            FilmeEntity filmeEntity = await iFilmeRepository.GetByIdAsync(filmeDTO.Id);

            return iMapper.Map<FilmeDTO>(filmeEntity);
        }

        public async Task<FilmeDTO> VeriricarEstoqueFilme(int id)
        {
            FilmeEntity filmeEntity = await iFilmeRepository.GetByIdAsync(id);

            IEnumerable<FilmeEstoqueEntity> filmeEstoqueEntity = await iFilmeEstoqueRepository
                .GetByAsync(a => a.FilmeId == id && a.QuantidadeDisponivel > 0);

            if (filmeEntity == null || filmeEstoqueEntity == null)
                return null;

            return iMapper.Map<FilmeDTO>(filmeEntity);
        }
    }
}
