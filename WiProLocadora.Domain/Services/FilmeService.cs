using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WiProLocadora.Domain.UseCases.Repository;
using WiProLocadora.Domain.UseCases.Service;

namespace WiProLocadora.Domain.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository iFilmeRepository;
        private readonly IFilmeCategoriaRepository iFilmeCategoriaRepository;
        private readonly IFilmeElencoRepository iFilmeElencoRepository;
        private readonly IElencoRepository iElencoRepository;
        private readonly IMapper iMapper;

        public FilmeService(IFilmeRepository iFilmeRepository, IFilmeCategoriaRepository iFilmeCategoriaRepository, IFilmeElencoRepository iFilmeElencoRepository, IElencoRepository iElencoRepository, IMapper iMapper)
        {
            this.iFilmeRepository = iFilmeRepository;
            this.iFilmeCategoriaRepository = iFilmeCategoriaRepository;
            this.iFilmeElencoRepository = iFilmeElencoRepository;
            this.iElencoRepository = iElencoRepository;
            this.iMapper = iMapper;
        }
    }
}
