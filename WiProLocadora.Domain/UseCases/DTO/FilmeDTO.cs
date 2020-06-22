using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WiProLocadora.Domain.UseCases.DTO
{
    public class FilmeDTO: BaseDTO
    {
        [Required(ErrorMessage = "Campo Nome obrigatório")]
        [StringLength(30, ErrorMessage = "Campo {0} excedeu {1} caracteres.")]
        public string Nome { get; set; }
        public FilmeCategoriaDTO FilmeCategoriaDto { get; set; }
        public int? AnoLancamento { get; set; }
        [StringLength(30, ErrorMessage = "Campo {0} excedeu {1} caracteres.")]
        public string Diretor { get; set; }
        public double NotaIMDb { get; set; }
        public string IncluidoPor { get; set; }
        public DateTime DataInclusao { get; set; }
        public string AlteradoPor { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
