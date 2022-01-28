using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1
{
    public partial class NotasFiscai
    {
        public NotasFiscai()
        {
            ItensNotasFiscais = new HashSet<ItensNotasFiscai>();
        }

        public string Cpf { get; set; }
        public string Matricula { get; set; }
        public DateTime? Data { get; set; }
        public int Numero { get; set; }
        public double Imposto { get; set; }

        public virtual TabelaDeCliente CpfNavigation { get; set; }
        public virtual TabelaDeVendedore MatriculaNavigation { get; set; }
        public virtual ICollection<ItensNotasFiscai> ItensNotasFiscais { get; set; }
    }
}
