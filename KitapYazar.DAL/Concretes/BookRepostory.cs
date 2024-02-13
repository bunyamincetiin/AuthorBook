using KitapYazar.DAL.Abstracts;
using KitapYazar.DAL.Contexts;
using KitapYazar.Entity.Entity;
using Microsoft.EntityFrameworkCore;


namespace KitapYazar.DAL.Concretes
{
	public class BookRepostory : GenericRepostory<Book>, IBookRepostory
	{
		public BookRepostory(KitapYazarContext dbContext) : base(dbContext)
		{
		}

		public async Task<List<Book>> GetVirtualizedBooksAsync(int startIndex, int count)
		{

			return await entity
				.OrderBy(b => b.ID)  
				.Skip(startIndex)
				.Take(count)
				.ToListAsync();
		}
	}
}
