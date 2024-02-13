namespace KitapYazar.Entity.Entity
{
	public class AuthorBook : BaseEntity
	{
        public Guid AuthorID { get; set; }
        public Guid BookID { get; set; }

        public virtual Author Author { get; set; }
    }
}
