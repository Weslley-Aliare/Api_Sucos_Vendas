using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1
{
    public partial class TabelaDeProduto
    {
        public TabelaDeProduto()
        {
            ItensNotasFiscais = new HashSet<ItensNotasFiscai>();
        }

        public string CodigoDoProduto { get; set; }
        public string NomeDoProduto { get; set; }
        public string Embalagem { get; set; }
        public string Tamanho { get; set; }
        public string Sabor { get; set; }
        public decimal PreçoDeLista { get; set; }

        public virtual ICollection<ItensNotasFiscai> ItensNotasFiscais { get; set; }
    }
}
