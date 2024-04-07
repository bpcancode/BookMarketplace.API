using System.ComponentModel.DataAnnotations;

namespace BookMarketplace.API.Data.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }

    [MaxLength(400)]
    public string Description { get; set; }
    public string Condition { get; set; } = string.Empty;
    public User User { get; set; }
    public List<Genre> Genres { get; set; }
}

