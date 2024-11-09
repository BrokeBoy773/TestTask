using CSharpFunctionalExtensions;
using Domain.Entities;
using Infrastructure.EntityFrameworkCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFrameworkCore.Repositories
{
    public class BookRepository(TestTaskDbContext dbContext) : IBookRepository
    {
        private readonly TestTaskDbContext _dbContext = dbContext;

        public async Task<Result<List<Book>>> GetAllBooksAsync(
            string? searchString,
            CancellationToken ct)
        {
            List<Book> books = await _dbContext.Books
                .AsNoTracking()
                .Where(b => string.IsNullOrWhiteSpace(searchString) ||
                            b.Title.Title.ToLower().Contains(searchString.ToLower()))
                .ToListAsync(ct);

            return Result.Success(books);
        }

        public async Task<Result<Book>> CreateBookAsync(
            Book book,
            CancellationToken ct)
        {
            await _dbContext.Books.AddAsync(book, ct);
            await _dbContext.SaveChangesAsync(ct);

            return Result.Success(book);
        }

        public async Task<Result<Guid>> DeleteBookAsync(
            Guid id,
            CancellationToken ct)
        {
            await _dbContext.Books
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync(ct);

            return Result.Success(id);
        }
    }
}
