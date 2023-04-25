using entities;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepositorySql : IUsersRepository
    {
        MyShop213354335Context _MyShopContext;

        public UserRepositorySql(MyShop213354335Context myShopContext)
        {
            _MyShopContext = myShopContext;
        }

        public async Task<User> AddUser(User newUser)
        {
            await _MyShopContext.Users.AddAsync(newUser);
            await _MyShopContext.SaveChangesAsync();
            return newUser;
        }

        public async Task<User> FindUser(User userToFind)
        {
            return await _MyShopContext.Users.FirstOrDefaultAsync(user => user.Email == userToFind.Email && user.Password == userToFind.Password);
        }

        public async Task<User> GetUser(int id)
        {
            return await _MyShopContext.Users.FindAsync(id);
        }

        public async Task<bool> IsUserNameExist(string Email)
        {
            User user = await _MyShopContext.Users.FirstOrDefaultAsync(u => u.Email == Email);
            if (user == null)
                return false;
            return true;

        }

        public async Task UpdateUser(int id, User userToUpdate)
        {
            _MyShopContext.Users.Update(userToUpdate);
            await _MyShopContext.SaveChangesAsync();

        }
    }
}
