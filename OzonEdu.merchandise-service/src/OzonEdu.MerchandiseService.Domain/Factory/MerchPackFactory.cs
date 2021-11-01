using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using Name = OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate.Name;

namespace OzonEdu.MerchandiseService.Domain.Factory
{
    public static class MerchPackFactory
    {
        #region WelcomePack

        public static MerchPack GetWelcomePack(ClothingSize size = null)
        {
            MerchItemList merchItems = new MerchItemList(new List<MerchItem>()
            {
                MerchItemFactory.GetPen(),
                MerchItemFactory.GetNotepad()
            });
            return new MerchPack(new Name("Welcome pack"), merchItems);
        }

        #endregion
        
        #region StarterPack
        
        public static MerchPack GetStarterPack(ClothingSize size)
        {
            MerchItemList merchItems = new MerchItemList(new List<MerchItem>()
            {
                MerchItemFactory.GetPen(),
                MerchItemFactory.GetNotepad(),
                MerchItemFactory.GetTShirt(size),
                
            });
            return new MerchPack(new Name("Starter pack"), merchItems);
        }
        
        #endregion
        
        #region ConferenceListenerPack
        
        public static MerchPack GetConferenceListenerPack(ClothingSize size)
        {
            MerchItemList merchItems = new MerchItemList(new List<MerchItem>()
            {
                MerchItemFactory.GetPen(),
                MerchItemFactory.GetNotepad(),
                MerchItemFactory.GetTShirt(size),
                MerchItemFactory.GetSweatshirt(size),
                MerchItemFactory.GetSocks() 
            });
            return new MerchPack(new Name("Conference listener pack"), merchItems);
        }
        
        #endregion
        
        #region ConferenceSpeakerPack
        
        public static MerchPack GetConferenceSpeakerPack(ClothingSize size)
        {
            MerchItemList merchItems = new MerchItemList(new List<MerchItem>()
            {
                MerchItemFactory.GetPen(2),
                MerchItemFactory.GetNotepad(2),
                MerchItemFactory.GetTShirt(size,2),
                MerchItemFactory.GetSweatshirt(size),
                MerchItemFactory.GetSocks(),
                MerchItemFactory.GetBag()
            });
            return new MerchPack(new Name("Conference speaker pack"), merchItems);
        }
        
        #endregion
        
        #region VeteranPack
        
        public static MerchPack GetVeteranPack(ClothingSize size)
        {
            MerchItemList merchItems = new MerchItemList(new List<MerchItem>()
            {
                MerchItemFactory.GetPen(2),
                MerchItemFactory.GetNotepad(2),
                MerchItemFactory.GetTShirt(size,2),
                MerchItemFactory.GetSweatshirt(size,2),
                MerchItemFactory.GetSocks(2),
                MerchItemFactory.GetBag(2),
            });
            return new MerchPack(new Name("Veteran pack"), merchItems);
        }
        
        #endregion
    }
}