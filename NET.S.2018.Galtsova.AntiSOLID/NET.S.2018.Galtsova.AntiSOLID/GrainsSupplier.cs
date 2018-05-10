using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Galtsova.AntiSOLID
{
    public class GrainsSupplier
    {
        private static decimal _priceOfGrain;

        static GrainsSupplier()
        {
            _priceOfGrain = 10;
        }
            
        public GrainsSupplier(decimal priceOfGrain)
        {
            _priceOfGrain = priceOfGrain;
        } 

        public static double SellGrains(double grainsWeight, decimal amountOfMoney)
        {
            if (_priceOfGrain * (decimal)grainsWeight <= amountOfMoney)
            {
                return grainsWeight;
            }

            return 0;
        }
    }
}

