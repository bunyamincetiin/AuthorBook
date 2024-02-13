using KitapYazar.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapYazar.SERVICE.BookManager
{
	public interface IBookService
	{
		Task<List<Book>> GetVirtualizedBooksAsync(int startIndex, int count);
	}
}
