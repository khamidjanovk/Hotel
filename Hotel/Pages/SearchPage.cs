using ConsoleTables;
using Hotel.IRepositories;
using Hotel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Pages
{
    internal class SearchPage
    {
        private static IClientRepository clientRepo = new ClientRepository();
        private ClientsMenu _clientsMenu = new ClientsMenu();
        private static HomePage _homePage = new HomePage();
        public void Execute()
        {
            Console.Clear();
            Console.Write("Enter to search(enter 'q' to exit): ");
            Console.ForegroundColor = ConsoleColor.Green;
            string searchItem = Console.ReadLine();
            if (searchItem == "q") { _homePage.Menu(); }
            Console.ForegroundColor = ConsoleColor.White;
            var searchResult = clientRepo.Get(searchItem);
       
            var table = new ConsoleTable("Room №", "Room Type", "Firstname", "Lastname", "Country", "Birth Date", "Phone Number");
            foreach (var client in searchResult)
            {
                    table.AddRow(client.RoomNumber, _clientsMenu.CheckTypeRoom(client.RoomNumber), client.FirstName, client.LastName, client.Country, client.BirthDate, client.PhoneNumber);
            }
            //Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            if (searchResult.Count == 0 || searchItem.Length == 0)
            {
                Console.WriteLine("\nNo Results Found.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                table.Write();
            }
            Console.ForegroundColor = ConsoleColor.White;
            _homePage.EndMenu();
            
        }

    }
}
