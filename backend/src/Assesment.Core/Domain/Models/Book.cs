
namespace Library.Core.Domain.Models
{
    public class Book : ModelBase
    {
        public required string Title { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int TotalCopies { get; set; }
        public int CopiesInUse { get; set; }
        public string? Type { get; set; }
        public string? ISBN { get; set; }
        public string? Category { get; set; }
    }
}
