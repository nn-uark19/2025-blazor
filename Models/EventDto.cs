using System.ComponentModel.DataAnnotations;

namespace NnBlazorProj.Models;

public class EventDto
{
    public EventDto()
    {
        var random = new Random();
        int randomNumber = random.Next(0, 2);
        IsFree = randomNumber == 1;

        // default to current month
        Month = DateTime.Now.Month;
    }

    public int EventId { get; set; }
    public bool IsFree { get; set; }

    [Required]
    public string? Name { get; set; }

    [Range(1, 12, ErrorMessage = "Month must be between 1 and 12.")]
    public int Month { get; set; }
}