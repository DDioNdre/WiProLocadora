using System;
using System.Collections.Generic;
using System.Text;

namespace WiProLocadora.Domain.UseCases.DTO
{
    public class ElencoDTO: BaseDTO
    {
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Origem { get; set; }
        //public string[] Ocupacoes { get; set; }
        public string PeriodoAtividade { get; set; }
        public string IncluidoPor { get; set; }
        public DateTime DataInclusao { get; set; }
        public string AlteradoPor { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
