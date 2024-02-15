using Library.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Library.Common.Enums;

namespace Library.Controllers;

[Route("book")]
public class BookController : ApiControllerBase
{
    private readonly ILogger<BookController> _logger;
    private readonly IBookService _bookService;
    public BookController(ILogger<BookController> logger, IBookService bookService)
    {
        _logger = logger;
        _bookService = bookService;
    }

    [HttpGet("{criteria}/{search?}")]
    public async Task<IActionResult> Get(SearchBookCriteriaEnum criteria,
        string? search, CancellationToken cancellationToken)
    {
        try
        {
            if (search.IsNullOrEmpty())
                return BadRequest();

            _logger.LogInformation("Fetching Books for {0} based on {1}", search, criteria);

            var books = await _bookService
                .SearchAsync(criteria, search!, cancellationToken);

            return Ok(books);
        }

        catch (Exception ex)
        {
            _logger.LogInformation("Unable to fetch Books: {0}", ex);
            throw;
        }
    }

}