using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Galtsova.AntiSOLID
{
    public interface ICoffeeMaker
    {
        void CookCoffee(string coffeeName);

        decimal Pay(decimal amountOfMoney, object coffee);

        void Wash();

        void AddBeans(double grainsWeight, decimal amountOfMoney);

        void On();

        void Off();
    }
}
