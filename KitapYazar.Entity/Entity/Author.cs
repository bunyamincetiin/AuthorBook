using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapYazar.Entity.Entity
{
	public class Author : BaseEntity
	{
        public string Name { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }
    }
}
