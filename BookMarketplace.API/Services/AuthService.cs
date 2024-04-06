using BookMarketplace.API.Data;

namespace BookMarketplace.API.Services;

public class AuthService(DataContext context, TokenService tokenService, PasswordService passwordService)
{

    public async Task SignupAsync()
    {

    }

    public async Task SigninAsync()
    {

    }
}
