using System;
using System.Threading;

namespace Binance
{
    class Program : Variables
    {
        static void Main(string[] args)
        {/*
            if (Variables.apiKey == "" || Variables.apiSecret == "")
            {
                Console.Write("API Key : ");
                Variables.apiKey = Console.ReadLine();
                Console.Write("API Secret : ");
                Variables.apiSecret = Console.ReadLine();
                Request.Account_Info("GET");
            }*/
        x:
            Console.WriteLine("'R' to send request\n'C' to clear\n'X' to delete an order\n'A' for account info\n'O' for open orders\nAnother to exit");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.R:
                    Console.WriteLine("\nRequest has been sent");
                    Console.Write("\nSymbol : ");
                    string symbol = Console.ReadLine().ToUpper();
                    Console.Write("Side : ");
                    string side = Console.ReadLine().ToUpper();
                    Console.Write("Type : ");
                    string type = Console.ReadLine().ToUpper();
                    Console.Write("Quantity : ");
                    string quantity = Console.ReadLine().ToUpper();
                    Console.Write("Price : ");
                    string price = Console.ReadLine().ToUpper();
                    Request.New_Order(symbol, side, type, quantity, price, "POST");
                    goto x;
                case ConsoleKey.C:
                    Console.Clear();
                    goto x;
                case ConsoleKey.X:
                    Console.Write("\nSymbol : ");
                    string a = Console.ReadLine().ToUpper();
                    Console.Write("Order Id : ");
                    string b = Console.ReadLine();
                    Request.Delete_Order(a, b, "DELETE");
                    goto x;
                case ConsoleKey.A:
                    Request.Account_Info("GET");
                    goto x;
                case ConsoleKey.O:
                    Request.Open_Orders("GET");
                    goto x;
                default:
                    break;
            }
            Console.WriteLine("\nProgram closing...");
            Thread.Sleep(1000);
        }
    }
}
