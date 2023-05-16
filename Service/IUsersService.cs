using entities;

namespace Service
{
    public interface IUsersService
    {
        Task<User> Login(User user);
        Task<User> Register(User newUser);
        Task<bool> UpdateUser(int id, User userToUpdate);
    }
}