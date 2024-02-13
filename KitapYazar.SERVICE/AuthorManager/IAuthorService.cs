using KitapYazar.Entity.Entity;

namespace KitapYazar.SERVICE.AuthorManager
{
	public  interface IAuthorService
	{
		Task<List<Author>> GetVirtualizedAuthorAsync(int startIndex, int count);
		Task<List<Author>> GetAllAuthors();
	}
}
