using NnBlazorProj.Models;

namespace NnBlazorProj.Repository;

public static class EventRepository
{
    // -------------------------
    // STATIC DATA SOURCE
    // -------------------------
    private static readonly List<EventDto> Events = new()
{
    // --- 1–3 ---
    new EventDto { EventId = 1,  Name = "King Cake Bake-Off – Metairie Bakery",          Month = 1, IsFree = false },
    new EventDto { EventId = 2,  Name = "MQVN Farmers Market (Village de l’Est)",        Month = 1, IsFree = true  },
    new EventDto { EventId = 3,  Name = "Vietnamese Storytime – East Bank Library",      Month = 2, IsFree = true  },
    new EventDto { EventId = 4,  Name = "City Park Families 3K Fun Run",                 Month = 3, IsFree = true  },

    // --- 4–6 ---
    new EventDto { EventId = 5,  Name = "Vietnamese Cooking Class: Bánh Xèo",            Month = 4, IsFree = false },
    new EventDto { EventId = 6,  Name = "Lafreniere Park Kite Day",                      Month = 4, IsFree = true  },
    new EventDto { EventId = 7,  Name = "Bucktown Marina Sunset Walk Meetup",            Month = 5, IsFree = true  },
    new EventDto { EventId = 8,  Name = "Saigon Plaza Night Market (Gretna)",            Month = 6, IsFree = true  },

    // --- 7–9 ---
    new EventDto { EventId = 9,  Name = "Metairie Road Summer Art Stroll",               Month = 7, IsFree = true  },
    new EventDto { EventId = 10, Name = "Lion Dance Workshop – Chùa Linh Sơn",           Month = 7, IsFree = false },
    new EventDto { EventId = 11, Name = "Back-to-School Swap – West Esplanade",          Month = 8, IsFree = true  },
    new EventDto { EventId = 12, Name = "City Park Moon-Viewing Picnic",                 Month = 9, IsFree = true  },

    // --- 10–12 ---
    new EventDto { EventId = 13, Name = "Vietnamese Book Club – Fall Meetup",            Month = 10, IsFree = true },
    new EventDto { EventId = 14, Name = "Westbank Community Potluck – Vietnamese Dishes",Month = 11, IsFree = true },
    new EventDto { EventId = 15, Name = "Lafreniere Park Lights Walk",                   Month = 12, IsFree = true },
    new EventDto { EventId = 16, Name = "Holiday Bánh Chưng Wrapping Meetup",            Month = 12, IsFree = false },
};

    // -------------------------
    // STATIC METHODS
    // -------------------------

    public static List<EventDto> GetAll() =>
        Events.OrderBy(e => e.Month).ThenBy(e => e.Name).ToList();

    public static EventDto? GetById(int id) =>
        Events.FirstOrDefault(e => e.EventId == id);

    public static List<EventDto> GetByMonth(int month) =>
        Events.Where(e => e.Month == month)
              .OrderBy(e => e.Name)
              .ToList();

    public static List<EventDto> SearchByName(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
            return GetAll();

        keyword = keyword.Trim().ToLower();
        return Events
            .Where(e => e.Name.ToLower().Contains(keyword))
            .OrderBy(e => e.Month)
            .ThenBy(e => e.Name)
            .ToList();
    }

    public static void Add(EventDto e)
    {
        int nextId = Events.Max(x => x.EventId) + 1;
        e.EventId = nextId;
        Events.Add(e);
    }

    public static void Update(EventDto e)
    {
        var existing = Events.FirstOrDefault(x => x.EventId == e.EventId);
        if (existing is null) return;

        existing.Name = e.Name;
        existing.Month = e.Month;
        existing.IsFree = e.IsFree;
    }

    public static void Delete(int id)
    {
        var existing = Events.FirstOrDefault(x => x.EventId == id);
        if (existing is not null)
            Events.Remove(existing);
    }
}