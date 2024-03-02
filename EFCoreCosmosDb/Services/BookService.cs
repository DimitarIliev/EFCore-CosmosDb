using EFCoreCosmosDb.Data;
using EFCoreCosmosDb.Models;

namespace EFCoreCosmosDb.Services
{
    public class BookService : IBookService
    {
        public async Task CreateBookAsync(CreateBookDto book)
        {
            using (var context = new LibraryContext())
            {
                var bookId = Guid.NewGuid();

                context.Add(
                    new Book
                    {
                        Id = bookId,
                        Authors = book.Authors,
                        NmPages = book.NmPages,
                        PartitionKey = bookId.ToString(),
                        Title = book.Title,
                    });

                await context.SaveChangesAsync();
            }
        }

        public IEnumerable<GetBookDto> GetBooks()
        {
            using (var context = new LibraryContext())
            {
                var books = context.Books
                    .ToList()
                    .ConvertAll(x => new GetBookDto
                    {
                        Title = x.Title,
                        Authors = x.Authors,
                        Id = x.Id,
                        NmPages = x.NmPages,
                    });

                return books;
            }
        }
    }
}
