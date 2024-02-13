using KitapYazar.DAL.Abstracts;
using KitapYazar.Entity.Entity;

namespace KitapYazar.SERVICE.BookManager
{
	public class BookService : IBookService
	{
		private readonly IBookRepostory _bookRepostory;
		public BookService(IBookRepostory bookRepostory)
		{
			_bookRepostory = bookRepostory;
		}

		public async Task<List<Book>> GetVirtualizedBooksAsync(int startIndex, int count)
		{
			var books = await _bookRepostory.GetVirtualizedBooksAsync(startIndex, count);
			
			return books;
		}
	}
}
