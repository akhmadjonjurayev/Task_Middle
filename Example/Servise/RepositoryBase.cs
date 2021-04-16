using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Example.Model;

namespace Example.Service
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DbClass _db;
        public RepositoryBase(DbClass db)
        {
            _db = db;
        }

        public Response Create(T entity)
        {
            if (entity == null)
                return new Response() { IsSuccess = false, Message = "Entered model is null" };
            this._db.Set<T>().Add(entity);
            return new Response() { IsSuccess = true, Message = "Model create succsessfully" };
        }

        public Response Delete(T entity)
        {
            if (entity == null)
                return new Response() { IsSuccess = false, Message = "Entered model is null" };
            this._db.Set<T>().Remove(entity);
            return new Response() { IsSuccess = true, Message = "Model delete succsessfully" };
        }

        public IQueryable<T> FindAll()
        {
            return this._db.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._db.Set<T>().Where(expression).AsNoTracking();
        }

        public ResponseData<T> GetAll()
        {
            return new ResponseData<T>() { IsSuccsess = true, Message = "succsessful", Data = this._db.Set<T>().Where(i => true).ToList() };
        }

        public Response Update(T entity)
        {
            if (entity == null)
                return new Response() { IsSuccess = false, Message = "Model is null" };
            this._db.Set<T>().Update(entity);
            return new Response() { IsSuccess = true, Message = "Model has updated succsessfully" };
        }
    }
}
