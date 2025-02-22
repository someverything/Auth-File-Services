using Business.Abstract;
using Core.Entities;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.Abstract;
using Entities.DTOs.AuthDTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthServices
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenServices _tokenServices;

        public IDataResult<List<UserDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Token>> LoginAsync(LoginDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> LogOutAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Token>> RefreshTokenLoginAsync(RefreshTokenDTO refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> RegisterAsync(RegisterDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> RemoveUserAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<string>> UpdateRefreshToken(string refreshToken, AppUser user)
        {
            throw new NotImplementedException();
        }
    }
}
