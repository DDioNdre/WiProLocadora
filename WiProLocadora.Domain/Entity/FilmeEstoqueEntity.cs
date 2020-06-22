using System;
using System.ComponentModel.DataAnnotations.Schema;
using WiProLocadora.Domain.UseCases.Utils;

namespace WiProLocadora.Domain.Entity
{
    [Table("TbFilmeEstoque")]
    public class FilmeEstoqueEntity : BaseEntity, IDadosInclusaoAlteracao
    {
        [ForeignKey("FilmeEntity")] public int FilmeId { get; set; }
        public int QuantidadeEstoque { get; set; }
        public int QuantidadeAlugada { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public string IncluidoPor { get; set; }
        public DateTime DataInclusao { get; set; }
        public string AlteradoPor { get; set; }
        public DateTime DataAlteracao { get; set; }

        public virtual FilmeEntity FilmeEntity { get; set; }
    }
}
