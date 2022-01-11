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
    internal class RoomsRepository : IRoomsRepository
    {
        public IList<Room> GetAll()
        {
            string json = File.ReadAllText(Constants.RoomsDbPath);
            var rooms = JsonConvert.DeserializeObject<IList<Room>>(json);
            return rooms;
        }
        public IList<Room> GetBusy()
        {
            var Busyrooms = GetAll().Where(x => x.status == Enums.Status.Busy).ToList();
            return Busyrooms;
        }
        public IList<Room> GetEmpty()
        {
            var Busyrooms = GetAll().Where(x => x.status == Enums.Status.Empty).ToList();
            return Busyrooms;
        }
    }
}
