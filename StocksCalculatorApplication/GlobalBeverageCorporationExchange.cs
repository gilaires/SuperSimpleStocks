namespace StocksCalculatorApplication
{
    using System.Collections.Generic;
    using StocksDomainModel;
    using System;
    using System.Linq;

    public static class GlobalBeverageCorporationExchange
    {
        #region GBCE Constructors
        static GlobalBeverageCorporationExchange()
        {
            GlobalBeverageCorporationExchange.Stocks = new List<Stock>
            {
                StockTea,
                StockPop,
                StockAle,
                StockGin,
                StockJoe
            };

            GlobalBeverageCorporationExchange.Trades = new List<Trade>();
        }
        #endregion 


        #region GBCE Properties
        /// <summary>
        /// The total trades that have happened in the GBCE.
        /// </summary>
        public static List<Trade> Trades;

        /// <summary>
        /// All the stocks listed in the GBCE.
        /// </summary>
        public static List<Stock> Stocks;
    
        public static Stock StockTea = new Stock
        {
            Symbol = "TEA",
            Type = StockType.Common,
            LastDividend = 0,
            ParValue = 100
        };

        public static Stock StockPop = new Stock
        {
            Symbol = "POP",
            Type = StockType.Common,
            LastDividend = 8,
            ParValue = 100
        };

        public static Stock StockAle = new Stock
        {
            Symbol = "ALE",
            Type = StockType.Common,
            LastDividend = 23,
            ParValue = 60
        };

        public static Stock StockGin = new Stock
        {
            Symbol = "GIN",
            Type = StockType.Preferred,
            LastDividend = 8,
            FixedDividend = 0.02,
            ParValue = 100
        };

        public static Stock StockJoe = new Stock
        {
            Symbol = "JOE",
            Type = StockType.Common,
            LastDividend = 13,
            ParValue = 250
        };
        #endregion


        #region GBCE Methods
        /// <summary>
        /// Records a Buy or Sell trade in the GBCE.
        /// </summary>
        /// <param name="stock">The stock to trade.</param>
        /// <param name="quantityOfShares">The number of shares to trade.</param>
        /// <param name="tradeIndicator">Indicates wether the trade is a Buy or a Sell.</param>
        /// <param name="price">The price of the stock in this trade.</param>
        public static void RecordTrade(Stock stock, double quantityOfShares, TradeIndicator tradeIndicator, double price)
        {
            var trade = new Trade
            {
                TimeStamp = DateTime.Now,
                Quantity = quantityOfShares,
                TradeIndicator = tradeIndicator,
                Price = price,
                Stock = stock
            };

            GlobalBeverageCorporationExchange.Trades.Add(trade);

            stock.LastDividend = CalculateStockPrice(stock);
        }

        /// <summary>
        /// Calculate Stock Price based on trades recorded in past 15 minutes.
        /// If there are no Trades for a given stock, it's price is defaulted to 1, 
        /// not to interfere with GBCE All Share Index calculation.
        /// </summary>
        /// <param name="stock">The stock to calculate the price.</param>
        /// <returns>The stock price for the given stock.</returns>
        public static double CalculateStockPrice(Stock stock)
        {
            double numeratorAccumulator = 0;
            double denominatorAccumulator = 0;
            var fifteenMinutesAgo = DateTime.Now.AddMinutes(-15);

            var listOfTrades = GlobalBeverageCorporationExchange.Trades
                                   .Select(t => t)
                                   .Where(t => t.Stock.Symbol.Equals(stock.Symbol)
                                               && t.TimeStamp >= fifteenMinutesAgo);

            // Sum (TradePrice x Quantity) / Sum (Quantity)
            foreach (var trade in listOfTrades)
            {
                numeratorAccumulator = numeratorAccumulator + (trade.Price*trade.Quantity);
                denominatorAccumulator = denominatorAccumulator + trade.Quantity;
            }

            var result = numeratorAccumulator/denominatorAccumulator;

            result = double.IsNaN(result) ? 1 : result;

            return result;
        }

        /// <summary>
        /// Calculate the GBCE All Share Index using the geometric mean of prices for all stocks
        /// </summary>
        /// <returns>The GBCE All Share Index.</returns>
        public static double CalculateGbceAllShareIndex()
        {
            double result;
            double multiplicationAccumulator = 1;

            foreach (var stock in GlobalBeverageCorporationExchange.Stocks)
            {
                var stockPrice = CalculateStockPrice(stock);
                multiplicationAccumulator = multiplicationAccumulator*stockPrice;
            }

            result = Math.Pow(multiplicationAccumulator, 1.0 / GlobalBeverageCorporationExchange.Stocks.Count);

            return result;
        }

        /// <summary>
        /// Calculates the Stock Dividend Yield.
        /// </summary>
        /// <param name="stock">The stock.</param>
        /// <param name="tickerPrice">The ticker price of the stock.</param>
        /// <returns></returns>
        public static double StockDividendYieldCalculation(Stock stock, double tickerPrice)
        {
            switch (stock.Type)
            {
                case StockType.Common:
                    {
                        return (stock.LastDividend / tickerPrice);
                    }
                case StockType.Preferred:
                    {
                        return ((stock.FixedDividend * stock.ParValue) / tickerPrice);
                    }
                default:
                    throw new Exception("Unknown Stock Type");
            }
        }

        /// <summary>
        /// Calculates the P/E Ratio of a given stock.
        /// </summary>
        /// <param name="stock">The stock to calculate P/E Ratio.</param>
        /// <param name="tickerPrice">The ticker price of the stock.</param>
        /// <returns></returns>
        public static double StockPeRatioFormula(Stock stock, double tickerPrice)
        {
            var dividend = StockDividendYieldCalculation(stock, tickerPrice);
            return tickerPrice / dividend;
        }
        #endregion
    }
}
