using CSharpFunctionalExtensions;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Book
    {
        public Guid Id { get; }

        public BookTitle Title { get; private set; }

        private Book()
        {
        }

        private Book(
            Guid id,
            BookTitle title)
        {
            Id = id;
            Title = title;
        }

        public static Result<Book> Create(
            Guid id,
            string title)
        {
            Result<BookTitle> resultBookTitle = BookTitle.Create(title);

            if (resultBookTitle.IsFailure)
                return Result.Failure<Book>(resultBookTitle.Error);

            Book validBook = new(
                id,
                resultBookTitle.Value);

            return Result.Success(validBook);
        }
    }
}
