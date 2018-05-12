using System;

namespace Task3.Solution
{
    public class Stock
    {
        public event EventHandler<StockEventArgs> StockInfoChanged;

        public void Market()
        {
            Random rnd = new Random();

            int _usd = rnd.Next(20, 40);
            int _euro = rnd.Next(30, 50);

            StockEventArgs eventArgs = new StockEventArgs() { Date = DateTime.Now, USD = _usd, Euro = _euro };

            OnStockInfoChanged(eventArgs);
        }

        protected virtual void OnStockInfoChanged(StockEventArgs e)
        {
            if (ReferenceEquals(StockInfoChanged, null))
            {
                throw new ArgumentNullException(nameof(StockInfoChanged));
            }

            StockInfoChanged(this, e);
        }
    }
}
