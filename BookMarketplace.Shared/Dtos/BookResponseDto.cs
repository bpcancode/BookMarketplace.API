using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMarketplace.Shared.Dtos;

public record BookResponseDto(int Id, string Title, string Description, decimal Price, bool IsFixedPrice, bool IsExpired, List<GenreResponseDto> Genres, List<BookImageResponseDto> BookImage);

public record BookImageResponseDto(int Id, string ImageName, string Mime, byte[] Image);