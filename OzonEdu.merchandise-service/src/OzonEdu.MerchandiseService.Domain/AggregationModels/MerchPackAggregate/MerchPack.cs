using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
    /// <summary> Пакет мерча </summary>
    public class MerchPack : Entity
    {
        #region Properties

        // mershPacketType должен содержать несколько Sku, которые хранятся на стоке
        
        public MerchPackEntity Pack { get; }

        #endregion
    }
}