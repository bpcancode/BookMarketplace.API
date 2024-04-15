using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMarketplace.API.Data.Entities;

public class BookImage
{
    public int Id { get; set; }
    public string Mime { get; set; }
    public string ImageName { get; set; }
    public byte[] ImageData { get; set; }

}
