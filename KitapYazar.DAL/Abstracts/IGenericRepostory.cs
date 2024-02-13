using KitapYazar.Entity.Entity;
using System.Linq.Expressions;

namespace KitapYazar.DAL.Abstracts
{
	public interface IGenericRepostory<T> where T : BaseEntity
	{
		//buradaki parametre "no-tracking query" kullanılıp kullanılmayacağını (nesne üzerindeki değişimleri takip) belirler. noTracking: true ya da  noTracking: false
		Task<List<T>> GetAllAsync(int startIndex, int count);
		public Task<List<T>> FindByAsync(Expression<Func<T, bool>> predicate);
	}
}
