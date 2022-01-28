using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Actions
{
    public interface IActionVendedores
    {
        Task<IEnumerable<TabelaDeVendedore>> Get();

        Task<TabelaDeVendedore> Get(string Matricula);

        Task<TabelaDeVendedore> Create(TabelaDeVendedore tabelaDeVendedore);

        Task  Update(TabelaDeVendedore tabelaDeVendedore);

        Task  Delete(string Matricula);

    }
}
