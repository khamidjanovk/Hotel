using ConsoleTables;
using Hotel.IRepositories;
using Hotel.Models;
using Hotel.Repositories;
using Hotel.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hotel.Pages
{
    internal class ClientsMenu
    {
        private static HomePage _homePage = new HomePage();
        private static IClientRepository repository = new ClientRepository();
        private static IRoomsRepository roomRepository = new RoomsRepository();
        public void Execute()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            ShowClients();
            Console.WriteLine("\n1.Add Client | 2.Update Client | 3.Remove Client | 4.Back");
            Console.ForegroundColor= ConsoleColor.White;
            Console.Write("\n-> ");
            string choose = Console.ReadLine();
            switch (choose)
            {
                case "1":
                    AddClient();
                    break;
                case "2":
                    UpdateClient();
                    break;
                case "3":
                    RemoveClient();
                    break;
                case "4":
                    _homePage.Menu();
                    break;
                default:
                    CatchErrors.InputError();
                    break;

            }
        }
        
        private void ShowClients()
        {
            Console.Clear();
            var clients = repository.GetAll();
            var table = new ConsoleTable("Room №","Room Type", "Firstname", "Lastname", "Country", "Birth Date", "Phone Number");
            foreach (var client in clients)
            {
                table.AddRow(client.RoomNumber,CheckTypeRoom(client.RoomNumber), client.FirstName, client.LastName, client.Country, client.BirthDate, client.PhoneNumber);
            }
            table.Write();
        }
        private void AddClient()
        {
            Console.Clear();
            _homePage.ShowEmptyRooms();
            Console.Write("\nSelect the room(enter 'q' to back): ");
            string tempRoomNumber = Console.ReadLine();
            if(tempRoomNumber == "q") { Execute(); }
            if (!checkIsBusyRoom(tempRoomNumber))
            {
                White();
                Console.Write("\nFirstname: ");
                Green();
                string firstname = Console.ReadLine();
                White();               
                Console.Write("\nLastname: ");
                Green();
                string lastname = Console.ReadLine();
                White();
                Console.Write("\nBirth Date: ");
                Green();
                DateTime birthDate = DateTime.Parse(Console.ReadLine());
                White();
                Console.Write("\nCountry: ");
                Green();
                string country = Console.ReadLine();
                White();
                Console.Write("\nPhone: ");
                Green();
                string phoneNumber = Console.ReadLine();

                repository.Create(
                    new Client
                    {
                        RoomNumber = tempRoomNumber,
                        FirstName = firstname,
                        LastName = lastname,
                        Country = country,
                        BirthDate = birthDate,
                        PhoneNumber = phoneNumber,
                    }
                    );
                ToBusy(tempRoomNumber);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nClient added successfully!");
                White();
                Thread.Sleep(2500);
                _homePage.EndMenu();

            }
            else
            {
                Red();
                if (checkIsRoom(tempRoomNumber))
                {
                    Console.WriteLine("\nThe room you have selected is busy!");
                }
                else
                {
                    CatchErrors.InputError();
                }
                White();
                Thread.Sleep(3000);
                AddClient();
            }
        }
        private void UpdateClient()
        {
            Console.Clear();
            Console.Write("\nThe number of the room you want to change (enter 'q' to back): ");
            Console.Write("\n-> ");
            string tempRoomNumb = Console.ReadLine();
            if (tempRoomNumb == "q") { Execute(); }

            if (checkIsRoom(tempRoomNumb))
            {
                if (checkIsBusyRoom(tempRoomNumb))
                {
                    Console.WriteLine("What do you want to edit?");
                    Green();
                    Console.WriteLine("1.Name\n2.Birth Date\n3.Country\n4.Phone Number\n5.All");
                    Console.Write("\n-> ");
                    string choose = Console.ReadLine();
                    
                    switch (choose)
                    {
                        case "1":
                            White();
                            Console.Write("\nFirstname: ");
                            Green();
                            string firstName = Console.ReadLine();
                            White();
                            Console.Write("\nLastname: ");
                            Green();
                            string lastName = Console.ReadLine();
                            White();
                            repository.Edit(
                                new Client
                                {
                                    RoomNumber = tempRoomNumb,
                                    FirstName = firstName,
                                    LastName = lastName
                                });
                            Green();
                            Console.WriteLine("\nThe change has been successfully completed!");
                            White();
                            Thread.Sleep(1500);
                            _homePage.EndMenu();
                            break;
                        case "2":
                            Console.Write("\nBirth Date: ");
                            DateTime newDate = DateTime.Parse(Console.ReadLine());
                            repository.Edit(
                                new Client
                                {
                                    RoomNumber = tempRoomNumb,
                                    BirthDate = newDate
                                });
                            Green();
                            Console.WriteLine("\nThe change has been successfully completed!");
                            White();
                            Thread.Sleep(1500);
                            _homePage.EndMenu();
                            break;
                        case "3":
                            Console.Write("\nCountry: ");
                            Green();
                            string country = Console.ReadLine();
                            White();
                            repository.Edit(
                                new Client
                                {
                                    RoomNumber = tempRoomNumb,
                                    Country = country
                                });
                            Green();
                            Console.WriteLine("\nThe change has been successfully completed!");
                            White();
                            Thread.Sleep(1500);
                            _homePage.EndMenu();
                            break;
                        case "4":
                            Console.Write("\nPhone Number: ");
                            Green();
                            string phone = Console.ReadLine();
                            White();
                            repository.Edit(
                                new Client
                                {
                                    RoomNumber = tempRoomNumb,
                                    PhoneNumber = phone
                                });
                            Green();
                            Console.WriteLine("\nThe change has been successfully completed!");
                            White();
                            Thread.Sleep(1500);
                            _homePage.EndMenu();
                            break;
                        case "5":
                            White();
                            Console.Write("\nFirstname: ");
                            Green();
                            string _firstName = Console.ReadLine();
                            White();
                            Console.Write("\nLastname: ");
                            Green();
                            string _lastName = Console.ReadLine();
                            White();
                            Console.Write("\nBirth Date: ");
                            Green();
                            DateTime _newDate = DateTime.Parse(Console.ReadLine());
                            White();
                            Console.Write("\nCountry: ");
                            Green();
                            string _country = Console.ReadLine();
                            White();
                            Console.Write("\nPhone Number: ");
                            Green();
                            string _phone = Console.ReadLine();
                            White();

                            repository.Edit(
                                new Client
                                {
                                    RoomNumber = tempRoomNumb,
                                    FirstName = _firstName,
                                    LastName = _lastName,
                                    BirthDate = _newDate,
                                    Country = _country,
                                    PhoneNumber = _phone
                                });
                            Green();
                            Console.WriteLine("\nThe change has been successfully completed!");
                            White();
                            Thread.Sleep(1500);
                            _homePage.EndMenu();
                            break;
                        default:
                            Red();
                            CatchErrors.InputError();
                            White();
                            break;
                    };

                }
                else
                {
                    Red();
                    Console.WriteLine("\nThis room isn't busy!");
                    Thread.Sleep(1500);
                    White();
                    _homePage.EndMenu();
                }

            }
            else
            {
                CatchErrors.InputError();
                Thread.Sleep(1500);
                UpdateClient();
            }

        }
        private void RemoveClient()
        {
            Console.Clear();
            Console.Write("\nThe number of the room you want to remove(enter 'q' to back): ");
            Green();
            string NumbRoomDelete = Console.ReadLine();
            if (NumbRoomDelete == "q") { Execute(); }
            White();
            if (checkIsRoom(NumbRoomDelete))
            {
                if (checkIsBusyRoom(NumbRoomDelete))
                {
                    repository.Delete(NumbRoomDelete);
                    ToEmpty(NumbRoomDelete);
                    Green();
                    Console.WriteLine("\nClient has been successfully deleted!");
                    White();
                    Thread.Sleep(1500);
                    _homePage.EndMenu();

                }
                else
                {
                    Red();
                    Console.WriteLine("\nThis room isn't busy!");
                    Thread.Sleep(1500);
                    White();
                    _homePage.EndMenu();
                }
            }
            else
            {
                CatchErrors.InputError();
                Thread.Sleep(1500);
                RemoveClient();
            }

        }

        private bool checkIsRoom(string roomNumb)
        {
            var roomAll = roomRepository.GetAll();
            return roomAll.Any(x => x.Number == roomNumb);
        }
        private bool checkIsBusyRoom(string roomNumb)
        {
            var roomnumb = roomRepository.GetBusy();

            if(checkIsRoom(roomNumb))
            {
                return roomnumb.Any(x => x.Number == roomNumb);
            }
            else
            {
                return true;
            }

            

        }
        private void ToBusy(string roomNumb)
        {
            var rooms = roomRepository.GetAll();
            foreach(var room in rooms)
            {
                if(room.Number == roomNumb)
                {
                    room.status = Enums.Status.Busy;
                }
            }
            File.WriteAllText(Constants.RoomsDbPath, JsonConvert.SerializeObject(rooms));
        }
        private void ToEmpty(string roomNumb)
        {
            var rooms = roomRepository.GetAll();
            foreach (var room in rooms)
            {
                if (room.Number == roomNumb)
                {
                    room.status = Enums.Status.Empty;
                }
            }
            File.WriteAllText(Constants.RoomsDbPath, JsonConvert.SerializeObject(rooms));
        }
        public string CheckTypeRoom(string numberRoom)
        {
            var rooms = roomRepository.GetAll();
            foreach(var room in rooms)
            {
                if(room.Number == numberRoom)
                {
                    return room.Type.ToString();
                }
            }
            return "";
        }
        
        private void Green()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        private void White()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void Red()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
    }
}
