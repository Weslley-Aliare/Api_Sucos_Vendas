using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1
{
    public partial class TabelaDeCliente
    {
        public TabelaDeCliente()
        {
            NotasFiscais = new HashSet<NotasFiscai>();
        }

        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Endereco1 { get; set; }
        public string Endereco2 { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public DateTime? DataDeNascimento { get; set; }
        public short? Idade { get; set; }
        public string Sexo { get; set; }
        public decimal? LimiteDeCredito { get; set; }
        public double? VolumeDeCompra { get; set; }
        public bool? PrimeiraCompra { get; set; }

        public virtual ICollection<NotasFiscai> NotasFiscais { get; set; }
    }
}
