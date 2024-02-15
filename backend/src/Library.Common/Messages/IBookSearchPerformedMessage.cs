
using Library.Common.Enums;

namespace Library.Common.Messages;

public interface IBookSearchPerformedMessage
{
    public DateTime MessageDate { get; set; }
    public string MessageId { get; set; }
    public SearchBookCriteriaEnum Criteria { get; set; }
    public string Search { get; set; }
}
