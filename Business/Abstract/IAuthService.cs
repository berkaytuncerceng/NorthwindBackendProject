using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.Jwt;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userDto, string password);
        IDataResult<User> Login(UserForLoginDto userDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> GetAccessToken(User user);


    }
}