using BookMarketplace.Shared.Dtos;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMarketplace.App.Services;

public interface IBookService
{
    [Get("api/book")]
    Task<ResultWithDataDto<List<BookResponseDto>>> GetAllBooks();
}
