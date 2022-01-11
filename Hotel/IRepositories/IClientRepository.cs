using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.IRepositories
{
    internal interface IClientRepository
    {
        void Create(Client client);
        IList<Client> GetAll();
        IList<Client> Get(string text);

        void Edit(Client client);
        void Delete(string text);
    }
}
