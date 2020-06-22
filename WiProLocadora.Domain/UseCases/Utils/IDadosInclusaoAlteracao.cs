using System;
using System.Collections.Generic;
using System.Text;

namespace WiProLocadora.Domain.UseCases.Utils
{
    public interface IDadosInclusaoAlteracao
    {
        string IncluidoPor { get; set; }
        DateTime DataInclusao { get; set; }
        string AlteradoPor { get; set; }
        DateTime DataAlteracao { get; set; }
    }
}
