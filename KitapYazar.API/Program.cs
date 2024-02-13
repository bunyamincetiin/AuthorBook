using KitapYazar.API;
using KitapYazar.DAL.Abstracts;
using KitapYazar.DAL.Concretes;
using KitapYazar.DAL.Contexts;
using KitapYazar.Entity.Entity;
using KitapYazar.SERVICE.AuthorBookManager;
using KitapYazar.SERVICE.AuthorManager;
using KitapYazar.SERVICE.BookManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Globalization;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		builder.Services.AddControllers();
		builder.Services.AddScoped<IBookService, BookService>();
		builder.Services.AddScoped<IBookRepostory, BookRepostory>();
		builder.Services.AddScoped<IAuthorBookRepostory, AuthorBookRepostory>();
		builder.Services.AddScoped<IAuthorBookService, AuthorBookService>();
		builder.Services.AddScoped<IAuthorRepostory, AuthorRepostory>();
		builder.Services.AddScoped<IAuthorService, AuthorService>();

		builder.Services.AddCors(options =>
		{
			options.AddPolicy("AllowOrigin", builder =>
			{
				builder.AllowAnyOrigin()
					   .AllowAnyMethod()
					   .AllowAnyHeader();
			});
		});

		builder.Services.AddDbContext<KitapYazarContext>(options =>
		{
			options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"));
			CultureInfo culture = CultureInfo.InvariantCulture;
			CultureInfo.DefaultThreadCurrentCulture = culture;
			CultureInfo.DefaultThreadCurrentUICulture = culture;
		});

		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen(c =>
		{
			c.SwaggerDoc("v1", new OpenApiInfo { Title = "KitapYazar API", Version = "v1" });
		});

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KitapYazar API v1"));
			app.UseCors("AllowOrigin");
		}

		app.UseHttpsRedirection();
		app.UseAuthorization();
		app.MapControllers();

		app.Run();
	}
}
