using Core.Entities;
using Core.Utilities.Results.Abstract;
using Entities.DTOs.AuthDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthServices
    {
        Task<IResult> RegisterAsync(RegisterDTO model);
        Task<IDataResult<Token>> LoginAsync(LoginDTO model);
        Task<IDataResult<string>> UpdateRefreshToken(string refreshToken, AppUser user);
        Task<IDataResult<Token>> RefreshTokenLoginAsync(RefreshTokenDTO refreshToken);
        Task<IResult> LogOutAsync(string userId);
        IDataResult<List<UserDTO>> GetAll();
        Task<IResult> RemoveUserAsync(string userId);
    }
}
