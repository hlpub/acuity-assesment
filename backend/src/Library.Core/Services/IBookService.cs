using Library.Core.Domain.Models;
using Library.Common.Enums;

namespace Library.Core.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> SearchAsync(SearchBookCriteriaEnum criteria, string search,
             CancellationToken cancellationToken);
    }
}