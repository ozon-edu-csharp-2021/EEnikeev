using System.Collections.Generic;

namespace OzonEdu.MerchandiseService.Infrastructure.Broker.Contracts
{
    public class StockReplenishedEventContract
    {
        public IReadOnlyCollection<StockReplenishedItem> Type { get; set; }

        public StockReplenishedEventContract()
        {
            
        }

        public StockReplenishedEventContract(IReadOnlyCollection<StockReplenishedItem> type)
        {
            Type = type;
        }

        public override string ToString()
        {
            string result = "";
            foreach (var item in Type)
            {
                result += Type.ToString()+"\n";
            }

            return result;
        }
    }
}