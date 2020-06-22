using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WiProLocadora.Domain.Entity;
using WiProLocadora.Domain.UseCases.DTO;

namespace WiProLocadora.Domain.Mapping
{
    public class MappingProfile: Profile
    {
        public static IConfigurationProvider InitializeAutomapper()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.CreateMap<ClienteEntity, ClienteDTO>()
                .ReverseMap();

                cfg.CreateMap<ClienteLocacaoDTO, ClienteLocacaoEntity>()
                    .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => new ClienteDTO { Id = src.ClienteDto.Id}))
                    .ForMember(dest => dest.FilmeId, opt => opt.MapFrom(src => new FilmeDTO { Id = src.FilmeDto.Id }))
                    .ReverseMap();

                cfg.CreateMap<ElencoDTO, ElencoEntity>()
                    .ReverseMap();

                cfg.CreateMap<FilmeCategoriaDTO, FilmeCategoriaEntity>()
                    .ReverseMap();

                cfg.CreateMap<FilmeElencoDTO, FilmeElencoEntity>()
                    .ForMember(dest => dest.FilmeId, opt => opt.MapFrom(src => new FilmeDTO { Id = src.FilmeDto.Id }))
                    .ForMember(dest => dest.AtorId, opt => opt.MapFrom(src => new ElencoDTO { Id = src.ElencoDto.Id }))
                    .ReverseMap();

                cfg.CreateMap<FilmeDTO, FilmeEntity>()
                    .ForMember(dest => dest.FilmeCategoriaId, opt => opt.MapFrom(src => new FilmeCategoriaDTO { Id = src.FilmeCategoriaDto.Id }))
                    .ReverseMap();

                cfg.CreateMap<FilmeEstoqueDTO, FilmeEstoqueEntity>()
                    .ForMember(dest => dest.FilmeId, opt => opt.MapFrom(src => new FilmeDTO { Id = src.FilmeDto.Id }))
                    .ReverseMap();
            });

            return mapperConfiguration;
        }
    }
}
