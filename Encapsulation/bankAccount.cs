using System;

public class BankAccount
{
    private decimal _balance;
    private string _pin;
    private int _failedAttempts;

    public string AccountHolder { get; }

    public bool IsLocked { get; private set; }

    public BankAccount(string accountHolder, string initialPin, decimal initialBalance = 0)
    {
        AccountHolder = accountHolder;
        _pin = initialPin;
        _balance = initialBalance;
        _failedAttempts = 0;
        IsLocked = false;
    }


    public bool Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Lỗi: Số tiền nạp phải lớn hơn 0.");
            return false;
        }

        _balance += amount;
        Console.WriteLine($"Thành công: Đã nạp {amount:C}. Số dư hiện tại đang được ẩn.");
        return true;
    }

    public bool Withdraw(decimal amount, string inputPin)
    {
        if (IsLocked)
        {
            Console.WriteLine("Lỗi: Tài khoản đã bị khóa do nhập sai PIN quá nhiều lần.");
            return false;
        }

        if (inputPin != _pin)
        {
            _failedAttempts++;
            Console.WriteLine($"Lỗi: Sai mã PIN. Số lần nhập sai: {_failedAttempts}/3.");

            if (_failedAttempts >= 3)
            {
                IsLocked = true;
                Console.WriteLine("CẢNH BÁO: Tài khoản của bạn đã bị khóa!");
            }
            return false;
        }

        _failedAttempts = 0;

        if (amount <= 0 || _balance < amount)
        {
            Console.WriteLine("Lỗi: Số tiền rút không hợp lệ hoặc số dư không đủ.");
            return false;
        }

        _balance -= amount;
        Console.WriteLine($"Thành công: Đã rút {amount:C}.");
        return true;
    }

    public decimal GetBalance(string inputPin)
    {
        if (inputPin != _pin)
        {
            Console.WriteLine("Lỗi truy cập: Sai mã PIN. Không thể xem số dư.");
            return -1m; 
        }

        return _balance;
    }

    public void ChangePin(string currentPin, string newPin)
    {
        if (currentPin != _pin)
        {
            Console.WriteLine("Lỗi: Mã PIN hiện tại không đúng.");
            return;
        }

        if (!string.IsNullOrEmpty(newPin) && newPin.Length == 4 && int.TryParse(newPin, out _))
        {
            _pin = newPin;
            Console.WriteLine("Thành công: Đã đổi mã PIN mới.");
        }
        else
        {
            Console.WriteLine("Lỗi: Mã PIN mới phải bao gồm đúng 4 chữ số.");
        }
    }
}