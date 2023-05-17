using entities;
using Repository;
using Zxcvbn;


namespace Service
{
    public class UsersService : IUsersService
    {
        IUsersRepository _userRepository;
        IPasswordStrengthService _passwordStrengthService;
        public UsersService(IUsersRepository UserRepository, IPasswordStrengthService passwordStrengthService)
        {
            _userRepository = UserRepository;
            _passwordStrengthService = passwordStrengthService;
        }
      
        public async Task<User> Login(User user)=>await _userRepository.FindUser(user);


        public async Task<User> Register(User newUser)
        {
            if (_passwordStrengthService.passwordScore(newUser.Password) >= 2 && !await _userRepository.IsUserNameExist(newUser.Email))
                return await _userRepository.AddUser(newUser);
            return null;
        }

        public async Task<bool> UpdateUser(int id, User userToUpdate)
        {
            //User user =await _userRepository.GetUser(id);
            //if (user==null) return false;
            //if (user.Email != userToUpdate.Email && await _userRepository.IsUserNameExist(userToUpdate.Email))
            //    return false;
            userToUpdate.Id = id;
            await _userRepository.UpdateUser(id,userToUpdate);
            return true;
        }

    }
}
