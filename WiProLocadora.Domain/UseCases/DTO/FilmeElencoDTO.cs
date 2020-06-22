using System;
using System.Collections.Generic;
using System.Text;

namespace WiProLocadora.Domain.UseCases.DTO
{
    public class FilmeElencoDTO: BaseDTO
    {
        public ElencoDTO ElencoDto { get; set; }
        public FilmeDTO FilmeDto { get; set; }
        public string IncluidoPor { get; set; }
        public DateTime DataInclusao { get; set; }
        public string AlteradoPor { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
