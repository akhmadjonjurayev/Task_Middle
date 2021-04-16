using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Model;

namespace Example.Service
{
    public interface ICategory:IRepositoryBase<Category>
    {
        Response DeleteById(int id);
    }
    public interface IAuthor : IRepositoryBase<Author>
    {
        ResponseSingleData<Author> FindOne(int id);
        Response DeleteById(int id);
    }
    public interface IQuote : IRepositoryBase<Quote>
    {
        Response DeleteById(int id);
        ResponseData<QuoteMapper> GetAllData();
        ResponseData<QuoteMapper> GetByCategory(string category);
        ResponseData<QuoteMapper> GetRandom();
    }
    public interface ICategory_Quote : IRepositoryBase<Category_Quote>
    {
        Response DeleteById(int id);
        void CreateCategory(int id, List<string> Catigories);
    }
}
