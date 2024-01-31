using AutoFixture;
using AutoFixture.Xunit2;
using Library.Api.Test.Controllers;
using Library.Controllers;
using Library.Core.Domain.Models;
using Library.Core.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Library.Core.Enums;

namespace Clarity.Api.UnitTests.Controllers
{
    public class BookControllerTest : ControllerTestsBase<BookController>
    {
        private readonly Mock<IBookService> _bookServiceMock;
        private readonly Fixture _fixture;

        public BookControllerTest()
        {
            _bookServiceMock = Mocker.GetMock<IBookService>();
            _fixture = new Fixture();
        }

        [Theory]
        [AutoData]
        public async Task Get_should_return_Ok_with_(string search)
        {
            //Arrange
            var books = _fixture.Build<Book>()
                .CreateMany(1).ToList();

            _bookServiceMock
                .Setup(x =>
                x.SearchAsync(It.IsAny<SearchBookCriteriaEnum>(),
                It.IsAny<string>(), default)).ReturnsAsync(books);

            //Act
            var result = await Controller
                .Get(It.IsAny<SearchBookCriteriaEnum>(),
                search, default) as OkObjectResult;

            //Assert
            result.Should().NotBeNull();
            result?.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}