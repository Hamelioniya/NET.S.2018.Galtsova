using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Galtsova.AntiSOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            CoffeeMaker coffeMaker = new CoffeeMaker();
            coffeMaker.On();
            coffeMaker.AddBeans(100, 1000);
            coffeMaker.Pay(20, new Cappuccino());

            Console.ReadKey();
        }
    }
}
