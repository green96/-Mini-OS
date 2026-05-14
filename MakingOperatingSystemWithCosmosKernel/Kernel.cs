using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace MakingOperatingSystemWithCosmosKernel
{
    public class Kernel : Sys.Kernel
    {

        protected override void BeforeRun()
        {
            Console.Clear();
            Console.WriteLine("Cosmos booted successfully. Welcome to Nhan OS");
        }

        protected override void Run()
        {
            Console.Write("Input: ");

            // Thay thế Console.ReadLine() bằng vòng lặp đọc phím thủ công để tránh liệt phím trên máy thật
            string input = "";
            while (true)
            {
                // Kiểm tra liên tục xem có phím nào được nhấn hay không
                if (System.Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);

                    // Nếu người dùng bấm ENTER -> kết thúc việc nhập dòng lệnh
                    if (key.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine();
                        break;
                    }
                    // Nếu người dùng bấm nút xóa (Backspace)
                    else if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        input = input.Substring(0, input.Length - 1);
                        Console.Write("\b \b"); // Xóa ký tự vừa gõ trên màn hình
                    }
                    // Nhận các ký tự chữ, số và dấu cách thông thường
                    else if (key.KeyChar != '\u0000')
                    {
                        input += key.KeyChar;
                        Console.Write(key.KeyChar); // Hiển thị ký tự ra màn hình
                    }
                }
            }

            // Chuyển chữ nhập vào thành chữ thường để tránh lỗi khi người dùng bật CapsLock
            input = input.Trim().ToLower();

            // Giữ nguyên toàn bộ các tính năng và văn bản của Nhan OS
            if (input == "about")
            {
                Console.WriteLine("Author: Nhan OS is an operating system made by Nhan using Cosmos Kernel.");
                Console.WriteLine("Cosmos: Cosmos (C# Open Source Managed Operating System) is an operating system development kit which uses Visual Studio as its development environment. Despite C# in the name any .NET based language can be used including VB.NET, Fortran, Delphi Prism, IronPython, F# and more. Cosmos itself and the kernel routines are primarily written in C#, and thus the Cosmos name.");
            }
            else if (input == "hi")
            {
                Console.WriteLine("Hello there! Welcome to Nhan OS. Type 'about' to know more about this operating system, Shutdown to Shutdown, Reboot to Reboot");
            }
            else if (input == "shutdown")
            {
                Sys.Power.Shutdown();
            }
            else if (input == "reboot")
            {
                Sys.Power.Reboot();
            }
            else
            {
                Console.WriteLine("Unknown command. Please try again");
            }
        }
    }
}
