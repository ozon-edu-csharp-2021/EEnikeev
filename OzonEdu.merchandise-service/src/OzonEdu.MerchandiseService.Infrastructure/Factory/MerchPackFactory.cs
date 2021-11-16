using System;
using System.Collections.Generic;
using CSharpCourse.Core.Lib.Enums;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;

namespace OzonEdu.MerchandiseService.Infrastructure.Factory
{
    
    public static class MerchPackFactory
    {
        public static MerchPack GetPack(MerchType type, ClothingSize size)
        {
            switch (type)
            {
                case MerchType.WelcomePack: return GetWelcomePack(size);
                case MerchType.ProbationPeriodEndingPack: return GetStarterPack(size);
                case MerchType.ConferenceListenerPack: return GetConferenceListenerPack(size);
                case MerchType.ConferenceSpeakerPack: return GetConferenceSpeakerPack(size);
                case MerchType.VeteranPack: return GetVeteranPack(size);
                default: throw new ArgumentException($"Неизвестный тип мерча: {type}");
            }
        }


        #region WelcomePack

        public static MerchPack GetWelcomePack(ClothingSize size = null)
        {
            MerchItemList merchItems = new MerchItemList(new List<MerchItem>()
            {
                MerchItemFactory.GetPen(),
                MerchItemFactory.GetNotepad()
            });
            return new MerchPack((int)MerchType.WelcomePack, new MerchPackName("Welcome pack"), merchItems);
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
            return new MerchPack((int)MerchType.ProbationPeriodEndingPack, new MerchPackName("Starter pack"), merchItems);
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
            return new MerchPack((int)MerchType.ConferenceListenerPack, new MerchPackName("Conference listener pack"), merchItems);
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
            return new MerchPack((int)MerchType.ConferenceSpeakerPack, new MerchPackName("Conference speaker pack"), merchItems);
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
            return new MerchPack((int)MerchType.VeteranPack,new MerchPackName("Veteran pack"), merchItems);
        }
        
        #endregion
    }
}