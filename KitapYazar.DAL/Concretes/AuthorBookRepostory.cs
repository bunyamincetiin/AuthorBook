using KitapYazar.DAL.Abstracts;
using KitapYazar.DAL.Contexts;
using KitapYazar.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapYazar.DAL.Concretes
{
	public class AuthorBookRepostory : GenericRepostory<AuthorBook>, IAuthorBookRepostory
	{
		public AuthorBookRepostory(KitapYazarContext dbContext) : base(dbContext)
		{
		}
	}
}
