using Library.Core.Domain.Models;
using Library.Core.Enums;

namespace Library.Core.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> SearchAsync(SearchBookCriteriaEnum criteria, string search,
             CancellationToken cancellationToken);
    }
}