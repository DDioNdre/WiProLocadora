using System;
using System.Collections.Generic;
using System.Text;

namespace WiProLocadora.Domain.UseCases.DTO
{
    public class ClienteLocacaoDTO: BaseDTO
    {
        public ClienteDTO ClienteDto { get; set; }
        public FilmeDTO FilmeDto { get; set; }
        public DateTime DataAlocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
        public int DiasAlocacao { get; set; }
        public bool Devolucao { get; set; }
        public string IncluidoPor { get; set; }
        public DateTime DataInclusao { get; set; }
        public string AlteradoPor { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
