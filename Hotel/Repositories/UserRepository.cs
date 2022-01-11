using Hotel.IRepositories;
using Hotel.Models;
using Hotel.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Repositories
{
    internal class UserRepository : IUserRepository
    {
        public void Create(User user)
        {
            string users = File.ReadAllText(Constants.UsersDbPath);

            var usersJson = JsonConvert.DeserializeObject<IList<User>>(users);

            usersJson.Add(user);

            File.WriteAllText(Constants.UsersDbPath, JsonConvert.SerializeObject(usersJson));
        }

        public User Get(SignIn signIn)
        {
            string users = File.ReadAllText(Constants.UsersDbPath);

            var usersJson = JsonConvert.DeserializeObject<IList<User>>(users);

            return usersJson.FirstOrDefault(x => x.Username == signIn.Username && x.Password == signIn.Password);
        }

        public IList<User> GetAll()
        {
            string users = File.ReadAllText(Constants.UsersDbPath);

            return JsonConvert.DeserializeObject<IList<User>>(users);
        }
    }
}
