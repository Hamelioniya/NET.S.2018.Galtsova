using System;

namespace Task3.Solution
{
    public class StockEventArgs : EventArgs
    {
        public DateTime Date { get; set; }

        public int USD { get; set; }

        public int Euro { get; set; }
    }
}
