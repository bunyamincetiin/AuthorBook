using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapYazar.Entity.Entity
{
	public class BookDto
	{
		public Guid BookId { get; set; }
		public string BookName { get; set; }
		public string BookDescription { get; set; }
		public string AuthorName { get; set; }
		public string AuthorSurname { get; set; }
	}
}
