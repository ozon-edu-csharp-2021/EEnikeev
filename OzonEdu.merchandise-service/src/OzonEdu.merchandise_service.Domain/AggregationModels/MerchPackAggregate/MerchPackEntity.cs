using System.Collections.Generic;
using OzonEdu.merchandise_service.DomainBase.Models;

namespace OzonEdu.merchandise_service.Domain.AggregationModels.MerchPackAggregate
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