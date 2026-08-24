using System;
using System.Linq; 

namespace SecureBankApp
{
    public class BankAccount
    {
        // TODO 1: Declare private fields (_balance, _pin, _failedAttempts)
        private decimal _balance;
        private string _pin;
        private int _failedAttempts;

        // TODO 2: Declare public AccountHolder property (read-only)
        public string AccountHolder { get; }

        // TODO 3: Declare IsLocked property with a private setter
        public bool IsLocked { get; private set; }

        // Constructor
        public BankAccount(string accountHolder, decimal initialBalance, string initialPin)
        {
            AccountHolder = accountHolder;
            _balance = initialBalance > 0 ? initialBalance : 0;
            _pin = initialPin;
            _failedAttempts = 0;
            IsLocked = false;
        }

        // TODO 4: Implement Deposit method
        public bool Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Error: Deposit amount must be positive.");
                return false;
            }

            _balance += amount;
            Console.WriteLine($"Successfully deposited {amount:C}.");
            return true;
        }

        // TODO 5: Implement Withdraw method
        public bool Withdraw(decimal amount, string inputPin)
        {
            if (IsLocked)
            {
                Console.WriteLine("Error: Account is locked due to multiple failed PIN attempts.");
                return false;
            }

            if (inputPin != _pin)
            {
                _failedAttempts++;
                if (_failedAttempts >= 3)
                {
                    IsLocked = true;
                    Console.WriteLine("Error: Invalid PIN code. Account has been LOCKED for security!");
                }
                else
                {
                    Console.WriteLine($"Error: Invalid PIN code. (Attempt {_failedAttempts}/3)");
                }
                return false;
            }

            _failedAttempts = 0;

            if (amount <= 0)
            {
                Console.WriteLine("Error: Withdrawal amount must be positive.");
                return false;
            }

            if (_balance < amount)
            {
                Console.WriteLine("Error: Insufficient funds.");
                return false;
            }

            _balance -= amount;
            Console.WriteLine($"Successfully withdrew {amount:C}.");
            return true;
        }

        // TODO 6: Implement GetBalance method (PIN required)
        public decimal GetBalance(string inputPin)
        {
            if (inputPin != _pin)
            {
                Console.WriteLine("Error: Invalid PIN code.");
                return -1m;
            }
            return _balance;
        }

        // TODO 7: Implement ChangePin method
        public bool ChangePin(string currentPin, string newPin)
        {
            if (currentPin != _pin)
            {
                Console.WriteLine("Error: Invalid current PIN code.");
                return false;
            }

            if (string.IsNullOrEmpty(newPin) || newPin.Length != 4 || !newPin.All(char.IsDigit))
            {
                Console.WriteLine("Error: New PIN must be exactly 4 digits and contain only numbers.");
                return false;
            }

            _pin = newPin;
            Console.WriteLine("Successfully changed PIN.");
            return true;
        }
    }
}