using Project.Models.DTOs;
using Project.Models.Responses;
using Project.Models.DTOs.UserDTOs;

namespace Project.Services.UserService
{
    public interface IUserService
    {
        Task<UserFormattedDTO> GetUserById(Guid id);
        Task<UserFormattedDTO> GetUserByUsername(string username);
        Task<UserFormattedDTO> CreateAsync(UserCreateDTO user);
        Task Update(UserUpdateDTO user);
        Task Delete(Guid id);

        Task<Guid> Login(LoginDTO loginModel);
        Task Logout();
        Task<ErrorResponse> SignUp(SignUpDTO signUpDto);
    }
}
