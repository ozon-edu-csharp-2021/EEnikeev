using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
    public class MerchPack : Entity
    {
        #region Properties

        public Name Name { get; }
        
        public MerchItemList MerchItems { get; }

        #endregion

        public MerchPack(Name name, MerchItemList merchItems)
        {
            Name = name;
            MerchItems = merchItems;
        }
    }
}