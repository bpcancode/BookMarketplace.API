using BookMarketplace.API.Services;
using BookMarketplace.Shared.Dtos;

namespace BookMarketplace.API.EndPoints;

public static class Endpoints
{
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/signup",
            handler: async (SignupRequestDto dto, AuthService authService) =>
                TypedResults.Ok(await authService.SignupAsync(dto)));

        app.MapPost("api/signin",
            handler: async (SigninRequestDto dto, AuthService authService) =>
                TypedResults.Ok(await authService.SigninAsync(dto)));

        return app;
    }
}
