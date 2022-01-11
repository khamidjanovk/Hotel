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
    internal class ClientRepository : IClientRepository
    {
        public void Create(Client client)
        {
            var clients = GetAll();
            clients.Add(client);

            File.WriteAllText(Constants.ClientsDbPath, JsonConvert.SerializeObject(clients));
        }
        public void Delete(string text)
        {
            var clients = GetAll();
            clients.Remove(clients.Where(x => x.RoomNumber == text).FirstOrDefault());

            File.WriteAllText(Constants.ClientsDbPath, JsonConvert.SerializeObject(clients));
        }
        public void Edit(Client client)
        {
            var clients = GetAll();
            for(int i = 0; i < clients.Count; i++)
            {
                if(clients[i].RoomNumber == client.RoomNumber)
                {
                    if (client.FirstName is not null) { clients[i].FirstName = client.FirstName; }
                    if (client.LastName is not null) { clients[i].LastName = client.LastName; }
                    if (client.Country is not null) { clients[i].Country = client.Country; }
                    if (client.BirthDate > DateTime.Parse("01.01.0001")) { clients[i].BirthDate = client.BirthDate; }
                    if (client.PhoneNumber is not null) { clients[i].PhoneNumber = client.PhoneNumber; }
                }
            }
            File.WriteAllText(Constants.ClientsDbPath, JsonConvert.SerializeObject(clients));

        }

        public IList<Client> Get(string text)
        {
            var clients = GetAll().Where(p => p.FirstName.ToLower().Contains(text.ToLower()) || 
                                              p.LastName.ToLower().Contains(text.ToLower()) ||
                                              p.Country.ToLower().Contains(text.ToLower()) ||
                                              p.RoomNumber.Contains(text));

            return clients.ToList();  
        }
        public IList<Client> GetAll()
        {
            string clients = File.ReadAllText(Constants.ClientsDbPath);

            return JsonConvert.DeserializeObject<IList<Client>>(clients);
        }
    }
}
