using entities;

namespace Service
{
    public interface IUsersService
    {
        int GetPasswordRate(string password);
        Task<User> Login(User user);
        Task<User> Register(User newUser);
        Task<bool> UpdateUser(int id, User userToUpdate);
    }
}