using Application.Interfaces;
using CSharpFunctionalExtensions;
using Domain.Entities;
using Infrastructure.EntityFrameworkCore.Interfaces;

namespace Application.Services
{
    public class BookService(IBookRepository bookRepository) : IBookService
    {
        private readonly IBookRepository _bookRepository = bookRepository;

        public async Task<Result<List<Book>>> GetAllBooksAsync(string? searchString, CancellationToken ct)
        {
            return await _bookRepository.GetAllBooksAsync(searchString, ct);
        }

        public async Task<Result<Book>> CreateBookAsync(string title, CancellationToken ct)
        {
            Result<Book> resultBook = Book.Create(
                Guid.NewGuid(),
                title);

            if (resultBook.IsFailure)
                return Result.Failure<Book>(resultBook.Error);

            return await _bookRepository.CreateBookAsync(resultBook.Value, ct);
        }

        public async Task<Result<Guid>> DeleteBookAsync(Guid id, CancellationToken ct)
        {
            return await _bookRepository.DeleteBookAsync(id, ct);
        }
    }
}
