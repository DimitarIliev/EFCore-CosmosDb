using EFCoreCosmosDb.Models;
using EFCoreCosmosDb.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreCosmosDb.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BookController
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;

        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet(Name = "GetBooks")]
        public IEnumerable<GetBookDto> Get()
        {
            return _bookService.GetBooks();
        }

        [HttpPost(Name = "Book")]
        public async Task Post(CreateBookDto book)
        {
            await _bookService.CreateBookAsync(book);
        }
    }
}
