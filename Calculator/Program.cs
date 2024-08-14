using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCodeYou
{
    class Program
    {
        static void Main(string[] args)
        {

            var calculator = new Calculator();
            var history = new List<dynamic>();

            var input = string.Empty;
            bool shouldQuit = false;
            var result = string.Empty;

            ManualResetEvent quitEvent = new ManualResetEvent(false);
            Thread countdownThread = null;

            do
            {
                Console.WriteLine("Choose an operation:");
                Console.WriteLine("1: Add");
                Console.WriteLine("2: Subtract");
                Console.WriteLine("3: Multiply");
                Console.WriteLine("4: Divide");
                Console.WriteLine("5: History");
                Console.WriteLine("q: Quit");

                input = Console.ReadLine();

                int numOne = 0;
                int numTwo = 0;

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        numOne = Utils.GetValidInteger("add: ");
                        numTwo = Utils.GetValidInteger("add: ");
                        result = $"{numOne} + {numTwo} = {calculator.Add(numOne, numTwo)}";
                        Console.WriteLine(result);
                        history.Add(result);
                        break;

                    case "2":
                        Console.Clear();
                        numOne = Utils.GetValidInteger("subtract: ");
                        numTwo = Utils.GetValidInteger("subtract: ");
                        result = $"{numOne} - {numTwo} = {calculator.Subtract(numOne, numTwo)}";
                        Console.WriteLine(result);
                        history.Add(result);
                        break;

                    case "3":
                        Console.Clear();
                        numOne = Utils.GetValidInteger("multiply: ");
                        numTwo = Utils.GetValidInteger("multiply: ");
                        result = $"{numOne} * {numTwo} = {calculator.Multiply(numOne, numTwo)}";
                        Console.WriteLine(result);
                        history.Add(result);
                        break;

                    case "4":
                        Console.Clear();
                        numOne = Utils.GetValidInteger("numerator: ");
                        numTwo = Utils.GetValidInteger("denominator: ",true);
                        result = $"{numOne} / {numTwo} = {calculator.Divide(numOne, numTwo)}";
                        Console.WriteLine(result);
                        history.Add(result);
                        break;

                    case "5":
                        Console.Clear();
                        Console.WriteLine("History");
                        for (int i = 0; i < history.Count; i++)
                        {
                            Console.WriteLine($"{i+1}. {history[i]}");
                        }
                        Console.WriteLine("");
                        break;

                    case "q":
                        if (countdownThread != null && countdownThread.IsAlive)
                        {
                            countdownThread.Join();
                        }
                        countdownThread = new Thread(() =>
                        {
                            for (int i = 10; i > 0; i--)
                            {
                                Console.Clear();
                                Console.WriteLine($"The application will close in {i} seconds...");
                                Thread.Sleep(1000); 
                            }

                            Console.Clear();
                            Console.WriteLine("Time's up! Closing the application...");
                            Thread.Sleep(1000);
                            Environment.Exit(0);
                        });

                        countdownThread.Start();
                        break;
                    default:
                        Console.WriteLine("Unknown input. Please try again.");
                        break;
                }
            }
            while (!shouldQuit);
        }
    }
}