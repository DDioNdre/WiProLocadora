using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WiProLocadora.Domain.UseCases.Utils;

namespace WiProLocadora.Domain.Entity
{
    [Table("TbFilmeCategoria")]
    public class FilmeCategoriaEntity: BaseEntity, IDadosInclusaoAlteracao
    {
        public string NomeCategoria { get; set; }
        public string IncluidoPor { get; set; }
        public DateTime DataInclusao { get; set; }
        public string AlteradoPor { get; set; }
        public DateTime DataAlteracao { get; set; }

        public virtual ICollection<FilmeEntity> FilmeEntities { get; set; }
    }
}
