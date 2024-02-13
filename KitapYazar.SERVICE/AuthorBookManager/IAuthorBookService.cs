using KitapYazar.Entity.Entity;

namespace KitapYazar.SERVICE.AuthorBookManager
{
	public interface IAuthorBookService
	{
		Task<List<AuthorBook>> GetVirtualizedAuthorAsync(int startIndex, int count);
		public Task<List<AuthorBook>> GetAuthorBooksByBookIdsAsync(List<Guid> bookIds);
		public  Task<List<BookDto>> GetBookDtosAsync(int pageNumber, int pageSize);
	}
}
