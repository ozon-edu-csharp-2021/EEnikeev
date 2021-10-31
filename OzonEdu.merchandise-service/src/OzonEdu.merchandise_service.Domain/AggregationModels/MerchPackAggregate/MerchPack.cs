using OzonEdu.merchandise_service.DomainBase.Models;

namespace OzonEdu.merchandise_service.Domain.AggregationModels.MerchPackAggregate
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