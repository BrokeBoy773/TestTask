using CSharpFunctionalExtensions;
using Domain.ValueObjects;
using Xunit;

namespace Domain.Tests.ValueObjectsTests
{
    public class BookTitleTests
    {
        [Theory]
        [InlineData("Война и мир")]
        [InlineData("1984")]
        [InlineData("Уловка-22")]
        [InlineData("Лев, колдунья и платяной шкаф")]
        public void CreateBookTitle_WithValidInput_ReturnsBookTitleValueObject(string title)
        {
            Result<BookTitle> result = BookTitle.Create(title);

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void CreateBookTitle_WithValidInputWithSpaces_ReturnsBookTitleValueObject()
        {
            string title = "      Война       и     мир      ";

            Result<BookTitle> result = BookTitle.Create(title);

            Assert.Equal("Война и мир", result.Value.Title);
        }

        [Theory]
        [InlineData("           ")]
        [InlineData("")]
        [InlineData("!!!")]
        [InlineData(".")]
        public void CreateBookTitle_WithInvalidInput_ReturnsBookTitleValueObject(string title)
        {
            Result<BookTitle> result = BookTitle.Create(title);

            Assert.True(result.IsFailure);
        }

        [Fact]
        public void CreateBookTitle_WithNullString_ReturnsBookTitleValueObject()
        {
            string? title = null;

            Result<BookTitle> result = BookTitle.Create(title);

            Assert.True(result.IsFailure);
        }
    }
}
