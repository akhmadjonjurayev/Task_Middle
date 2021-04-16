using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Model;

namespace Example.Service
{
    public interface IRepositoryWrapper
    {
        IAuthor Author { get; }
        ICategory Category { get; }
        ICategory_Quote Category_Quote { get; }
        IQuote Quote { get; }
        void Save();
        Task SaveAsync();
        Response CreateFullQuote(FullQuote full);
    }
}
