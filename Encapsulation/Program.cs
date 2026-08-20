using System;

namespace OOP_Encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount myAccount = new BankAccount("Minh Nguyen", "1234", 500m);

            Console.WriteLine($"Chủ tài khoản: {myAccount.AccountHolder}\n");

            myAccount.Deposit(200m);

            Console.WriteLine("\n--- YÊU CẦU XEM SỐ DƯ ---");
            myAccount.GetBalance("9999");
            decimal currentBalance = myAccount.GetBalance("1234");
            if (currentBalance != -1m)
            {
                Console.WriteLine($"Số dư tài khoản: {currentBalance:C}");
            }

            Console.WriteLine("\n--- YÊU CẦU ĐỔI PIN ---");
            myAccount.ChangePin("1234", "abcd"); 
            myAccount.ChangePin("1234", "5678"); 

            Console.WriteLine("\n--- YÊU CẦU RÚT TIỀN ---");
            myAccount.Withdraw(100m, "1111"); 
            myAccount.Withdraw(100m, "2222"); 
            myAccount.Withdraw(100m, "3333"); 

            myAccount.Withdraw(100m, "5678"); 

            Console.ReadLine();
        }
    }
}