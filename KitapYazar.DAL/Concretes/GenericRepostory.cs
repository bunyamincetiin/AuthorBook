using KitapYazar.DAL.Abstracts;
using KitapYazar.DAL.Contexts;
using KitapYazar.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KitapYazar.DAL.Concretes
{
	public abstract class GenericRepostory<T> : IGenericRepostory<T> where T : BaseEntity
	{
		private readonly KitapYazarContext context;
		protected DbSet<T> entity => context?.Set<T>();
		public GenericRepostory(KitapYazarContext dbContext)
		{
			this.context = dbContext;
		}

		public async Task<List<T>> GetAllAsync(int startIndex, int count)
		{
			using (var context = new KitapYazarContext())
			{
				return  await entity
				.OrderBy(b => b.ID)
				.Skip(startIndex)
				.Take(count)
				.ToListAsync();
			}
		}

		public async Task<List<T>> FindByAsync(Expression<Func<T, bool>> predicate)
		{
			return await entity
		   .Where(predicate)
		   .ToListAsync();
		}
	}
}
