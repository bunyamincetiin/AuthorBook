using KitapYazar.Entity.Entity;

namespace KitapYazar.DAL.Abstracts
{
	public interface IBookRepostory:IGenericRepostory<Book>
	{
		Task<List<Book>> GetVirtualizedBooksAsync(int startIndex, int count);
	}
}
