using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMarketplace.Shared.Dtos;

public record BookRequestDto(string Title, string Description, int[] GenreIds, decimal Price, bool IsFixedPrice, bool IsExpired, Guid UserId, BookImageRequestDto? Image);
public record BookImageRequestDto(string image, string ImageName, string mimeType);