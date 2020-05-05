using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data.Entity.Validation;

namespace Repositorio
{
    public class Repositorio<T> : IRepositorio<T>, IDisposable where T : class
    {
        private readonly DbContext _context;

        public Repositorio(DbContext contexto)
        {
            _context = contexto;
        }
        public void Adicionar(T entidad)
        {
            _context.Set<T>().Add(entidad);
        }

        public IQueryable<T> AsQuearyable()
        {
            return _context.Set<T>().AsNoTracking().AsQueryable();
        }

        public IEnumerable<T> Buscar(Expression<Func<T, bool>> predicado)
        {
            return _context.Set<T>().AsNoTracking().Where(predicado);
        }

        public void Dispose()
        {
            return;
        }

        public void Eliminar(T entidad)
        {
            _context.Entry<T>(entidad).State = EntityState.Deleted;
        }

        public void Grabar()
        {
            try
            {

                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public void Modificar(T entidad)
        {
            _context.Entry<T>(entidad).State = EntityState.Modified;
        }

        public IEnumerable<T> TraerTodo()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public T TraerUno(Expression<Func<T, bool>> predicado)
        {
            return _context.Set<T>().AsNoTracking().Where(predicado).FirstOrDefault();
        }

        public T TraerUnoPorID(int ID_emp)
        {
            return _context.Set<T>().Find(ID_emp);
        }
    }
}
