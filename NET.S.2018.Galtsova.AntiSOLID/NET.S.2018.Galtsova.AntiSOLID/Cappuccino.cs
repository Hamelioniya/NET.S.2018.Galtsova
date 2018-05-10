using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Galtsova.AntiSOLID
{
    public class Cappuccino
    {
        public decimal Price { get; set; }
        public double GrainsWeight { get; set; }

        public Cappuccino()
        {
            Price = 10;
            GrainsWeight = 5;
        }

        public string Cook()
        {
            return "Cook cappuccino";
        }

        public double GrindGrain(double grainsWeight)
        {
            grainsWeight -= GrainsWeight;

            return grainsWeight;
        }
    }
}
