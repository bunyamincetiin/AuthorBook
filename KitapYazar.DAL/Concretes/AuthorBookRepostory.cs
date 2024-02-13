using KitapYazar.DAL.Abstracts;
using KitapYazar.DAL.Contexts;
using KitapYazar.Entity.Entity;

namespace KitapYazar.DAL.Concretes
{
	public class AuthorBookRepostory : GenericRepostory<AuthorBook>, IAuthorBookRepostory
	{
		public AuthorBookRepostory(KitapYazarContext dbContext) : base(dbContext)
		{
		}
	}
}
