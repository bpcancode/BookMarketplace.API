using BookMarketplace.API.Data;
using BookMarketplace.API.Data.Entities;
using BookMarketplace.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BookMarketplace.API.Services;

public class BookService(DataContext dbContext)
{
    private readonly DataContext _dbContext = dbContext;

    public async Task<ResultWithDataDto<List<BookResponseDto>>> GetAllBooks()
    {
        var res = await _dbContext.Books.Include(x => x.Genres)
            .ThenInclude(x => x.Books)
            .Include(x => x.BookImages)
            .ToListAsync();
        List<BookResponseDto> books = res.Select(x => new BookResponseDto(
                x.Id,
                x.Title,
                x.Description,
                x.Price,
                x.IsFixedPrice,
                x.IsExpired,
                x.Genres.Select(g => new GenreResponseDto(g.Id, g.Name)).ToList(),
                x.BookImages.Select(g => new BookImageResponseDto(g.Id, g.ImageName, g.Mime, g.ImageData)).ToList()
            )).ToList();

        return ResultWithDataDto<List<BookResponseDto>>.Success(books);
    }

    public async Task<ResultWithDataDto<BookResponseDto>> GetBook(int id)
    {
        var res = await _dbContext.Books.Include(x => x.Genres)
            .ThenInclude(x => x.Books)
            .Include(x => x.BookImages)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (res is null)
            return ResultWithDataDto<BookResponseDto>.Failure("Book not Found");

        var book = new BookResponseDto(res.Id,
            res.Title,
            res.Description,
            res.Price,
            res.IsFixedPrice,
            res.IsExpired,
            res.Genres.Select(g => new GenreResponseDto(g.Id, g.Name)).ToList(),
            res.BookImages.Select(g => new BookImageResponseDto(g.Id, g.ImageName, g.Mime, g.ImageData)).ToList()
            );

        return ResultWithDataDto<BookResponseDto>.Success(book);
    }

    public async Task<ResultDto> CreateBook(BookRequestDto dto)
    {
        var book = new Book
        {
            Title = dto.Title,
            Description = dto.Description,
            Price = dto.Price,
            IsFixedPrice = dto.IsFixedPrice,
        };
        book.Genres = [];
        book.BookImages = [];

        if (dto.Image is not null)
        {

            book.BookImages.Add(new BookImage
            {
                ImageName = dto.Image.ImageName,
                ImageData = Convert.FromBase64String(dto.Image.image),
                Mime = dto.Image.mimeType,
            });
        }

        foreach (var id in dto.GenreIds)
        {
            var genre = await _dbContext.Genres.FirstOrDefaultAsync(x => x.Id == id);
            if (genre is not null)
                book.Genres.Add(genre);
        }

        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == dto.UserId);
        if (user is null)
            return ResultDto.Failure("No User Found");

        book.User = user;
        var entity = await _dbContext.Books.AddAsync(book);
        await _dbContext.SaveChangesAsync();

        return ResultDto.Success();
    }

    public async Task<ResultDto> UpdateBook(int id, BookRequestDto dto)
    {
        var book = await _dbContext.Books.Include(x => x.Genres)
            .ThenInclude(x => x.Books)
            .Include(x => x.BookImages)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (book is null)
            return ResultDto.Failure("Book Not Found");

        book.UpdateDate = DateTime.Now;
        book.Title = dto.Title;
        book.Description = dto.Description;
        book.IsFixedPrice = dto.IsFixedPrice;
        book.IsExpired = dto.IsExpired;

        book.Genres = [];
        book.BookImages = [];
        foreach (var genreId in dto.GenreIds)
        {
            var genre = await _dbContext.Genres.FirstOrDefaultAsync(x => x.Id == genreId);
            if (genre is not null)
                book.Genres.Add(genre);
        }

        _dbContext.Books.Update(book);
        await _dbContext.SaveChangesAsync();

        return ResultDto.Success();

    }
}
