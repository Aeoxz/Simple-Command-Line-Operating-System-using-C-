using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace OS1
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Console.WriteLine("   _   _                                           \r\n  / _ \\ / |                                          \r\n | |  | | (                                            \r\n | |  1 |\\_ \\                                           \r\n | || |) |                                          \r\n  \\/|/      _  _  _ _   _  _  _  _ \r\n | |/ /  | |    / _ \\|  \\/  |  _ \\ / _ \\| |/ / /B |\r\n | ' /| |  | |   | |  | | \\  / | |_  | |  | | ' /   | |\r\n |  < |  | | |   | |  | | |\\/| |  _/| |  | |  <    | |\r\n | . \\| || || || | |  | | |    | || | . \\   | |\r\n ||\\\\_|\\/||  |||     \\/||\\\\  ||\r\n                                                          ");
            Console.WriteLine("=====WELCOME USER OS TB1 KL5 BUILD V.1=====");
            Console.WriteLine("============OS BUILDERS====================");
            Console.WriteLine(" Reyhan Baskara Pramatya (41522010183)");
            Console.WriteLine(" Fawwaz Sholehuddin (41522010239)");
            Console.WriteLine(" Azka Faiq (41522010212)");
            Console.WriteLine(" Elga Prasetya (41522010198)");
            Console.WriteLine(" Muhammad Daffa (41522010246)");
        }

        protected override void Run()
        {
            Console.WriteLine("Available options:");
            Console.WriteLine("------------------");
            Console.WriteLine("shutdown");
            Console.WriteLine("------------------");
            Console.WriteLine("time");
            Console.WriteLine("------------------");
            Console.WriteLine("date");
            Console.WriteLine("------------------");
            Console.WriteLine("calculator");
            Console.WriteLine("------------------");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "shutdown":
                    Shutdown();
                    break;
                case "time":
                    DisplayTime();
                    break;
                case "date": // Tambahkan case untuk "date"
                    DisplayDate();
                    break;
                case "calculator":
                    OpenCalculator();
                    break;
                default:
                    Console.WriteLine("ERROR OPTIONS DOES NOT EXIST");
                    Console.WriteLine("PLS TRY NEW COMMAND ");
                    Console.WriteLine("OR TRY TO REWRITE COMMAND ");
                    Console.WriteLine("COMMANDS ARE CASE SENSITIVE !!! ");
                    break;
            }
        }

        private void DisplayTime()
        {
            Console.WriteLine($"Current time: {DateTime.Now.ToLongTimeString()}");
        }

        private void DisplayDate() // Tambahkan metode untuk menampilkan tanggal
        {
            Console.WriteLine($"Current date: {DateTime.Now.ToLongDateString()}");
        }

        private void OpenCalculator()
        {
            Console.WriteLine("Calculator is now open.");
            Console.WriteLine("Enter 'exit' to return to the main menu.");
            Console.WriteLine("this calculator can only add subtract divide and multiply");
            Console.WriteLine("CONTOH");
            Console.WriteLine("2 + 2 (PENAMBAHAN)");
            Console.WriteLine("2 * 2 (PERKALIAN)");
            Console.WriteLine("2 - 2 (PENGURANGAN)");
            Console.WriteLine("2 / 2 (PEMBAGIAN)");
            Console.WriteLine("Insert Input ");

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("Exiting Calculator...");
                    break;
                }

                try
                {
                    int result = CalculateExpression(input);
                    Console.WriteLine($"Result: {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private int CalculateExpression(string expression)
        {
            string[] parts = expression.Split(' ');
            if (parts.Length != 3)
            {
                throw new ArgumentException("Invalid expression format. Example: 2 + 2");
            }

            int operand1 = int.Parse(parts[0]);
            int operand2 = int.Parse(parts[2]);
            string operation = parts[1];

            switch (operation)
            {
                case "+":
                    return operand1 + operand2;
                case "-":
                    return operand1 - operand2;
                case "*":
                    return operand1 * operand2;
                case "/":
                    if (operand2 != 0)
                    {
                        return operand1 / operand2;
                    }
                    else
                    {
                        throw new DivideByZeroException("Division by zero is not allowed.");
                    }
                default:
                    throw new ArgumentException("Invalid operation. Supported operations: +, -, *, /");
            }
        }

        private void Halt()
        {
            Console.WriteLine("Exiting the OS...");
            Sys.Power.Shutdown();
        }

        private void Shutdown()
        {
            Console.WriteLine("Shutting down...");
            Sys.Power.Shutdown();
        }
    }
}