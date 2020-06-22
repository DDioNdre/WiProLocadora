using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WiProLocadora.Domain.UseCases.Utils;

namespace WiProLocadora.Domain.Entity
{
    [Table("TbFilme")]
    public class FilmeEntity: BaseEntity, IDadosInclusaoAlteracao
    {
        public string Nome { get; set; }
        [ForeignKey("FilmeCategoriaEntity")] public int? FilmeCategoriaId { get; set; }
        public int? AnoLancamento { get; set; }
        public string Diretor { get; set; }
        public double NotaIMDb { get; set; }
        public string IncluidoPor { get; set; }
        public DateTime DataInclusao { get; set; }
        public string AlteradoPor { get; set; }
        public DateTime DataAlteracao { get; set; }

        public virtual FilmeCategoriaEntity FilmeCategoriaEntity { get; set; }
        public virtual FilmeEstoqueEntity FilmeEstoqueEntity { get; set; }
        public virtual ICollection<FilmeElencoEntity> FilmeElencoEntity { get; set; }
    }
}
