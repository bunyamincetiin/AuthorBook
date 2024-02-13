using KitapYazar.DAL.Abstracts;
using KitapYazar.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapYazar.SERVICE.AuthorBookManager
{
	public class AuthorBookService : IAuthorBookService
	{
		private readonly IAuthorBookRepostory _authorBookRepository;
        public AuthorBookService(IAuthorBookRepostory authorBookRepository)
        {
            _authorBookRepository = authorBookRepository;
        }

		public async Task<List<AuthorBook>> GetAuthorBooksByBookIdsAsync(List<Guid> bookIds)
		{
			var authorBooks = await _authorBookRepository.FindByAsync(ab => bookIds.Contains(ab.BookID));

			return authorBooks;
		}

		public async Task<List<AuthorBook>> GetVirtualizedAuthorAsync(int startIndex, int count)
		{
			var authorBooks = await _authorBookRepository.GetAllAsync(startIndex, count);

			return authorBooks;
		}
	}
}
