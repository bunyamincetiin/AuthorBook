using KitapYazar.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Globalization;

namespace KitapYazar.API
{
	public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<KitapYazarContext>
	{
		public KitapYazarContext CreateDbContext(string[] args)
		{

			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			var optionsBuilder = new DbContextOptionsBuilder<KitapYazarContext>();
			optionsBuilder.UseSqlServer(configuration.GetConnectionString("sqlConnection"), a => a.MigrationsAssembly("KitapYazar.API"));
			CultureInfo culture = CultureInfo.InvariantCulture;
			CultureInfo.DefaultThreadCurrentCulture = culture;
			CultureInfo.DefaultThreadCurrentUICulture = culture;

			return new KitapYazarContext(optionsBuilder.Options);
		}
	}
}
