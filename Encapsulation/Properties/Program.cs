using System;

namespace OOP_UserAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            UserAccount acc = new UserAccount
            {
                AccountId = "ACC-999888"
            };

            acc.Username = "MinhNguyen";
            acc.Password = "mySecretPass123";

            Console.WriteLine("--- Test Balance ---");
            acc.Balance = -500;
            Console.WriteLine($"Current Balance: ${acc.Balance}");

            acc.Balance = 15000;
            Console.WriteLine($"New Balance: ${acc.Balance}");

            Console.WriteLine("\n--- Test IsVIP ---");
            Console.WriteLine($"Is account VIP? {acc.IsVIP}");

            Console.WriteLine("\n--- Test Read-Only Data ---");
            Console.WriteLine($"Account ID: {acc.AccountId}");
            Console.WriteLine($"Created Date: {acc.CreatedDate}");

            Console.ReadLine();
        }
    }
}