using KitapYazar.DAL.Contexts;
using KitapYazar.Entity.Entity;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace KitapYazar.Veri
{
	public class Program
	{
		static void Main(string[] args)
		{
			using (var context = new KitapYazarContext())
			{
				//for (int i = 0; i < 20; i++)
				//{
				//	string name = "Author" + i;

				//	string lastName = "Yazar" + i + i;

				//	var author = new Author
				//	{
				//		Name = name,
				//		LastName = lastName
				//	};
				//	context.Add(author);
				//}
				//context.SaveChanges();

				//for (int i = 0; i < 1000000; i++)
				//{

				//	string bookName = "Kitap" + i;

				//	string bookDescription = "KitapKitap" + i + i;

				//	var book = new Book
				//	{
				//		Name = bookName,
				//		Description = bookDescription
				//	};

				//	context.Books.Add(book);
				//}
				//context.SaveChanges();

			//	var authors = context.Authors.OrderBy(a => a.ID).ToList();

			//	var books = context.Books.OrderBy(b => b.ID).ToList();

			//	var a = 1;



			//	foreach (var author in authors)
			//	{
			//		foreach (var book in books)
			//		{
			//			var authorBooks = new AuthorBook
			//			{
			//				AuthorID = author.ID,
			//				BookID = book.ID,
			//			};
			//			a++;
			//			if (a % 50000 == 0)
			//			{
			//				break;
			//			}
			//			context.AuthorBooks.Add(authorBooks);
			//		}
			//	}
			//	context.SaveChanges();
			}

			//Console.WriteLine("Kitaplar başarıyla eklenmiştir.");
		}

		
	}
}

