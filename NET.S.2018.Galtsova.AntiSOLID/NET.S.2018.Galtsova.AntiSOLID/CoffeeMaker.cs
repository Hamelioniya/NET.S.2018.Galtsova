using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Galtsova.AntiSOLID
{
    class CoffeeMaker : ICoffeeMaker
    {
        public CoffeeMaker()
        {
            TotalBeansWeight = 0;
            Status = "Off";
        }

        private double TotalBeansWeight { get; set; }
        public string Status { get; set; }

        public void AddBeans(double beansWeight, decimal amountOfMoney)
        {
            TotalBeansWeight = GrainsSupplier.SellGrains(beansWeight, amountOfMoney);
        }

        public void CookCoffee(string coffeeName)
        {
            if (Status == "Off")
            {
                return;
            }

            if (coffeeName == "Cappuccino")
            {
                Cappuccino cappucino = new Cappuccino();
                TotalBeansWeight = cappucino.GrindGrain(TotalBeansWeight);
                Console.WriteLine(cappucino.Cook() +  "\nBeans left: " + TotalBeansWeight.ToString() + "\n");
            }
        }

        public void Off()
        {
            Status = "Off";
        }

        public void On()
        {
            Status = "On";
        }

        public decimal Pay(decimal amountOfMoney, object coffee)
        {
            if (Status == "Off")
            {
                return amountOfMoney;
            }

            if (coffee.GetType() == typeof(Cappuccino))
            {
                if ((((Cappuccino)coffee).Price <= amountOfMoney) && (TotalBeansWeight > ((Cappuccino)coffee).GrainsWeight))
                {
                    CookCoffee("Cappuccino");

                    return amountOfMoney - ((Cappuccino)coffee).Price;
                }
            }

            return amountOfMoney;
        }

        public void Wash()
        {
            Console.WriteLine("Coffee maker was washed!");
        }
    }
}
