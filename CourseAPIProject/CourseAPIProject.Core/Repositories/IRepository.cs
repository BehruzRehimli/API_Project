using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CourseAPIProject.Core.Repositories
{
    public  interface IRepository<TEntity>
    {
        TEntity Find(Expression<Func<TEntity,bool>> exp,params string[] includes);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> exp, params string[] includes);
        bool IsExsist(Expression<Func<TEntity, bool>> exp);
        void Add(TEntity entity);
        void Remove(TEntity entity);
        int Commit();

    }
}
