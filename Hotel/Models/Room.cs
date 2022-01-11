using Hotel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    internal class Room
    {
        public string Number { get; set; }
        public RoomType Type { get; set; }
        public Status status { get; set; }
    }
}
