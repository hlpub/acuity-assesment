using Library.Core.Domain.Models;
using Library.Core.Domain.Repositories;
using Library.Common.Enums;
using Library.Common.Messages;
using MassTransit;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Xml.Schema;


namespace Library.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IBaseRepository<Book> _booksRepository;
        private readonly IPublishEndpoint _publishEndpoint;

        public BookService(IBaseRepository<Book> bookRepository, IPublishEndpoint publishEndpoint)
        {
            _booksRepository = bookRepository;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<IEnumerable<Book>> SearchAsync(SearchBookCriteriaEnum criteria,
            string search, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(search, nameof(search));

            var books = await _booksRepository.SearchAsync(
                Getpredicate(criteria, search), cancellationToken);

            await _publishEndpoint.Publish<IBookSearchPerformedMessage>(new
            {
                MessageDate = DateTime.UtcNow,
                MessageId = Guid.NewGuid(),
                Criteria = criteria,
                Search = search

            }, cancellationToken);

            return books;
        }

        private Expression<Func<Book, bool>> Getpredicate
            (SearchBookCriteriaEnum criteria, string search) =>
            criteria switch
            {
                SearchBookCriteriaEnum.Title => (Book x) => x.Title.Contains(search),
                SearchBookCriteriaEnum.Author => (Book x) => x.FirstName.Contains(search) || x.LastName.Contains(search),
                SearchBookCriteriaEnum.ISBN => (Book x) => x.ISBN != null && x.ISBN.Contains(search),
                _ => throw new ArgumentException("Invalid criteria value", nameof(criteria)),
            };
    }
}
