using entities;

namespace Service
{
    public interface IUsersService
    {
        Task<User> SignIn(User user);
        Task<User> SignUp(User newUser);
        Task<bool> UpdateUser(int id, User userToUpdate);
    }
}