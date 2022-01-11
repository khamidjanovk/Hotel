using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.IRepositories
{
    internal interface IUserRepository
    {
        void Create(User user);
        User Get(SignIn signIn);
        IList<User> GetAll();
    }
}
