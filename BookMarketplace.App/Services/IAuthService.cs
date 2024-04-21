using BookMarketplace.Shared.Dtos;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMarketplace.App.Services;

public interface IAuthService
{
    [Post("/api/singup")]
    Task<ResultWithDataDto<AuthResponseDto>> SignupAsync(SignupRequestDto dto);
    
    [Post("/api/singin")]
    Task<ResultWithDataDto<AuthResponseDto>> SigninAsync(SigninRequestDto dto);
}
