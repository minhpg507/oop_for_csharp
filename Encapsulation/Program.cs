using SecureBankApp;

class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount("John Doe", 500.00m, "1234");
        Console.WriteLine($"Account Holder: {account.AccountHolder}");

        Console.WriteLine("\n--- 1. Testing Deposit ---");
        account.Deposit(-50m); 
        account.Deposit(200m); 

        Console.WriteLine("\n--- 2. Testing Protected Balance View ---");
        account.GetBalance("9999"); 
        decimal currentBalance = account.GetBalance("1234"); 

        if (currentBalance != -1m)
        {
            Console.WriteLine($"Verified Balance: {currentBalance:C}");
        }

        Console.WriteLine("\n--- 3. Testing Lockout Mechanism ---");
        account.Withdraw(100m, "0000"); 
        account.Withdraw(100m, "1111"); 
        account.Withdraw(100m, "2222"); 

        account.Withdraw(100m, "1234"); 

        Console.WriteLine("\n--- 4. Account Lock Status ---");
        Console.WriteLine($"Is account locked? {account.IsLocked}");
    }
}