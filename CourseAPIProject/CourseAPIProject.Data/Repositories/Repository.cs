using CourseAPIProject.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CourseAPIProject.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly CourseDBContext _context;

        public Repository(CourseDBContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public TEntity Find(Expression<Func<TEntity, bool>> exp, params string[] includes)
        {
            var query=_context.Set<TEntity>().AsQueryable();
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
            return query.FirstOrDefault(exp);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> exp, params string[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
            return query.Where(exp);
        }

        public bool IsExsist(Expression<Func<TEntity, bool>> exp)
        {
            return _context.Set<TEntity>().Any(exp);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}
