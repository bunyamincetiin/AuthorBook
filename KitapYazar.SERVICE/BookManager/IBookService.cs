using KitapYazar.Entity.Entity;

namespace KitapYazar.SERVICE.BookManager
{
	public interface IBookService
	{
		Task<List<Book>> GetVirtualizedBooksAsync(int startIndex, int count);
	}
}
