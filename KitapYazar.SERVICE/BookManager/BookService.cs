using KitapYazar.DAL.Abstracts;
using KitapYazar.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
