using System;
using System.ComponentModel.DataAnnotations.Schema;
using WiProLocadora.Domain.UseCases.Utils;

namespace WiProLocadora.Domain.Entity
{
    [Table("TbClienteLocacao")]
    public class ClienteLocacaoEntity : BaseEntity, IDadosInclusaoAlteracao
    {
        [ForeignKey("ClienteEntity")] public int ClienteId { get; set; }
        [ForeignKey("FilmeEntity")] public int FilmeId { get; set; }
        public DateTime DataAlocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
        public int DiasAlocacao { get; set; }
        public bool Devolucao { get; set; }
        public string IncluidoPor { get; set; }
        public DateTime DataInclusao { get; set; }
        public string AlteradoPor { get; set; }
        public DateTime DataAlteracao { get; set; }

        public virtual ClienteEntity ClienteEntity { get; set; }
        public virtual FilmeEntity FilmeEntity { get; set; }
    }
}
