using NnBlazorProj.Models;

namespace NnBlazorProj.Repository;

public static class EventRepository
{
    // -------------------------
    // STATIC DATA SOURCE
    // -------------------------
    private static readonly List<EventDto> events = new List<EventDto>
{
    // --- JANUARY ---
    new EventDto { EventId = 1,  Name = "King Cake Bake-Off – Metairie Bakery", Month = 1,  IsFree = false },
    new EventDto { EventId = 2,  Name = "MQVN Farmers Market (Village de l’Est)", Month = 1, IsFree = true  },

    // --- FEBRUARY ---
    new EventDto { EventId = 3,  Name = "Vietnamese Coffee Workshop – Westbank", Month = 2, IsFree = false },
    new EventDto { EventId = 4,  Name = "Vietnamese Storytime – East Bank Library", Month = 2, IsFree = true },

    // --- MARCH ---
    new EventDto { EventId = 5,  Name = "City Park Families 3K Fun Run", Month = 3, IsFree = true },
    new EventDto { EventId = 6,  Name = "NOLA Night Market (Westbank)", Month = 3, IsFree = true },

    // --- APRIL ---
    new EventDto { EventId = 7,  Name = "Vietnamese Cooking Class: Bánh Xèo", Month = 4, IsFree = false },
    new EventDto { EventId = 8,  Name = "Lafreniere Park Kite Day", Month = 4, IsFree = true },

    // --- MAY ---
    new EventDto { EventId = 9,  Name = "Bucktown Marina Sunset Walk Meetup", Month = 5, IsFree = true },
    new EventDto { EventId = 10, Name = "Phở Cook-Off – Community Center", Month = 5, IsFree = false },

    // --- JUNE ---
    new EventDto { EventId = 11, Name = "Saigon Plaza Night Market (Gretna)", Month = 6, IsFree = true },
    new EventDto { EventId = 12, Name = "Bayou Segnette Family Picnic Meetup", Month = 6, IsFree = true },

    // --- JULY ---
    new EventDto { EventId = 13, Name = "Metairie Road Summer Art Stroll", Month = 7, IsFree = true },
    new EventDto { EventId = 14, Name = "Lion Dance Workshop – Chùa Linh Sơn", Month = 7, IsFree = false },

    // --- AUGUST ---
    new EventDto { EventId = 15, Name = "Back-to-School Swap – West Esplanade", Month = 8, IsFree = true },
    new EventDto { EventId = 16, Name = "Lantern Craft Workshop (Đèn Lồng)", Month = 8, IsFree = false },

    // --- SEPTEMBER ---
    new EventDto { EventId = 17, Name = "City Park Moon-Viewing Picnic", Month = 9, IsFree = true },
    new EventDto { EventId = 18, Name = "Mooncake Baking Demo", Month = 9, IsFree = false },

    // --- OCTOBER ---
    new EventDto { EventId = 19, Name = "Vietnamese Book Club – Fall Meetup", Month = 10, IsFree = true },

    // --- NOVEMBER / DECEMBER ---
    new EventDto { EventId = 20, Name = "Lafreniere Park Lights Walk", Month = 12, IsFree = true }
};

    // -------------------------
    // STATIC METHODS
    // -------------------------

    public static List<EventDto> GetAll() =>
        events.OrderBy(e => e.Month).ThenBy(e => e.Name).ToList();

    public static EventDto? GetById(int id) =>
        events.FirstOrDefault(e => e.EventId == id);

    public static List<EventDto> GetByMonth(int month) =>
        events.Where(e => e.Month == month)
              .OrderBy(e => e.Name)
              .ToList();

    public static List<EventDto> SearchByName(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
            return GetAll();

        keyword = keyword.Trim().ToLower();
        return events
            .Where(e => e.Name.ToLower().Contains(keyword))
            .OrderBy(e => e.Month)
            .ThenBy(e => e.Name)
            .ToList();
    }

    public static void Add(EventDto e)
    {
        int nextId = events.Max(x => x.EventId) + 1;
        e.EventId = nextId;
        events.Add(e);
    }

    public static void Update(EventDto e)
    {
        var existing = events.FirstOrDefault(x => x.EventId == e.EventId);
        if (existing is null) return;

        existing.Name = e.Name;
        existing.Month = e.Month;
        existing.IsFree = e.IsFree;
    }

    public static void Delete(int id)
    {
        var existing = events.FirstOrDefault(x => x.EventId == id);
        if (existing is not null)
            events.Remove(existing);
    }
}