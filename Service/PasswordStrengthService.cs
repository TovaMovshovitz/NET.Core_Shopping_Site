using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PasswordStrengthService : IPasswordStrengthService
    {

        public int passwordScore(string password)
        {
            if(password.Length>0)
                return Zxcvbn.Core.EvaluatePassword(password).Score;
            return 0;
        }
    }
}
