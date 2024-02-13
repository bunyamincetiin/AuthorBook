namespace KitapYazar.Entity.Entity
{
	public class Author : BaseEntity
	{
        public string Name { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }
    }
}
