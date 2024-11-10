using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class AsyncURLProvider : ITradeDataProvider
    {
        private readonly ITradeDataProvider objec;

        public AsyncURLProvider(ITradeDataProvider objec)
        {
            this.objec = objec;
        }

        public async IAsyncEnumerable<string> GetTradeDataAsync()
        {
            var tradeData = objec.GetTradeDataAsync();

            await foreach (var trade in tradeData)
            {
                await Task.Yield();
                yield return trade;
            }
        }
    }
}
