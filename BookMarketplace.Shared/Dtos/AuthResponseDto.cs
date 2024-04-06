namespace BookMarketplace.Shared.Dtos;

public record AuthResponseDto(LoggedInUser User, string Token);
