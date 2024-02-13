using KitapYazar.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KitapYazar.DAL.Abstracts
{
	public interface IGenericRepostory<T> where T : BaseEntity
	{
		//buradaki parametre "no-tracking query" kullanılıp kullanılmayacağını (nesne üzerindeki değişimleri takip) belirler. noTracking: true ya da  noTracking: false
		Task<List<T>> GetAllAsync(int startIndex, int count);
		public Task<List<T>> FindByAsync(Expression<Func<T, bool>> predicate);
	}
}
