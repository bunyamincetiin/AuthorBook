using KitapYazar.DAL.Abstracts;
using KitapYazar.Entity.Entity;
using KitapYazar.SERVICE.AuthorManager;
using KitapYazar.SERVICE.BookManager;
using Microsoft.Extensions.Logging;

namespace KitapYazar.SERVICE.AuthorBookManager
{
	public class AuthorBookService : IAuthorBookService
	{
		private readonly IAuthorBookRepostory _authorBookRepository;
		private readonly IBookService _bookService;
		private readonly IAuthorService _authorService;
		private readonly ILogger<AuthorBookService> _logger;
		public AuthorBookService(IAuthorBookRepostory authorBookRepository, IBookService bookService, IAuthorService authorService, ILogger<AuthorBookService> logger)
        {
            _authorBookRepository = authorBookRepository;
			_bookService = bookService;
			_authorService = authorService;
			_logger = logger;
		}

		public async Task<List<AuthorBook>> GetAuthorBooksByBookIdsAsync(List<Guid> bookIds)
		{
			var authorBooks = await _authorBookRepository.FindByAsync(ab => bookIds.Contains(ab.BookID));

			return authorBooks;
		}

		public async Task<List<AuthorBook>> GetVirtualizedAuthorAsync(int startIndex, int count)
		{
			var authorBooks = await _authorBookRepository.GetAllAsync(startIndex, count);

			return authorBooks;
		}
		public async Task<List<BookDto>> GetBookDtosAsync(int pageNumber,int pageSize)
		{
			try
			{
				var authors = await _authorService.GetAllAuthors();
				var books = await _bookService.GetVirtualizedBooksAsync((pageNumber - 1) * pageSize, pageSize);
				var bookIds = books.Select(book => book.ID).ToList();
				var authorBooks = await GetAuthorBooksByBookIdsAsync(bookIds);

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

				return (result);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "GetBookDtosAsync işlemi sırasında bir hata oluştu");
				return new List<BookDto>();
			}
		}
	}
}
