namespace NnBlazorProj.Repository;

public static class MonthRepository
{
    // ----------------------------------------
    // STATIC DATA SOURCE: Month groups + images
    // ----------------------------------------
    private static readonly List<MonthGroup> monthGroups = new()
    {
        new MonthGroup
        {
            Key = "spring",
            Name = "January – March",
            Months = new() { 1, 2, 3 },
            ImagePath = "images/seasons/spring.jpeg"
        },
        new MonthGroup
        {
            Key = "summer",
            Name = "April – June",
            Months = new() { 4, 5, 6 },
            ImagePath = "images/seasons/summer.jpg"
        },
        new MonthGroup
        {
            Key = "fall",
            Name = "July – September",
            Months = new() { 7, 8, 9 },
            ImagePath = "images/seasons/fall.png"
        },
        new MonthGroup
        {
            Key = "winter",
            Name = "October – December",
            Months = new() { 10, 11, 12 },
            ImagePath = "images/seasons/winter.jpg"
        }
    };

    // ----------------------------------------
    // PUBLIC METHODS
    // ----------------------------------------

    // Return all groups
    public static List<MonthGroup> GetMonthGroups() => monthGroups;

    // Find a group by its name (case-insensitive)
    private static MonthGroup? GetByName(string name) =>
        monthGroups.FirstOrDefault(
            g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
        );

    // Get numeric month list for a given group name
    public static List<int> GetMonths(string name) =>
        GetByName(name)?.Months ?? new List<int>();

    // Find which group name a specific month belongs to
    public static string? GetGroupNameByMonth(int month) =>
        monthGroups.FirstOrDefault(g => g.Months.Contains(month))?.Name;

    // Find image path for a given group name
    public static string? GetImageByName(string name) =>
        GetByName(name)?.ImagePath;
}

// ----------------------------------------
// DTO CLASS: MonthGroup
// ----------------------------------------
public class MonthGroup
{
    public string Name { get; set; } = string.Empty;       // e.g. "January – March"
    public List<int> Months { get; set; } = new();         // e.g. [1, 2, 3]
    public string Key { get; set; } = string.Empty;        // e.g. "spring"
    public string ImagePath { get; set; } = string.Empty;  // e.g. "images/seasons/spring.jpg"
}