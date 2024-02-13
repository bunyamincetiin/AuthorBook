using KitapYazar.DAL.Contexts;
using KitapYazar.Entity.Entity;

namespace YazarveKitapEkleme
{
	internal class Program
	{
		static void Main(string[] args)
		{
			using (var context = new KitapYazarContext())
			{
				var authors = context.Authors.ToList();
				var a = 0;
				// Rastgele 1000000 kitap seç
				var books = context.Books.OrderBy(b => Guid.NewGuid()).ToList();

				// AuthorBook tablosuna rastgele eşleştirmeleri ekle
				var authorBooks = new List<AuthorBook>();

				foreach (var author in authors)
				{
					foreach (var book in books)
					{
						authorBooks.Add(new AuthorBook
						{
							Author = author,
							BookID = book.ID
						});
						a++;
						if (a % 50000 == 0)
							break;
					}
				}
				context.AuthorBooks.AddRange(authorBooks);
				context.SaveChanges();
			}

			Console.WriteLine("Yazarlar başarıyla eklenmiştir.");
			Console.ReadLine();
		}



	}
}

