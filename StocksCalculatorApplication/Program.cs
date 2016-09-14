namespace StocksCalculatorApplication
{
    using System;
    using System.Linq;
    using StocksDomainModel;

    public class Program
    {
        public static void Main(string[] args)
        {
            GlobalBeverageCorporationExchange.RecordTrade(GlobalBeverageCorporationExchange.StockTea, 1, TradeIndicator.Buy, 100);
            GlobalBeverageCorporationExchange.RecordTrade(GlobalBeverageCorporationExchange.StockTea, 10, TradeIndicator.Sell, 100);
            GlobalBeverageCorporationExchange.RecordTrade(GlobalBeverageCorporationExchange.StockTea, 2, TradeIndicator.Buy, 200);
            GlobalBeverageCorporationExchange.RecordTrade(GlobalBeverageCorporationExchange.StockTea, 5, TradeIndicator.Buy, 300);
            GlobalBeverageCorporationExchange.RecordTrade(GlobalBeverageCorporationExchange.StockTea, 100, TradeIndicator.Buy, 600);

            GlobalBeverageCorporationExchange.RecordTrade(GlobalBeverageCorporationExchange.StockPop, 1, TradeIndicator.Sell, 50);
            GlobalBeverageCorporationExchange.RecordTrade(GlobalBeverageCorporationExchange.StockPop, 2, TradeIndicator.Sell, 60);
            GlobalBeverageCorporationExchange.RecordTrade(GlobalBeverageCorporationExchange.StockPop, 20, TradeIndicator.Buy, 700);
            GlobalBeverageCorporationExchange.RecordTrade(GlobalBeverageCorporationExchange.StockPop, 40, TradeIndicator.Buy, 800);
            GlobalBeverageCorporationExchange.RecordTrade(GlobalBeverageCorporationExchange.StockPop, 10, TradeIndicator.Buy, 900);

            GlobalBeverageCorporationExchange.RecordTrade(GlobalBeverageCorporationExchange.StockAle, 10, TradeIndicator.Buy, 100);
            GlobalBeverageCorporationExchange.RecordTrade(GlobalBeverageCorporationExchange.StockAle, 100, TradeIndicator.Sell, 50);
            GlobalBeverageCorporationExchange.RecordTrade(GlobalBeverageCorporationExchange.StockAle, 30, TradeIndicator.Buy, 250);
            GlobalBeverageCorporationExchange.RecordTrade(GlobalBeverageCorporationExchange.StockAle, 60, TradeIndicator.Buy, 300);

            GlobalBeverageCorporationExchange.RecordTrade(GlobalBeverageCorporationExchange.StockGin, 20, TradeIndicator.Buy, 20);
            GlobalBeverageCorporationExchange.RecordTrade(GlobalBeverageCorporationExchange.StockGin, 10, TradeIndicator.Sell, 100);
            GlobalBeverageCorporationExchange.RecordTrade(GlobalBeverageCorporationExchange.StockGin, 30, TradeIndicator.Buy, 30);
            GlobalBeverageCorporationExchange.RecordTrade(GlobalBeverageCorporationExchange.StockGin, 40, TradeIndicator.Buy, 40);
            GlobalBeverageCorporationExchange.RecordTrade(GlobalBeverageCorporationExchange.StockGin, 50, TradeIndicator.Buy, 50);
            GlobalBeverageCorporationExchange.RecordTrade(GlobalBeverageCorporationExchange.StockGin, 70, TradeIndicator.Sell, 50);

            GlobalBeverageCorporationExchange.RecordTrade(GlobalBeverageCorporationExchange.StockJoe, 10, TradeIndicator.Buy, 100);
            GlobalBeverageCorporationExchange.RecordTrade(GlobalBeverageCorporationExchange.StockJoe, 30, TradeIndicator.Sell, 30);
            GlobalBeverageCorporationExchange.RecordTrade(GlobalBeverageCorporationExchange.StockJoe, 60, TradeIndicator.Buy, 60);
            GlobalBeverageCorporationExchange.RecordTrade(GlobalBeverageCorporationExchange.StockJoe, 70, TradeIndicator.Buy, 70);

            var numberOfTeaTrades = GlobalBeverageCorporationExchange.Trades.Select(t => t).Count(t => t.Stock.Symbol.Equals("TEA"));
            var stockTeaPrice = GlobalBeverageCorporationExchange.CalculateStockPrice(GlobalBeverageCorporationExchange.StockTea);
            var stockTeaDividendYield = GlobalBeverageCorporationExchange.StockDividendYieldCalculation(GlobalBeverageCorporationExchange.StockTea, stockTeaPrice);
            var stockTeaPeRatio = GlobalBeverageCorporationExchange.StockPeRatioFormula(GlobalBeverageCorporationExchange.StockTea, stockTeaPrice);

            var numberOfPopTrades = GlobalBeverageCorporationExchange.Trades.Select(t => t).Count(t => t.Stock.Symbol.Equals("POP"));
            var stockPopPrice = GlobalBeverageCorporationExchange.CalculateStockPrice(GlobalBeverageCorporationExchange.StockPop);
            var stockPopDividendYield = GlobalBeverageCorporationExchange.StockDividendYieldCalculation(GlobalBeverageCorporationExchange.StockPop, stockPopPrice);
            var stockPopPeRatio = GlobalBeverageCorporationExchange.StockPeRatioFormula(GlobalBeverageCorporationExchange.StockPop, stockPopPrice);

            var numberOfAleTrades = GlobalBeverageCorporationExchange.Trades.Select(t => t).Count(t => t.Stock.Symbol.Equals("ALE"));
            var stockAlePrice = GlobalBeverageCorporationExchange.CalculateStockPrice(GlobalBeverageCorporationExchange.StockAle);
            var stockAleDividendYield = GlobalBeverageCorporationExchange.StockDividendYieldCalculation(GlobalBeverageCorporationExchange.StockAle, stockAlePrice);
            var stockAlePeRatio = GlobalBeverageCorporationExchange.StockPeRatioFormula(GlobalBeverageCorporationExchange.StockAle, stockAlePrice);

            var numberOfGinTrades = GlobalBeverageCorporationExchange.Trades.Select(t => t).Count(t => t.Stock.Symbol.Equals("GIN"));
            var stockGinPrice = GlobalBeverageCorporationExchange.CalculateStockPrice(GlobalBeverageCorporationExchange.StockGin);
            var stockGinDividendYield = GlobalBeverageCorporationExchange.StockDividendYieldCalculation(GlobalBeverageCorporationExchange.StockGin, stockGinPrice);
            var stockGinPeRatio = GlobalBeverageCorporationExchange.StockPeRatioFormula(GlobalBeverageCorporationExchange.StockGin, stockGinPrice);

            var numberOfJoeTrades = GlobalBeverageCorporationExchange.Trades.Select(t => t).Count(t => t.Stock.Symbol.Equals("JOE"));
            var stockJoePrice = GlobalBeverageCorporationExchange.CalculateStockPrice(GlobalBeverageCorporationExchange.StockJoe);
            var stockJoeDividendYield = GlobalBeverageCorporationExchange.StockDividendYieldCalculation(GlobalBeverageCorporationExchange.StockJoe, stockJoePrice);
            var stockJoePeRatio = GlobalBeverageCorporationExchange.StockPeRatioFormula(GlobalBeverageCorporationExchange.StockJoe, stockJoePrice);

            var gbceAllShareIndex = GlobalBeverageCorporationExchange.CalculateGbceAllShareIndex();

            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Global Beverage Corporation Exchange");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Total Number of Trades: " + GlobalBeverageCorporationExchange.Trades.Count());
            Console.WriteLine("All Share Index: " + gbceAllShareIndex);
            Console.WriteLine("-------------------------------------\n");
            Program.PrintStockResults("TEA", numberOfTeaTrades, stockTeaPrice, stockTeaDividendYield, stockTeaPeRatio);
            Program.PrintStockResults("POP", numberOfPopTrades, stockPopPrice, stockPopDividendYield, stockPopPeRatio);
            Program.PrintStockResults("ALE", numberOfAleTrades, stockAlePrice, stockAleDividendYield, stockAlePeRatio);
            Program.PrintStockResults("GIN", numberOfGinTrades, stockGinPrice, stockGinDividendYield, stockGinPeRatio);
            Program.PrintStockResults("JOE", numberOfJoeTrades, stockJoePrice, stockJoeDividendYield, stockJoePeRatio);
            Console.ReadLine();
        }

        private static void PrintStockResults(string stockName, int numberOfTrades, double stockPrice, double stockDividendYield, double stockPeRatio)
        {
            Console.WriteLine("Stock " + stockName + ":");
            Console.WriteLine("----------");
            Console.WriteLine("Number of Trades: " + numberOfTrades + ".");
            Console.WriteLine("Price: " + stockPrice + ".");
            Console.WriteLine("Dividend Yeld: " + stockDividendYield + ".");
            Console.WriteLine("P/E Ratio: " + stockPeRatio + ".\n");
        }
    }
}
