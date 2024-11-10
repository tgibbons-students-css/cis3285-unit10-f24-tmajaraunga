
using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class TradeProcessor
    {
        public TradeProcessor(ITradeDataProvider tradeDataProvider, ITradeParser tradeParser, ITradeStorage tradeStorage)
        {
            this.tradeDataProvider = tradeDataProvider;
            this.tradeParser = tradeParser;
            this.tradeStorage = tradeStorage;
        }

        public async Task ProcessTradesAsync()
        {
            await foreach (var tradeData in tradeDataProvider.GetTradeDataAsync())
            {
                var trade = tradeParser.Parse(tradeData);
                tradeStorage.Persist((IEnumerable<TradeRecord>)trade);
            }
        }

        private readonly ITradeDataProvider tradeDataProvider;
        private readonly ITradeParser tradeParser;
        private readonly ITradeStorage tradeStorage;
    }
}
