﻿namespace BookMarketplace.Shared.Dtos;

public record LoggedInUser(Guid Id, string Name, string Email, string Address, string Phone);
