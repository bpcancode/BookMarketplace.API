using BookMarketplace.API.Data;
using BookMarketplace.API.Data.Entities;
using BookMarketplace.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;

namespace BookMarketplace.API.Services;

public class AuthService(DataContext context, TokenService tokenService, PasswordService passwordService)
{
    private readonly DataContext _context = context;
    private readonly TokenService _tokenService = tokenService;
    private readonly PasswordService _passwordService = passwordService;

    public async Task<ResultWithDataDto<AuthResponseDto>> SignupAsync(SignupRequestDto dto)
    {
        if ( await _context.Users.AsNoTracking().AnyAsync(x => x.Email == dto.Email))
        {
            return ResultWithDataDto<AuthResponseDto>.Failure("Email already exists");
        }

        var user = new User
        {
            Email = dto.Email,
            Name = dto.Name,
            Address = dto.Address,
        };

        (user.Salt, user.Hash) = _passwordService.GenerateSaltAndHash(dto.Password);

        try
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return GenerateAuthResponse(user);
        }
        catch (Exception ex)
        {
            return ResultWithDataDto<AuthResponseDto>.Failure(ex.Message);
        }
    }

    public async Task<ResultWithDataDto<AuthResponseDto>> SigninAsync(SigninRequestDto dto)
    {
        var dbUser = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == dto.Email);

        if (dbUser is null)
            return ResultWithDataDto<AuthResponseDto>.Failure("User doesnot exists");

        if(!_passwordService.IsEqual(dto.Password, dbUser.Salt, dbUser.Hash))
            return ResultWithDataDto<AuthResponseDto>.Failure("Incorrect password");

        return GenerateAuthResponse(dbUser);
    }

    private ResultWithDataDto<AuthResponseDto> GenerateAuthResponse(User user)
    {
        var loggedInUser = new LoggedInUser(user.Id, user.Name, user.Address, user.Email);
        var token = _tokenService.GenerateJwt(loggedInUser);

        var authResponse = new AuthResponseDto(loggedInUser, token);
        return ResultWithDataDto<AuthResponseDto>.Success(authResponse);
    }

}
