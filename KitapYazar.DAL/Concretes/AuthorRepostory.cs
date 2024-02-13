using KitapYazar.DAL.Abstracts;
using KitapYazar.DAL.Contexts;
using KitapYazar.Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace KitapYazar.DAL.Concretes
{
	public class AuthorRepostory : GenericRepostory<Author>, IAuthorRepostory
	{
		public AuthorRepostory(KitapYazarContext dbContext) : base(dbContext)
		{
		}

		public async Task<List<Author>> GetVirtualizedAuthorsAsync()
		{
			return await entity.ToListAsync();
		}
	}
}
