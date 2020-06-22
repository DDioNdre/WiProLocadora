using System;
using System.Collections.Generic;
using System.Text;

namespace WiProLocadora.Domain.UseCases.DTO
{
    public class FilmeEstoqueDTO: BaseDTO
    {
        public FilmeDTO FilmeDto { get; set; }
        public int QuantidadeEstoque { get; set; }
        public int QuantidadeAlugada { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public string IncluidoPor { get; set; }
        public DateTime DataInclusao { get; set; }
        public string AlteradoPor { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
