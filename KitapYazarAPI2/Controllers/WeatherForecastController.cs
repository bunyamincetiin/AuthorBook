using KitapYazar.SERVICE.BookManager;
using Microsoft.AspNetCore.Mvc;

namespace KitapYazarAPI2.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly IBookService _bookService;
        public WeatherForecastController(IBookService bookService)
        {
			_bookService = bookService;
		}
        private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherForecastController> _logger;

		public WeatherForecastController(ILogger<WeatherForecastController> logger)
		{
			_logger = logger;
		}

		[HttpGet("GetAllBooks")]
		public async Task<IActionResult> GetAllBooks()
		{
			Console.WriteLine("GetAllBooks metoduna giriþ yapýldý.");
			try
			{
				var books = await _bookService.GetAllBooks();
				Console.WriteLine("Kitaplar baþarýyla alýndý.");
				return Ok(books);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}
	}
}
