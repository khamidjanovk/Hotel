using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.IRepositories
{
    internal interface IRoomsRepository
    {
        IList<Room> GetAll();
        IList<Room> GetBusy();
        IList<Room> GetEmpty();
    }
}
