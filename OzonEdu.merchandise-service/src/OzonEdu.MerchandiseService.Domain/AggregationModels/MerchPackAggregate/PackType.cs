using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
    /// <summary> Тип пакета мерча </summary>
    public class PackType : Enumeration
    {
        public static PackType WelcomePack = new PackType(1, nameof(WelcomePack));
        public static PackType StarterPack = new PackType(2, nameof(StarterPack));
        public static PackType ConferenceListenerPack = new PackType(3, nameof(ConferenceListenerPack));
        public static PackType ConferenceSpeakerPack = new PackType(4, nameof(ConferenceSpeakerPack));
        public static PackType VeteranPack = new PackType(5, nameof(VeteranPack));
        
        public PackType(int id, string name) : base(id, name)
        {
        }
    }
}