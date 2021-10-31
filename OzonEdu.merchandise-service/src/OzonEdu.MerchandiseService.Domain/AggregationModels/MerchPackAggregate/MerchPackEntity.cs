using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
    /// <summary> Тип пакета мерча </summary>
    public class MerchPackEntity : Entity
    {
        public MerchPackType MerchPackType { get; }
        
        public SkuList SkuItems { get; }

        public MerchPackEntity(MerchPackType merchPackType, SkuList skuItems)
        {
            MerchPackType = merchPackType;
            SkuItems = skuItems;
        }
    }
}