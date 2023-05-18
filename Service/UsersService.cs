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
      
        public async Task<User> SignIn(User user)=>await _userRepository.FindUser(user);


        public async Task<User> SignUp(User newUser)
        {
            if (_passwordStrengthService.passwordScore(newUser.Password) < 2)
                return null;
            //if (await _userRepository.IsUserNameExist(newUser.Email))
            //    return null;                
            return await _userRepository.AddUser(newUser);

        }

        public async Task<bool> UpdateUser(int id, User userToUpdate)
        {
            if (_passwordStrengthService.passwordScore(userToUpdate.Password) >= 2)
                return false;
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
