using CSharpFunctionalExtensions;
using Domain.Entities;

namespace Infrastructure.EntityFrameworkCore.Interfaces
{
    public interface IBookRepository
    {
        Task<Result<List<Book>>> GetAllBooksAsync(
            string? searchString,
            CancellationToken ct);

        Task<Result<Book>> CreateBookAsync(
            Book book,
            CancellationToken ct);

        Task<Result<Guid>> DeleteBookAsync(
            Guid id,
            CancellationToken ct);
    }
}
