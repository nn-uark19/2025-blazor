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
        new EventDto { EventId = 1,  Name = "New Year’s Day (US)", Month = 1,  IsFree = true },
        new EventDto { EventId = 2,  Name = "Tết Nguyên Đán (Vietnamese Lunar New Year)", Month = 1, IsFree = true },

        // --- FEBRUARY ---
        new EventDto { EventId = 3,  Name = "Valentine’s Day", Month = 2,  IsFree = false },
        new EventDto { EventId = 4,  Name = "President’s Day (US)", Month = 2,  IsFree = true },
        new EventDto { EventId = 5,  Name = "Lễ Hội Rằm Tháng Giêng (Full Moon Festival)", Month = 2, IsFree = true },

        // --- MARCH / APRIL ---
        new EventDto { EventId = 6,  Name = "Easter Sunday", Month = 3,  IsFree = true },
        new EventDto { EventId = 7,  Name = "Giỗ Tổ Hùng Vương (Hung Kings’ Commemoration Day)", Month = 4, IsFree = true },
        new EventDto { EventId = 8,  Name = "Vietnamese Áo Dài Festival", Month = 4, IsFree = false },

        // --- MAY ---
        new EventDto { EventId = 9,  Name = "Labor Day (International) / Quốc Tế Lao Động 1/5", Month = 5,  IsFree = true },
        new EventDto { EventId = 10, Name = "Memorial Day (US)", Month = 5,  IsFree = true },

        // --- JUNE / JULY ---
        new EventDto { EventId = 11, Name = "Juneteenth (US)", Month = 6,  IsFree = true },
        new EventDto { EventId = 12, Name = "Fourth of July (US Independence Day)", Month = 7,  IsFree = true },
        new EventDto { EventId = 13, Name = "Bánh Mì & Phở Festival", Month = 7,  IsFree = false },

        // --- AUGUST / SEPTEMBER ---
        new EventDto { EventId = 14, Name = "Vu Lan Báo Hiếu (Ullambana – Mother’s Day in Vietnam)", Month = 8,  IsFree = true },
        new EventDto { EventId = 15, Name = "Mid-Autumn Festival (Tết Trung Thu)", Month = 9,  IsFree = true },
        new EventDto { EventId = 16, Name = "Mooncake Tasting (Bánh Trung Thu)", Month = 9,  IsFree = false },

        // --- OCTOBER / NOVEMBER ---
        new EventDto { EventId = 17, Name = "Halloween (US)", Month = 10,  IsFree = false },
        new EventDto { EventId = 18, Name = "Thanksgiving Day (US)", Month = 11,  IsFree = true },
        new EventDto { EventId = 19, Name = "Ngày Nhà Giáo Việt Nam (Vietnamese Teachers’ Day)", Month = 11,  IsFree = true },

        // --- DECEMBER ---
        new EventDto { EventId = 20, Name = "Christmas Day", Month = 12,  IsFree = true },
        new EventDto { EventId = 21, Name = "New Year’s Eve Celebrations", Month = 12,  IsFree = false },
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