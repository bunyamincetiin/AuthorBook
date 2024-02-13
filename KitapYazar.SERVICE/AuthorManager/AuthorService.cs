using KitapYazar.DAL.Abstracts;
using KitapYazar.DAL.Concretes;
using KitapYazar.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
