using Library.Core.Domain.Models;
using Library.Core.Domain.Repositories;
using Library.Core.Enums;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Xml.Schema;


namespace Library.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IBaseRepository<Book> _booksRepository;

        public BookService(IBaseRepository<Book> bookRepository)
        {
            _booksRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> SearchAsync(SearchBookCriteriaEnum criteria,
            string search, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(search, nameof(search));

            return await _booksRepository.SearchAsync(
                Getpredicate(criteria, search), cancellationToken);
        }

        private Expression<Func<Book, bool>> Getpredicate
            (SearchBookCriteriaEnum criteria, string search) =>
            criteria switch
            {
                SearchBookCriteriaEnum.Title => (Book x) => x.Title.Contains(search),
                SearchBookCriteriaEnum.Author => (Book x) => x.FirstName.Contains(search) || x.LastName.Contains(search),
                _ => throw new ArgumentException("Invalid criteria value", nameof(criteria)),
            };
    }
}
