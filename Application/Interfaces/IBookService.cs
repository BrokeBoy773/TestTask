using CSharpFunctionalExtensions;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IBookService
    {
        Task<Result<List<Book>>> GetAllBooksAsync(
            string? searchString,
            CancellationToken ct);

        Task<Result<Book>> CreateBookAsync(
            string title,
            CancellationToken ct);

        Task<Result<Guid>> DeleteBookAsync(
            Guid id,
            CancellationToken ct);
    }
}
