using entities;

namespace Repository
{
    public interface IUsersRepository
    {
        Task<User> AddUser(User newUser);
        Task<User> FindUser(User userToFind);
        Task<User> GetUser(int id);
        Task<bool> IsUserNameExist(string Email);
        Task UpdateUser(int id, User userToUpdate);
    }
}