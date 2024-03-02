namespace EFCoreCosmosDb.Models
{
    public class GetBookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int NmPages { get; set; }
        public List<string> Authors { get; set; }
    }
}
