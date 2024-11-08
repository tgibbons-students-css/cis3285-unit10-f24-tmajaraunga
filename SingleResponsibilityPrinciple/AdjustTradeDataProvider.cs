using SingleResponsibilityPrinciple.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple 
{
    public class AdjustTradeDataProvider : ITradeDataProvider
    {
        private ITradeDataProvider objectt;
        public AdjustTradeDataProvider(ITradeDataProvider objectt) 
        { 
            this.objectt = objectt; 
        }

        public IEnumerable<string> GetTradeData() 
        {
            IEnumerable<string> stats = objectt.GetTradeData();
            List<string> result = new List<string>();
            foreach (String t in stats)
            {
                String newT = t.Replace("GBP", "EUR");
                result.Add(newT);
            }
            return stats;
        }
    }
}
