using ExampleAPI.Api.UserManager.Models;
using System.Threading.Tasks;

namespace ExampleAPI.Api.UserManager.Interfaces
{
    public interface IUsersService
    {
        Task<(bool IsSuccess, UserModel User, string ErrorMessage)> PostUserLoginAsync(LoginModel login);
    }
}
