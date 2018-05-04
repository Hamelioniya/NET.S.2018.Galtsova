using System;

namespace Task3.Solution
{
    public class Stock
    {
        private StockInfo stocksInfo;
        public EventHandler<StockEventArgs> StockInfoChanged;

        public Stock()
        {
            stocksInfo = new StockInfo();
        }

        public void Market()
        {
            Random rnd = new Random();
            stocksInfo.USD = rnd.Next(20, 40);
            stocksInfo.Euro = rnd.Next(30, 50);

            StockEventArgs eventArgs = new StockEventArgs() { Date = DateTime.Now, StockInfo = stocksInfo };

            OnTimeElapsed(eventArgs);
        }

        protected virtual void OnTimeElapsed(StockEventArgs e)
        {
            if (ReferenceEquals(StockInfoChanged, null))
            {
                throw new ArgumentNullException(nameof(StockInfoChanged));
            }

            StockInfoChanged(this, e);
        }
    }
}
