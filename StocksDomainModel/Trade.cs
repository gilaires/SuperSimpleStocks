namespace StocksDomainModel
{
    using System;

    public class Trade
    {
        public DateTime TimeStamp { get; set; }
        public double Quantity { get; set; }
        public TradeIndicator TradeIndicator { get; set; }
        public double Price { get; set; }
        public Stock Stock { get; set; }
    }
}
