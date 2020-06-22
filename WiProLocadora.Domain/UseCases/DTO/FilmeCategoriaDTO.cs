using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WiProLocadora.Domain.UseCases.DTO
{
    public class FilmeCategoriaDTO: BaseDTO
    {
        [Required(ErrorMessage = "Campo Nome obrigatório")]
        [StringLength(25, ErrorMessage = "Campo {0} excedeu {1} caracteres.")]
        public string NomeCategoria { get; set; }
        public string IncluidoPor { get; set; }
        public DateTime DataInclusao { get; set; }
        public string AlteradoPor { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
