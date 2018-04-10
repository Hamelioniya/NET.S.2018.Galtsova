using System;
using Timer;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock(5);
            Handler handler = new Handler();

            clock.TimeElapsed += handler.Message;

            clock.Start();

            Console.ReadKey();
        }
    }
}
