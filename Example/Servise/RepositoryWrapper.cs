using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Model;

namespace Example.Service
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IAuthor author;
        private IQuote quote;
        private ICategory category;
        private ICategory_Quote category_Quote;
        private readonly DbClass dbClass;
        public RepositoryWrapper(DbClass db)
        {
            dbClass = db;
            dbClass.Quotes.AddRange(GetData.GetQuotes());
            dbClass.Authors.AddRange(GetData.GetAuthors());
            dbClass.Categories.AddRange(GetData.GetCategory());
            dbClass.Category_Quotes.AddRange(GetData.GetCategory_Quotes());
            dbClass.SaveChanges();
        }

        public IAuthor Author
        {
            get
            {
                if (author == null)
                {
                    author = new AuthorRepository(dbClass);
                }
                return author;
            }
        }
        public IQuote Quote
        {
            get
            {
                if (quote == null)
                {
                    quote = new QuoteRepository(dbClass);
                }
                return quote;
            }
        }
        public ICategory Category
        {
            get
            {
                if (category == null)
                {
                    category = new CategoryRepository(dbClass);
                }
                return category;
            }
        }
        public ICategory_Quote Category_Quote
        {
            get
            {
                if (category_Quote == null)
                {
                    category_Quote = new Category_QuoteRepository(dbClass);
                }
                return category_Quote;
            }
        }

        public Response CreateFullQuote(FullQuote full)
        {
            if (full == null) return new Response() { IsSuccess = false, Message = "model is null" };
            Quote quot = new Quote() { Author_id = full.Author_Id, Text = full.Text, Entered_Date = DateTime.Now };
            Quote.Create(quot);
            Save();
            Category_Quote.CreateCategory(quot.Id, full.Categories);
            Save();
            return new Response() { IsSuccess = true, Message = "save succsessfully" };
        }

        public void Save()
        {
            dbClass.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await dbClass.SaveChangesAsync();
        }
    }
}

