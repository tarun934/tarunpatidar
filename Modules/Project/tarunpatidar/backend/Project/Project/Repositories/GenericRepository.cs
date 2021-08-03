using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly UdemyDBContext _context;

        public GenericRepository(UdemyDBContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T , bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
