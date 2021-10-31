using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
    /// <summary> Тип пакета мерча </summary>
    public class MerchPackType : Enumeration
    {
        public static MerchPackType WelcomePack = new MerchPackType(1, nameof(WelcomePack));
        public static MerchPackType StarterPack = new MerchPackType(2, nameof(StarterPack));
        public static MerchPackType ConferenceListenerPack = new MerchPackType(3, nameof(ConferenceListenerPack));
        public static MerchPackType ConferenceSpeakerPack = new MerchPackType(4, nameof(ConferenceSpeakerPack));
        public static MerchPackType VeteranPack = new MerchPackType(5, nameof(VeteranPack));
        
        public MerchPackType(int id, string name) : base(id, name)
        {
        }
    }
}