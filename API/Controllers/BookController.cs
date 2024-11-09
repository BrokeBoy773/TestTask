using API.DTOs;
using Application.Interfaces;
using CSharpFunctionalExtensions;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController(IBookService bookService) : ControllerBase
    {
        private readonly IBookService _bookService = bookService;

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooksAsync(
            [FromQuery] string? searchString,
            CancellationToken ct)
        {
            Result<List<Book>> resultBooks = await _bookService.GetAllBooksAsync(searchString, ct);

            if (resultBooks.IsFailure)
                return BadRequest(resultBooks.Error);

            return Ok(resultBooks.Value);
        }

        [HttpPost]
        public async Task<ActionResult<Result<Book>>> CreateBookAsync(
            [FromBody] CreateBookDTO createBookDto,
            CancellationToken ct)
        {
            Result<Book> result = await _bookService.CreateBookAsync(createBookDto.Title, ct);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Created();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Result<Guid>>> DeleteBookAsync(
            [FromRoute] Guid id,
            CancellationToken ct)
        {
            Result<Guid> result = await _bookService.DeleteBookAsync(id, ct);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return NoContent();
        }
    }
}
