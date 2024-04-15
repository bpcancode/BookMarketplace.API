using BookMarketplace.API.Data;
using BookMarketplace.API.Data.Entities;
using BookMarketplace.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Reflection.Metadata.Ecma335;

namespace BookMarketplace.API.Services;

public class GenreService(DataContext dbContext)
{
    private readonly DataContext _dbContext = dbContext;

    public async Task<ResultWithDataDto<List<GenreResponseDto>>> GetAllGenres()
    {
        var res = await _dbContext.Genres.ToListAsync();
        var genres = res.Select(x => new GenreResponseDto(x.Id, x.Name)).ToList();
        return ResultWithDataDto<List<GenreResponseDto>>.Success(genres);
    }

    public async Task<ResultDto> CreateGenre(GenreRequestDto dto)
    {
        Genre genre = new()
        {
            Name = dto.Name,
        };

        await _dbContext.Genres.AddAsync(genre);
        await _dbContext.SaveChangesAsync();
        return ResultDto.Success();
    }
    
}
