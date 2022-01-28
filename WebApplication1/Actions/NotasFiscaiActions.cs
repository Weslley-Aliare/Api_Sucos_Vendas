using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Actions;
using WebApplication1.Repositories;

namespace WebApplication1.Comunicacao_Entidades
{
    public class NotasFiscaiActions : IActionNotasFiscais
    {
        public readonly SUCOS_VENDASContext _context; // chamando (apenas como leitura) a conexão com a classe "SUCOS_VENDASContext" e o nomeando para _context

        public NotasFiscaiActions(SUCOS_VENDASContext context) // Construtor da classe, passando SUCOS_VENDASContext como parametro e o nomeando para context.
        {
            _context = context;
        }

        public async Task<NotasFiscai> Create(NotasFiscai notasFiscai)
        {
            _context.NotasFiscais.Add(notasFiscai); // Entramos com a conexão no banco de dados, buscar na entidade NotasFiscais(dentro de context) e adiciona os dados de entrada em notasFiscai.
            await _context.SaveChangesAsync();

            return notasFiscai;
        }

        public async Task Delete(int Numero)
        {
            var notaFiscalToDelete = await _context.NotasFiscais.FindAsync(Numero);
            _context.NotasFiscais.Remove(notaFiscalToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<NotasFiscai>> Get()
        {
           return await _context.NotasFiscais.ToListAsync();
        }

        public async Task<NotasFiscai> Get(int Numero)
        {
           return await _context.NotasFiscais.FindAsync(Numero);
        }

        public async Task Update(NotasFiscai notasFiscai)
        {
            _context.Entry(notasFiscai).State = EntityState.Modified;
            await _context.SaveChangesAsync();  
        }
    }
}
