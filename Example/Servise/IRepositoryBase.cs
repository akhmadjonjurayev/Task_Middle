using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Example.Model;

namespace Example.Service
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Response Create(T entity);
        Response Update(T entity);
        Response Delete(T entity);
        ResponseData<T> GetAll();
    }
}
