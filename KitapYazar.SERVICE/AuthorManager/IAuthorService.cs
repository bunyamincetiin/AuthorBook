using KitapYazar.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapYazar.SERVICE.AuthorManager
{
	public  interface IAuthorService
	{
		Task<List<Author>> GetVirtualizedAuthorAsync(int startIndex, int count);
		Task<List<Author>> GetAllAuthors();
	}
}
