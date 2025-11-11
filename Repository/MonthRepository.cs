namespace NnBlazorProj.Repository;

public static class MonthRepository
{
    private static readonly List<string> monthGroups = new List<string>
    {
        "January – March",
        "April – July",
        "August – October",
        "November – December"
    };

    public static List<string> GetMonthGroups() => monthGroups;
}