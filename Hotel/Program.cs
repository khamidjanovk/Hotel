using ConsoleTables;
using Hotel.IRepositories;
using Hotel.Models;
using Hotel.Pages;
using Hotel.Repositories;
using Hotel.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Hotel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoginPage login = new LoginPage();
            login.Menu();
        }
    }
}
