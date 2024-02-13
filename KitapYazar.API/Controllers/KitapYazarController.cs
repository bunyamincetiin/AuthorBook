using KitapYazar.Entity.Entity;
using KitapYazar.SERVICE.AuthorBookManager;
using KitapYazar.SERVICE.AuthorManager;
using KitapYazar.SERVICE.BookManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitapYazar.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class KitapYazarController : ControllerBase
	{
		private readonly IBookService _bookService;
		private readonly IAuthorBookService _authorBookService;
		private readonly IAuthorService _authorService;
		private readonly ILogger<KitapYazarController> _logger;

		public KitapYazarController(IBookService bookService,IAuthorService authorService,IAuthorBookService authorBookService ,ILogger<KitapYazarController> logger)
		{
			_bookService = bookService;
			_authorBookService = authorBookService;
			_authorService = authorService;
			_logger = logger;
		}

		[HttpGet("AllBooks")]
		public async Task<IActionResult> GetAllBook(int pageNumber, int pageSize)
		{
			_logger.LogInformation("GetAllBooks method entered.");

			try
			{
				var authors = await _authorService.GetAllAuthors();
				var books = await _bookService.GetVirtualizedBooksAsync((pageNumber - 1) * pageSize, pageSize);
				var bookIds = books.Select(book => book.ID).ToList();
				var authorBooks = await _authorBookService.GetAuthorBooksByBookIdsAsync(bookIds);

				_logger.LogInformation("Books successfully retrieved.");

				var result = books.Select(book =>
				{
					var authorBook = authorBooks.FirstOrDefault(ab => ab.BookID == book.ID);
					var author = authors.FirstOrDefault(a => a.ID == authorBook?.AuthorID);

					return new BookDto
					{
						BookId = book.ID,
						BookName = book.Name,
						BookDescription = book.Description,
						AuthorName = author?.Name,
						AuthorSurname = author?.LastName
					};
				}).ToList();

				return Ok(result);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception: {ex}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}


	}
}