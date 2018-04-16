using System;
using System.Collections.Generic;

namespace DataStructure.Tests
{
    public class ComparatorPoint : IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            double vectorX = Math.Sqrt((x.X * x.X) + (x.Y * x.Y));
            double vectorY = Math.Sqrt((y.X * y.X) + (y.Y * y.Y));

            if (vectorX == vectorY)
            {
                return 0;
            }

            if (vectorX > vectorY)
            {
                return 1;
            }

            return -1;
        }
    }
}
