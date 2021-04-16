using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Model;

namespace Example.Service
{
    public class CategoryRepository:RepositoryBase<Category>,ICategory
    {
        private readonly DbClass db;
        public CategoryRepository(DbClass dbClass) : base(dbClass)
        {
            db = dbClass;
        }

        public Response DeleteById(int id)
        {
            var model = new Category() { CId = id };
            db.Categories.Attach(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            return new Response() { IsSuccess = true, Message = "Category was deleted successfully !" };
        }
    }
    public class AuthorRepository : RepositoryBase<Author>, IAuthor
    {
        private readonly DbClass db;
        public AuthorRepository(DbClass db) : base(db)
        {
            this.db = db;
        }
        public Response DeleteById(int id)
        {
            var model = new Author() { AId = id };
            db.Authors.Attach(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            return new Response() { IsSuccess = true, Message = "Category was deleted successfully !" };
        }

        public ResponseSingleData<Author> FindOne(int id)
        {
            var data = db.Authors.Find(id);
            if (data != null)
                return new ResponseSingleData<Author>() { IsSuccsess = true, Message = "succsess", Data = data };
            return new ResponseSingleData<Author>() { IsSuccsess = false, Message = "something went wrong" };
        }
    }
    public class QuoteRepository : RepositoryBase<Quote>, IQuote
    {
        private readonly DbClass db;
        public QuoteRepository(DbClass db) : base(db)
        {
            this.db = db;
        }

        public Response DeleteById(int id)
        {
            var model = new Quote() { Id = id };
            db.Quotes.Attach(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            var arry = db.Category_Quotes.Where(i => i.Quote_Id == id);
            foreach (var arr in arry)
            {
                db.Category_Quotes.Remove(arr);
            }
            return new Response() { IsSuccess = true, Message = "model has deleted succsessfully" };
        }

        public ResponseData<QuoteMapper> GetAllData()
        {
            var datas = db.Quotes
                .Include(i => i.Author)
                .Include(i => i.category_s)
                .Select(i => new
                {
                    Text = i.Text,
                    Type = i.category_s.Select(i=>i.Category_Id)
                }).ToList();
            var data = db.Quotes
                .Include(i => i.Author)
                .Include(i => i.category_s).ThenInclude(j => j.Category)
                .Select(i => new QuoteMapper()
                {
                    Text = i.Text,
                    Entered_Date= i.Entered_Date,
                    Author = i.Author.FirstName,
                    Type = i.category_s.Select(j => j.Category.Type).ToList()
                }).ToList();

            return new ResponseData<QuoteMapper>() { IsSuccsess = true, Message = "get succsessfully", Data = data };
        }

        public ResponseData<QuoteMapper> GetByCategory(string category)
        {
            var cate = db.Categories.Where(i => i.Type == category).FirstOrDefault();
            if (cate == null)
                return new ResponseData<QuoteMapper>() { IsSuccsess = false, Message = "such a category does not exist" };
            var data = db.Quotes.Where(i => i.category_s
            .Select(j => j.Category.Type)
            .Where(j => j == category) != null)
                .Select(i => new QuoteMapper()
                {
                    Text = i.Text,
                    Entered_Date = i.Entered_Date,
                    Author = i.Author.FirstName,
                    Type = i.category_s.Select(j => j.Category.Type).ToList()
                }).ToList();
            return new ResponseData<QuoteMapper>() { IsSuccsess = true, Message = "get succsessfully", Data = data };
        }

        public ResponseData<QuoteMapper> GetRandom()
        {
            var count = db.Quotes.Where(i => true).Count();
            Random r = new Random();
            r.Next(1, count);
            var data = db.Quotes.Where(i => true)
                .Skip(r.Next(1, count) - 1)
                .Take(1)
                .Include(i => i.category_s).ThenInclude(j => j.Category)
                .Select(i => new QuoteMapper()
                {
                    Text = i.Text,
                    Entered_Date = i.Entered_Date,
                    Author = i.Author.FirstName,
                    Type = i.category_s.Select(j => j.Category.Type).ToList()
                }).ToList();
            return new ResponseData<QuoteMapper>() { IsSuccsess = true, Message = "get succsessful", Data = data };
        }
    }
    public class Category_QuoteRepository : RepositoryBase<Category_Quote>, ICategory_Quote
    {
        private readonly DbClass db;
        public Category_QuoteRepository(DbClass db) : base(db)
        {
            this.db = db;
        }

        public void CreateCategory(int id, List<string> Catigories)
        {
            foreach (var catigory in Catigories)
            {
                var ID = db.Categories.Where(i => i.Type == catigory)
                    .Select(i => i.CId)
                    .FirstOrDefault();
                var obj = new Category_Quote() { Category_Id = ID, Quote_Id = id };
                Create(obj);
            }
        }

        public Response DeleteById(int id)
        {
            var model = new Category_Quote() { ID = id };
            this.db.Category_Quotes.Attach(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            return new Response() { IsSuccess = true, Message = "model has deleted succsessfully" };
        }
    }
}
