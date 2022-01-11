using ConsoleTables;
using Hotel.IRepositories;
using Hotel.Repositories;
using Hotel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hotel.Pages
{
    internal class HomePage
    {
        private IRoomsRepository roomRepo = new RoomsRepository();
        private ClientsMenu clientsMenu = new ClientsMenu();
        private SearchPage searchPage = new SearchPage();
        private LoginPage loginPage = new LoginPage();
        public void Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1.Rooms | 2.Client | 3.Search | 4.Log out | 5.Exit");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n-> ");
            string choose = Console.ReadLine();

            switch (choose)
            {
                case "1":
                    RoomsMenu();
                    break;
                case "2":
                    clientsMenu.Execute();
                    break;
                case "3":
                    searchPage.Execute();
                    break;
                case "4":
                    loginPage.Menu();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    CatchErrors.InputError();
                    Thread.Sleep(1000);
                    Menu();
                    break;
            }
        }

        private void RoomsMenu()
        {
            Console.Clear();
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("1.Show Empty Rooms\n2.Show Busy Rooms\n3.Back");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n-> ");
            string choose = Console.ReadLine();
            switch (choose)
            {
                case "1":
                    ShowEmptyRooms();
                    EndMenu("room");
                    break;
                case "2":
                    ShowBusyRooms();
                    break;
                case "3":
                    Menu();
                    break;
                default:
                    CatchErrors.InputError();
                    break;
            }
        }
        public void ShowEmptyRooms()
        {
            Console.Clear();
            var emptyRooms = roomRepo.GetEmpty();
            ConsoleTable Table = new ConsoleTable("№","Type");
            Console.ForegroundColor= ConsoleColor.Green;
            foreach (var room in emptyRooms)
            {
                Table.AddRow(room.Number, room.Type);
            }
            Table.Write();
            Console.ForegroundColor = ConsoleColor.White;
            //EndMenu();

        }
        private void ShowBusyRooms()
        {
            Console.Clear();
            var emptyRooms = roomRepo.GetBusy();
            ConsoleTable Table = new ConsoleTable("№", "Type");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var room in emptyRooms)
            {
                Table.AddRow(room.Number, room.Type);
            }
            Table.Write();
            Console.ForegroundColor = ConsoleColor.White;
            EndMenu("room");
        }
        private void ShowClients()
        {

        }
        public void EndMenu()
        {
            Console.WriteLine("\n1.Main Menu | 2.Exit");
            Console.Write("\n-> ");
            string choose = Console.ReadLine();
            switch (choose)
            {
                case "1":
                    Menu();
                    break;
                case "2":
                    Environment.Exit(0);
                    break;
               default:
                    CatchErrors.InputError();
                    EndMenu();
                    break;
            }
        }
        public void EndMenu(string text)
        {
            Console.WriteLine("\n1.Main Menu | 2.Back | 3.Exit");
            Console.Write("\n-> ");
            string choose = Console.ReadLine();
            switch (choose)
            {
                case "1":
                    Menu();
                    break;
                
                case "2":
                    RoomsMenu();
                    break;
                
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    CatchErrors.InputError();
                    EndMenu();
                    break;
            }
        }
    }
}
