using ApiEscola.Data.Context;
using ApiEscola.Entidades;
using ApiEscola.Interfaces.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace ApiEscola.Repositorio
{
    public class RepositorioBanco<T> : IRepositorio<T> where T : EntidadeBase
    {
        protected readonly EscolaContext _context;
        protected readonly DbSet<T> _dbSet;

        public RepositorioBanco(EscolaContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual T Retorna(long id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public virtual List<T> RetornaTodos()
        {
            return _dbSet.ToList();
        }

        public T Incluir(T entidade)
        {
            _dbSet.Add(entidade);
            _context.SaveChanges();
            return entidade;
        }

        public T Editar(T entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;
            _context.SaveChanges();
            return entidade;
        }

        public T Excluir(T entidade)
        {
            _dbSet.Remove(entidade);
            _context.SaveChanges();
            return entidade;
        }
    }
}