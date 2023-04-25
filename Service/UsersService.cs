using entities;
using Repository;
using Zxcvbn;


namespace Service
{
    public class UsersService : IUsersService
    {
        IUsersRepository _userRepository;
        public UsersService(IUsersRepository UserRepository)=>_userRepository = UserRepository;
      
        public async Task<User> Login(User user)=>await _userRepository.FindUser(user);


        public async Task<User> Register(User newUser)
        {
            if ( GetPasswordRate(newUser.Password) >= 2 && !await _userRepository.IsUserNameExist(newUser.Email))
                return await _userRepository.AddUser(newUser);
            return null;
        }

        public async Task<bool> UpdateUser(int id, User userToUpdate)
        {
            User user =await _userRepository.GetUser(id);
            //if(!user) return false
            if (user.Email != userToUpdate.Email && await _userRepository.IsUserNameExist(userToUpdate.Email))
                return false;
            await _userRepository.UpdateUser(id, userToUpdate);
            return true;
        }

        public  int GetPasswordRate(string password)
        {
            return Zxcvbn.Core.EvaluatePassword(password).Score;
        }
    }
}
