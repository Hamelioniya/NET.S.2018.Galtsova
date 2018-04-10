using System;
using Timer;

namespace ConsoleUI
{
    public class Handler
    {
        public void Message(object sender, ClockEventArgs e)
        {
            Console.WriteLine("Time is over!\nDate: {0}\nNumber of milliseconds: {1}", e.Date, e.IntervalInMilliseconds);
        }
    }
}
