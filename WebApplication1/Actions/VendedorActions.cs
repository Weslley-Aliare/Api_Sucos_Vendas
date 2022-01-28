using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace WebApplication1.Actions
{
    public class VendedorActions : IActionVendedores
    {
        public readonly SUCOS_VENDASContext _context;

        public VendedorActions(SUCOS_VENDASContext context)
        {
            _context = context;
        }

        public async Task<TabelaDeVendedore> Create(TabelaDeVendedore tabelaDeVendedore)
        {
            _context.TabelaDeVendedores.Add(tabelaDeVendedore);
            await _context.SaveChangesAsync();

            return tabelaDeVendedore;
        }

        public async Task Delete(string Matricula)
        {
            var vendedorToDelete = await _context.TabelaDeVendedores.FindAsync(Matricula);
            _context.TabelaDeVendedores.Remove(vendedorToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TabelaDeVendedore>> Get()
        {
            return await _context.TabelaDeVendedores.ToListAsync();
        }

        public async Task<TabelaDeVendedore> Get(string Matricula)
        {
            return await _context.TabelaDeVendedores.FindAsync(Matricula);
        }

        public async Task Update(TabelaDeVendedore tabelaDeVendedore)
        {
            _context.Entry(tabelaDeVendedore).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
