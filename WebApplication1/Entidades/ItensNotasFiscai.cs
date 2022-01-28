using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1
{
    public partial class ItensNotasFiscai
    {
        public int Numero { get; set; }
        public string CodigoDoProduto { get; set; }
        public int Quantidade { get; set; }
        public double Preço { get; set; }

        public virtual TabelaDeProduto CodigoDoProdutoNavigation { get; set; }
        public virtual NotasFiscai NumeroNavigation { get; set; }
    }
}
