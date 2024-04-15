using System.ComponentModel.DataAnnotations;

namespace BookMarketplace.API.Data.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }

    [MaxLength(400)]
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool IsFixedPrice { get; set; }
    public bool IsExpired { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public DateTime UpdateDate { get; set; } = DateTime.Now;
    public User User { get; set; }
    public Guid UserId { get; set; }
    public List<Genre> Genres { get; set; }
    public List<BookImage> BookImages { get; set; }
}

