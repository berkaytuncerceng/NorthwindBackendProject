using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Concrete;
using System.Collections.Generic;
using System.Security.Claims;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;

        ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> GetAccessToken(User user)
        {
            var userClaims = _userService.GetClaims(user);
            var userToken = _tokenHelper.CreateToken(user, userClaims);
            return new SucceededDataResult<AccessToken>(userToken, Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userDto)
        {
            var userToCheck = _userService.GetByMail(userDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SucceededDataResult<User>(userToCheck);

        }

        public IDataResult<User> Register(UserForRegisterDto userDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            User user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SucceededDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            else
            {
                return new SucceededResult(Messages.UserFound);
            }
        }
    }
}
