using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
    /// <summary> Тип пакета мерча </summary>
    public class PackEntity : Entity
    {
        public PackType Type { get; }
        
        public SkuList SkuItems { get; }

        public PackEntity(PackType merchPackType, SkuList skuItems)
        {
            Type = merchPackType;
            SkuItems = skuItems;
        }
    }
}