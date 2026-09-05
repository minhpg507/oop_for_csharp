using System;
using GameXucXac;
namespace GameXucXac
{
    internal class XucXac
    {
        public static void Main(string[] args)
        {
            Game();
        }
        static void Game()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; 
            int budget = 1000000; // số tiền vốn
            int budgetbet = 0; // số tiền cược
            int count = 0; // số lần chơi
            int countcorrect = 0; // số lần đoán đúng
            int countwrong = 0; // số lần đoán sai

            PairOfDice pod = new PairOfDice();

            Console.WriteLine("=== Chào mừng bạn đến với trò chơi Xúc Xắc! ===");
            Console.WriteLine("--- Bạn có 1.000.000 đồng để bắt đầu chơi. ---");

            bool isPlaying = true;

            while (isPlaying && budget > 0)
            {
                Console.Write($"\nNhập số tiền bạn muốn đặt cược: ");
                if (!int.TryParse(Console.ReadLine(), out budgetbet) || budgetbet <= 0 || budgetbet > budget)
                {
                    Console.WriteLine("Số tiền cược không hợp lệ (phải lớn hơn 0 và nhỏ hơn số dư). Vui lòng thử lại.");
                    continue;
                }
                // 2. Bắt đầu đổ xúc xắc 
                Console.WriteLine($"\nĐã nhận cược {budgetbet} VNĐ. Đang đổ xúc xắc...");
                pod.Roll(); 
                int tong = pod.GetTotal();

                

                Console.Write("Bạn đoán tổng 2 xúc xắc là Chẵn (C) hay Lẻ (L)? Nhập C hoặc L: ");
                string? guess = Console.ReadLine()?.ToUpper();

                // In kết quả xúc xắc ra màn hình
                Console.WriteLine($"Kết quả xúc xắc: {pod.Die1.FaceValue} và {pod.Die2.FaceValue} (Tổng: {tong})");


                // 3. Kiểm tra kết quả
                bool isCorrect = (guess == "C" && tong % 2 == 0) || (guess == "L" && tong % 2 != 0);
                count++;
                if (isCorrect)
                {
                    Console.WriteLine("Chúc mừng! Bạn đã đoán đúng.");
                    budget += budgetbet ; // Thắng số tiền cược
                    countcorrect++;
                }
                else
                {
                    Console.WriteLine("Rất tiếc! Bạn đã đoán sai.");
                    budget -= budgetbet; // Thua mất số tiền cược
                    countwrong++;
                }
                if (budget <= 0)
                {
                    Console.WriteLine("Bạn đã hết tiền. Trò chơi kết thúc.");
                    return; // Kết thúc trò chơi nếu hết tiền
                }

                // 4. Lệnh hỏi người chơi
                Console.Write($"\nSố tiền còn lại của bạn là: {budget} VND. Bạn có muốn tiếp tục chơi không? (y/n): ");
                string? continuePlaying = Console.ReadLine();
                if (continuePlaying?.ToLower() == "y")
                {
                    Console.WriteLine("Bạn đã chọn tiếp tục chơi.");
                    // Tiếp tục trò chơi
                }
                else if (continuePlaying?.ToLower() == "n")
                {
                    Console.WriteLine("Bạn đã chọn dừng chơi. Cảm ơn bạn đã tham gia!");
                    isPlaying = false;
                }
                else
                {
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập 'y' hoặc 'n'.");
                    // Xử lý lựa chọn không hợp lệ)
                }
            }
            // 5. Hiển thị kết quả cuối cùng
            Console.WriteLine("=== Kết quả cuối cùng ===");
            Console.WriteLine($"Số lần chơi: {count}");
            Console.WriteLine($"Số lần đoán đúng: {countcorrect}");
            Console.WriteLine($"Số lần đoán sai: {countwrong}");
            Console.WriteLine($"Tiền còn lại: {budget}");
            Console.WriteLine("=== Cảm ơn bạn đã tham gia trò chơi! ===");
        }
    }
}