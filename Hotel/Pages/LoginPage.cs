using Hotel.Extensions;
using Hotel.IRepositories;
using Hotel.Models;
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
    internal class LoginPage
    {
        private IUserRepository userrepo = new UserRepository();
        public string keyToReg = "23r45t67y";
        private static HomePage _HomePage = new HomePage();
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("1.Sign in | 2.Sign up | 3.Exit");
            string choose = Console.ReadLine();

            switch (choose)
            {
                case "1":
                    SignIn();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Enter the secret key(enter 'q' to back): ");
                    string secretKey = MethodServices.HidePassword();
                    if (secretKey == "q") { Menu(); }
                    if (secretKey == keyToReg)
                    {
                        SignUp();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nSecret key invalid!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(1200);
                        Menu();
                    }
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    CatchErrors.InputError();
                    Menu();
                    break;
            }
        }
        private void SignIn()
        {
            Console.Clear();
            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = MethodServices.HashPassword(MethodServices.HidePassword());

            SignIn signIn = new SignIn { Username = username, Password = password };

            User user = userrepo.Get(signIn);

            if (user is not null)
            {
                Console.Title = $"Administrator: {user.Username}";
                _HomePage.Menu();
            }
            else
            {
                CatchErrors.ConfirmError();
                SignIn();
            }

        }
        private bool UserCheckBusy(string username)
        {
            var users = userrepo.GetAll();

            return users.Any(x => x.Username == username);
        }
        private void SignUp()
        {
            Console.Clear();

            Console.Write("Full Name: ");
            string fullName = Console.ReadLine().Capitalize();

            Console.Write("Username: ");
            string username = Console.ReadLine();
            if (!UserCheckBusy(username))
            {
                Console.Write("Password: ");
                string password = MethodServices.HidePassword();
                password = MethodServices.HashPassword(password);
                Console.Write("\nE-Mail: ");
                string eMail = Console.ReadLine();
                Console.Write("Birth Date( / or . ): ");
                DateTime dateTime = DateTime.Parse(Console.ReadLine());
                userrepo.Create(
                    new User
                    {
                        FullName = fullName,
                        Username = username,
                        Password = password,
                        Email = eMail,
                        BirthDate = dateTime,
                    }) ;

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nWelcome to our team, New Administrator!");
                Console.ForegroundColor= ConsoleColor.White;

                Console.WriteLine("\n1.Main Menu\t|\t2.Exit ");
                Console.Write("\n> ");
                string choose = Console.ReadLine();

                if (choose == "1")
                {
                    Console.Clear();
                    Menu();
                }
                else if (choose == "2")
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Username is busy!");
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("\nWould you like to try again? [y,n]: ");
                string choose = Console.ReadLine();
                if(choose == "y" || choose == "Y")
                {
                    SignUp();
                }
                else
                {
                    Menu();
                }
            }
        }
    }
}
