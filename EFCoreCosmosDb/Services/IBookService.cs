using EFCoreCosmosDb.Models;

namespace EFCoreCosmosDb.Services
{
    public interface IBookService
    {
        Task CreateBookAsync(CreateBookDto book);
        IEnumerable<GetBookDto> GetBooks();
    }
}
