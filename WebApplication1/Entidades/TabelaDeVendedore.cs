using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1
{
    public partial class TabelaDeVendedore
    {
        public TabelaDeVendedore()
        {
            NotasFiscais = new HashSet<NotasFiscai>();
        }

        public string Matricula { get; set; }
        public string Nome { get; set; }
        public double? PercentualComissão { get; set; }
        public DateTime? DataAdmissão { get; set; }
        public bool? DeFerias { get; set; }
        public string Bairro { get; set; }

        public virtual ICollection<NotasFiscai> NotasFiscais { get; set; }
    }
}
