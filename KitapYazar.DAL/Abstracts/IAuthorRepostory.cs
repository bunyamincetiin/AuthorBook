using KitapYazar.Entity.Entity;

namespace KitapYazar.DAL.Abstracts
{
	public interface IAuthorRepostory: IGenericRepostory<Author>
	{
		Task<List<Author>> GetVirtualizedAuthorsAsync();
	}
}
