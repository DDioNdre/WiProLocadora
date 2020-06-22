using System;
using System.ComponentModel.DataAnnotations.Schema;
using WiProLocadora.Domain.UseCases.Utils;

namespace WiProLocadora.Domain.Entity
{
    [Table("TbFilmeElenco")]
    public class FilmeElencoEntity : BaseEntity, IDadosInclusaoAlteracao
    {
        [ForeignKey("AtorEntity")]
        public int AtorId { get; set; }

        [ForeignKey("FilmeEntity")]
        public int FilmeId { get; set; }
        
        public string IncluidoPor { get; set; }
        public DateTime DataInclusao { get; set; }
        public string AlteradoPor { get; set; }
        public DateTime DataAlteracao { get; set; }


        public virtual ElencoEntity AtorEntity { get; set; }
        public virtual FilmeEntity FilmeEntity { get; set; }
    }
}
