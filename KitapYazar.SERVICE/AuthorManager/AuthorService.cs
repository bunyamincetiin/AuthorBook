using KitapYazar.DAL.Abstracts;
using KitapYazar.Entity.Entity;

namespace KitapYazar.SERVICE.AuthorManager
{
	public class AuthorService : IAuthorService
	{
		private readonly IAuthorRepostory _authorRepository;

		public AuthorService(IAuthorRepostory authorRepository)
		{
			_authorRepository = authorRepository;
		}

		public async Task<List<Author>> GetAllAuthors()
		{
			var authors = await _authorRepository.GetVirtualizedAuthorsAsync(); 
			return authors;
		}

		public async Task<List<Author>> GetVirtualizedAuthorAsync(int startIndex, int count)
		{
			var authors = await _authorRepository.GetAllAsync(startIndex,count);

			return authors;  
		}
	}
}
