using KitapYazar.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KitapYazar.DAL.Abstracts
{
	public interface IBookRepostory:IGenericRepostory<Book>
	{
		Task<List<Book>> GetVirtualizedBooksAsync(int startIndex, int count);
	}
}
