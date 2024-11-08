using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class AsyncURLProvider : ITradeDataProvider
    {
        private ITradeDataProvider objec;

        public AsyncURLProvider(ITradeDataProvider objec)
        {
            this.objec = objec;
        }

        public Task<IEnumerable<string>> GetTradeAsync()
        {
            Task<IEnumerable<string>> task = Task.Run(() => objec.GetTradeData());
            return task;
        }

        public IEnumerable<string> GetTradeData()
        {
            Task<IEnumerable<string>> task = Task.Run(() => GetTradeAsync());
            task.Wait();

            IEnumerable<string> tradeList = task.Result;
            return tradeList;
        } 
    }
}
