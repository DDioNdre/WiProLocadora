using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WiProLocadora.Domain.UseCases.DTO
{
    public class ClienteDTO: BaseDTO
    {
        [Required(ErrorMessage = "Campo Nome obrigatório")]
        [StringLength(50, ErrorMessage = "Campo {0} excedeu {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Sobrenome obrigatório")]
        [StringLength(50, ErrorMessage = "Campo {0} excedeu {1} caracteres.")]
        public string Sobrenome { get; set; }

        [StringLength(50, ErrorMessage = "Campo {0} excedeu {1} caracteres.")]
        public string Endereco { get; set; }
        public int Numero { get; set; }

        [StringLength(30, ErrorMessage = "Campo {0} excedeu {1} caracteres.")]
        public string Bairro { get; set; }

        public int Cep { get; set; }

        [StringLength(30, ErrorMessage = "Campo {0} excedeu {1} caracteres.")]
        public string Cidade { get; set; }

        [StringLength(2, ErrorMessage = "Campo {0} excedeu {1} caracteres.")]
        public string UF { get; set; }

        [Required(ErrorMessage = "Campo CPF obrigatório")]
        [StringLength(11, ErrorMessage = "Campo {0} excedeu {1} caracteres.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo RG obrigatório")]
        [StringLength(9, ErrorMessage = "Campo {0} excedeu {1} caracteres.")]
        public string RG { get; set; }

        [Required(ErrorMessage = "Campo Telefone obrigatório")]
        [StringLength(11, ErrorMessage = "Campo {0} excedeu {1} caracteres.")]
        public string Telefone { get; set; }

        [StringLength(30, ErrorMessage = "Campo {0} excedeu {1} caracteres.")]
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public string IncluidoPor { get; set; }
        public DateTime DataInclusao { get; set; }
        public string AlteradoPor { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
