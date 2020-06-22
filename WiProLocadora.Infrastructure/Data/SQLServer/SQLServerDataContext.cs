using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WiProLocadora.Domain.Entity;

namespace WiProLocadora.Infrastructure.Data.SQLServer
{
    public class SQLServerDataContext: DbContext
    {
        public SQLServerDataContext(DbContextOptions<SQLServerDataContext> options)
            : base(options)
        {}

        public DbSet<ClienteEntity> Cliente { get; set; }
        public DbSet<ClienteLocacaoEntity> ClienteLocacao { get; set; }
        public DbSet<ElencoEntity> Elenco { get; set; }
        public DbSet<FilmeCategoriaEntity> FilmeCategoria { get; set; }
        public DbSet<FilmeElencoEntity> FilmeElenco { get; set; }
        public DbSet<FilmeEntity> Filme { get; set; }
        public DbSet<FilmeEstoqueEntity> FilmeEstoque { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region builder.Entity<FilmeCategoriaEntity>().HasData
            builder.Entity<FilmeCategoriaEntity>().HasData(
                    new FilmeCategoriaEntity { Id = 1, NomeCategoria = "Drama" },
                    new FilmeCategoriaEntity { Id = 2, NomeCategoria = "Comédia" },
                    new FilmeCategoriaEntity { Id = 3, NomeCategoria = "Terror" },
                    new FilmeCategoriaEntity { Id = 4, NomeCategoria = "Aventura" },
                    new FilmeCategoriaEntity { Id = 5, NomeCategoria = "Suspense" }
                    );
            #endregion

            #region builder.Entity<FilmeEntity>().HasData
            builder.Entity<FilmeEntity>().HasData(
                    new FilmeEntity { Id = 1, Nome = "Um Sonho de Liberdade", FilmeCategoriaId = 1, AnoLancamento = 1994, Diretor = "Frank Darabont", NotaIMDb = 9.2 },
                    new FilmeEntity { Id = 2, Nome = "O Poderoso Chefão", FilmeCategoriaId = 1, AnoLancamento = 1972, Diretor = "Francis Ford Coppola", NotaIMDb = 9.1 },
                    new FilmeEntity { Id = 3, Nome = "O Poderoso Chefão II", FilmeCategoriaId = 1, AnoLancamento = 1974, Diretor = "Francis Ford Coppola", NotaIMDb = 9.0 },
                    new FilmeEntity { Id = 4, Nome = "Batman: O Cavaleiro das Trevas", FilmeCategoriaId = 4, AnoLancamento = 2008, Diretor = "Christopher Nolan", NotaIMDb = 9.0 },
                    new FilmeEntity { Id = 5, Nome = "12 Homens e uma Sentença", FilmeCategoriaId = 1, AnoLancamento = 1957, Diretor = "Sidney Lumet", NotaIMDb = 8.9 }
                    );
            #endregion

            #region builder.Entity<ElencoEntity>().HasData
            builder.Entity<ElencoEntity>().HasData(
                    new ElencoEntity { Id = 1, Nome = "Tim Robbins", Apelido = "", Origem = "EUA", /*Ocupacoes = new string[] { "Ator", "Roteirista", "Produtor", "Cineasta", "Músico" },*/ PeriodoAtividade = "1976 – presente" },
                    new ElencoEntity { Id = 2, Nome = "Morgan Freeman", Apelido = "", Origem = "EUA", /*Ocupacoes = new string[] { "Ator", "Produtor", "Narrador", "Diretor" },*/ PeriodoAtividade = "1980 – presente" },
                    new ElencoEntity { Id = 3, Nome = "Marlon Brando", Apelido = "", Origem = "EUA", /*Ocupacoes = new string[] { "Ator", "Diretor", "Ativista" },*/ PeriodoAtividade = "1944 – 2004" },
                    new ElencoEntity { Id = 4, Nome = "Al Pacino", Apelido = "", Origem = "EUA", /*Ocupacoes = new string[] { "Ator", "Cieasta", "Roteirista", "Produtor" },*/ PeriodoAtividade = "1968 - presente" },
                    new ElencoEntity { Id = 5, Nome = "Robert De Niro", Apelido = "", Origem = "EUA", /*Ocupacoes = new string[] { "Ator", "Produtor", "Diretor" },*/ PeriodoAtividade = "1965 – presente" },
                    new ElencoEntity { Id = 6, Nome = "Christian Bale", Apelido = "", Origem = "País de Gales", /*Ocupacoes = new string[] { "Ator" },*/ PeriodoAtividade = "1982–presente" },
                    new ElencoEntity { Id = 7, Nome = "Heath Ledger", Apelido = "", Origem = "Autrália", /*Ocupacoes = new string[] { "Ator" },*/ PeriodoAtividade = "1992 - 2008" },
                    new ElencoEntity { Id = 8, Nome = "Henry Fonda", Apelido = "", Origem = "EUA", /*Ocupacoes = new string[] { "Ator" },*/ PeriodoAtividade = "1928 – 1982" },
                    new ElencoEntity { Id = 9, Nome = "Leo Jacoby", Apelido = "", Origem = "EUA", /*Ocupacoes = new string[] { "Ator" },*/ PeriodoAtividade = "1934 - 1976" }
                    );
            #endregion

            #region builder.Entity<FilmeElencoEntity>().HasData
            builder.Entity<FilmeElencoEntity>().HasData(
                    new FilmeElencoEntity { Id = 1, AtorId = 1, FilmeId = 1 },
                    new FilmeElencoEntity { Id = 2, AtorId = 2, FilmeId = 1 },
                    new FilmeElencoEntity { Id = 3, AtorId = 3, FilmeId = 2 },
                    new FilmeElencoEntity { Id = 4, AtorId = 4, FilmeId = 2 },
                    new FilmeElencoEntity { Id = 5, AtorId = 4, FilmeId = 3 },
                    new FilmeElencoEntity { Id = 6, AtorId = 5, FilmeId = 3 },
                    new FilmeElencoEntity { Id = 7, AtorId = 6, FilmeId = 4 },
                    new FilmeElencoEntity { Id = 8, AtorId = 7, FilmeId = 4 },
                    new FilmeElencoEntity { Id = 9, AtorId = 8, FilmeId = 5 },
                    new FilmeElencoEntity { Id = 10, AtorId = 9, FilmeId = 5 }
                    );
            #endregion

            #region builder.Entity<FilmeEstoqueEntity>().HasData
            builder.Entity<FilmeEstoqueEntity>().HasData(
                    new FilmeEstoqueEntity { Id = 1, FilmeId = 1, QuantidadeEstoque = 10, QuantidadeAlugada = 5, QuantidadeDisponivel = 5 },
                    new FilmeEstoqueEntity { Id = 2, FilmeId = 2, QuantidadeEstoque = 20, QuantidadeAlugada = 5, QuantidadeDisponivel = 15 },
                    new FilmeEstoqueEntity { Id = 3, FilmeId = 3, QuantidadeEstoque = 15, QuantidadeAlugada = 0, QuantidadeDisponivel = 15 },
                    new FilmeEstoqueEntity { Id = 4, FilmeId = 4, QuantidadeEstoque = 15, QuantidadeAlugada = 15, QuantidadeDisponivel = 0 },
                    new FilmeEstoqueEntity { Id = 5, FilmeId = 5, QuantidadeEstoque = 5, QuantidadeAlugada = 1, QuantidadeDisponivel = 4 }
                    );
            #endregion

            #region builder.Entity<ClienteEntity>().HasData
            builder.Entity<ClienteEntity>().HasData(
                       new ClienteEntity { Id = 1, Nome = "Diego Diondré", Sobrenome = "Bueno de Camargo", Endereco = "Rua XYZ", Numero = 1, Bairro = "Bairro XYZ", Cep = 00000000, Cidade = "São Paulo", UF = "SP", CPF = "11122233344", RG = "001112223", Telefone = "(011)91111-2222", Email = "diego@email.com", Ativo = true },
                       new ClienteEntity { Id = 2, Nome = "João", Sobrenome = "Silva", Endereco = "Rua QWE", Numero = 1, Bairro = "Bairro QWE", Cep = 11111111, Cidade = "São Paulo", UF = "SP", CPF = "22233344455", RG = "112223334", Telefone = "(011)91111-3333", Email = "joao@email.com", Ativo = true },
                       new ClienteEntity { Id = 3, Nome = "Pedro", Sobrenome = "Santos", Endereco = "Rua ASD", Numero = 1, Bairro = "Bairro ASD", Cep = 222222222, Cidade = "São Paulo", UF = "SP", CPF = "33344455566", RG = "223334445", Telefone = "(011)91111-4444", Email = "pedro@email.com", Ativo = true },
                       new ClienteEntity { Id = 4, Nome = "Maria", Sobrenome = "Ferreira", Endereco = "Rua ZXC", Numero = 1, Bairro = "Bairro ZXC", Cep = 33333333, Cidade = "São Paulo", UF = "SP", CPF = "44455566677", RG = "334445556", Telefone = "(011)91111-5555", Email = "maria@email.com", Ativo = true },
                       new ClienteEntity { Id = 5, Nome = "Camila", Sobrenome = "Abreu", Endereco = "Rua QAZ", Numero = 1, Bairro = "Bairro QAZ", Cep = 44444444, Cidade = "São Paulo", UF = "SP", CPF = "55566677788", RG = "445556667", Telefone = "(011)91111-6666", Email = "camila@email.com", Ativo = false }
                   );
            #endregion

            #region builder.Entity<ClienteLocacaoEntity>().HasData
            builder.Entity<ClienteLocacaoEntity>().HasData(
                    new ClienteLocacaoEntity { Id = 1, ClienteId = 1, FilmeId = 2, DataAlocacao = new DateTime(2020, 6, 1), DataDevolucao = new DateTime(2020, 6, 5), DiasAlocacao = 5 },
                    new ClienteLocacaoEntity { Id = 2, ClienteId = 1, FilmeId = 3, DataAlocacao = new DateTime(2020, 6, 2), DataDevolucao = new DateTime(2020, 6, 6), DiasAlocacao = 5 },
                    new ClienteLocacaoEntity { Id = 3, ClienteId = 2, FilmeId = 1, DataAlocacao = new DateTime(2020, 6, 3), DataDevolucao = new DateTime(2020, 6, 7), DiasAlocacao = 5 },
                    new ClienteLocacaoEntity { Id = 4, ClienteId = 3, FilmeId = 4, DataAlocacao = new DateTime(2020, 6, 4), DataDevolucao = new DateTime(2020, 6, 8), DiasAlocacao = 5 },
                    new ClienteLocacaoEntity { Id = 5, ClienteId = 4, FilmeId = 5, DataAlocacao = new DateTime(2020, 6, 5), DataDevolucao = new DateTime(2020, 6, 9), DiasAlocacao = 5 }
                    );
            #endregion
        }
    }
}
