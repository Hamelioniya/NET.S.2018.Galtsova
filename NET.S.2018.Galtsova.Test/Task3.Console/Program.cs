using Task3.Solution;

namespace Task3.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock();
            Bank bank1 = new Bank("bank1");
            Bank bank2 = new Bank("bank2");
            Broker broker = new Broker("broker1");

            stock.StockInfoChanged += bank1.Update;
            stock.StockInfoChanged += bank2.Update;
            stock.StockInfoChanged += broker.Update;

            stock.Market();

            stock.StockInfoChanged -= bank1.Update;

            stock.Market();

            System.Console.ReadKey();
        }
    }
}
