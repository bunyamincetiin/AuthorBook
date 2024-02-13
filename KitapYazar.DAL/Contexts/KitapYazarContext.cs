using KitapYazar.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace KitapYazar.DAL.Contexts
{
	public class KitapYazarContext : DbContext
	{
		public DbSet<Author> Authors { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<AuthorBook> AuthorBooks { get; set; }
		public KitapYazarContext(DbContextOptions options) : base(options)
		{
		}

		public KitapYazarContext()
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Data Source=BUNYAMIN;Initial Catalog=KitapYazarAPI4;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

				CultureInfo culture = CultureInfo.InvariantCulture;
				CultureInfo.DefaultThreadCurrentCulture = culture;
				CultureInfo.DefaultThreadCurrentUICulture = culture;
			}

			
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AuthorBook>()
			.HasKey(ab => new { ab.AuthorID, ab.BookID });

			modelBuilder.Entity<AuthorBook>()
				.HasOne(ab => ab.Author)
				.WithMany(a => a.AuthorBooks)
				.HasForeignKey(ab => ab.AuthorID);

			//modelBuilder.Entity<AuthorBook>()
			//	.HasOne(ab => ab.Book)
			//	.WithMany()  
			//	.HasForeignKey(ab => ab.BookID);

			base.OnModelCreating(modelBuilder);

		}
	}

}
