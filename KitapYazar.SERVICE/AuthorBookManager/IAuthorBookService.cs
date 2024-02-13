using KitapYazar.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapYazar.SERVICE.AuthorBookManager
{
	public interface IAuthorBookService
	{
		Task<List<AuthorBook>> GetVirtualizedAuthorAsync(int startIndex, int count);
		public Task<List<AuthorBook>> GetAuthorBooksByBookIdsAsync(List<Guid> bookIds);
	}
}
