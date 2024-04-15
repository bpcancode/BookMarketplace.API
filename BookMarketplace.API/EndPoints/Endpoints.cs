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

        app.MapGet("api/Genre",
            handler: async (GenreService genreService) =>
                TypedResults.Ok(await genreService.GetAllGenres()));

        app.MapPost("api/Genre",
            handler: async (GenreRequestDto dto,GenreService genreService) =>
                TypedResults.Ok(await genreService.CreateGenre(dto)));

        app.MapGet("api/Book",
            handler: async (BookService bookService) =>
                TypedResults.Ok(await bookService.GetAllBooks()));

        app.MapGet("api/Book/{id}",
            handler: async (int id, BookService bookService) =>
                TypedResults.Ok(await bookService.GetBook(id)));

        app.MapPost("api/Book",
            handler: async (BookRequestDto dto, BookService bookService) =>
                TypedResults.Ok(await bookService.CreateBook(dto)));

        app.MapPut("api/Book/{id}",
           handler: async (int id, BookRequestDto dto, BookService bookService) =>
                TypedResults.Ok(await bookService.UpdateBook(id, dto)));

        return app;
    }
}
