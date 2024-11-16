using TournaManagementModels;
using TournaManagementServices;
using System;
using System.Collections.Generic;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool active = true;
            UserGetServices userGetServices = new UserGetServices();
            UserTransactionServices userTransactionServices = new UserTransactionServices();

            while (active)
            {
                Console.WriteLine("ENZO's MLBB Tournament Registration");
                Console.WriteLine("What's up?");
                Console.WriteLine("1. Registration");
                Console.WriteLine("2. Unregister");
                Console.WriteLine("3. Joined Players");
                Console.WriteLine("4. Exit");

                Console.WriteLine("Enter the number:");
                string number = Console.ReadLine();

                switch (number)
                {
                    case "1":
                        Console.WriteLine("What is the IGN?");
                        string ign = Console.ReadLine();

                        Console.WriteLine("What is the MLBB ID?");
                        string mlbbid = Console.ReadLine();

                        User newUser = new User { ign = ign, mlbbid = mlbbid, status = "Registered" };
                        userTransactionServices.CreateUser(newUser);
                        Console.WriteLine("Welcome to Land of Dawn!!");
                        break;

                    case "2":
                        Console.WriteLine("Okay, what's the registered IGN?");
                        string unregisterIgn = Console.ReadLine();

                        User userToDelete = new User { ign = unregisterIgn };
                        userTransactionServices.DeleteUser(userToDelete);
                        Console.WriteLine("Okay! Better luck next time!");
                        break;

                    case "3":
                        Console.WriteLine("Okay, here's the details:");
                        DisplayUsers(userGetServices.GetAllUsers());
                        break;

                    case "4":
                        active = false;
                        break;

                    default:
                        Console.WriteLine("ERROR: Invalid input, please try again.");
                        break;
                }
            }
        }

        public static void DisplayUsers(List<User> users)
        {
            foreach (var item in users)
            {
                Console.WriteLine($"IGN: {item.ign}, MLBB ID: {item.mlbbid}, Status: {item.status}");
            }
        }
    }
}
