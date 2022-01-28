using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Repositories
{
    public interface InotasFiscaiRepositorie // Temos uma classe interface, onde seus métodos devem ser implementados por que tiver chamado a interface. 
    {
        Task<IEnumerable<NotasFiscai>> Get();

        Task<NotasFiscai> Get(int id);

        Task<NotasFiscai> Create(NotasFiscai notasFiscai);

        Task<NotasFiscai> Update(NotasFiscai notasFiscai);

        Task Delete(int id);
    }
}
