using KitapYazar.Entity.Entity;
using KitapYazar.SERVICE.AuthorBookManager;
using KitapYazar.SERVICE.AuthorManager;
using KitapYazar.SERVICE.BookManager;
using Microsoft.AspNetCore.Mvc;

namespace KitapYazar.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class KitapYazarController : ControllerBase
	{
		private readonly IAuthorBookService _authorBookService;

		public KitapYazarController(IAuthorBookService authorBookService)
		{
			_authorBookService = authorBookService;
		}

		[HttpGet("AllBooks")]
		public async Task<IActionResult> GetAllBook(int pageNumber, int pageSize)
		{
			try
			{
				var result = await _authorBookService.GetBookDtosAsync(pageNumber, pageSize);
				return Ok(result);
			}
			catch (Exception ex)
			{
				// Log the exception if necessary
				return StatusCode(500, "Internal Server Error");
			}
		}


	}
}