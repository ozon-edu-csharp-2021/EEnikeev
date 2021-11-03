using System;
using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate.V1;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using Name = OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate.Name;


namespace OzonEdu.MerchandiseService.Domain.Factory
{
    public enum EMerchType
    {
        /// <summary> Набор мерча, выдаваемый сотруднику при устройстве на работу. </summary>
        WelcomePack = 10,
    
        /// <summary> Набор мерча, выдаваемый сотруднику при посещении конференции в качестве слушателя. </summary>
        ConferenceListenerPack = 20,
    
        /// <summary> Набор мерча, выдаваемый сотруднику при посещении конференции в качестве спикера. </summary>
        ConferenceSpeakerPack = 30,
    
        /// <summary> Набор мерча, выдаваемый сотруднику при успешном прохождении испытательного срока. </summary>
        ProbationPeriodEndingPack = 40,
    
        /// <summary> Набор мерча, выдаваемый сотруднику за выслугу лет. </summary>
        VeteranPack = 50
    }
    
    public static class MerchPackFactory
    {
        public static MerchPack GetPack(EMerchType type, ClothingSize size)
        {
            switch (type)
            {
                case EMerchType.WelcomePack: return GetWelcomePack(size);
                case EMerchType.ProbationPeriodEndingPack: return GetStarterPack(size);
                case EMerchType.ConferenceListenerPack: return GetConferenceListenerPack(size);
                case EMerchType.ConferenceSpeakerPack: return GetConferenceSpeakerPack(size);
                case EMerchType.VeteranPack: return GetVeteranPack(size);
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
            return new MerchPack((int)EMerchType.WelcomePack, new Name("Welcome pack"), merchItems);
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
            return new MerchPack((int)EMerchType.ProbationPeriodEndingPack, new Name("Starter pack"), merchItems);
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
            return new MerchPack((int)EMerchType.ConferenceListenerPack, new Name("Conference listener pack"), merchItems);
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
            return new MerchPack((int)EMerchType.ConferenceSpeakerPack, new Name("Conference speaker pack"), merchItems);
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
            return new MerchPack((int)EMerchType.VeteranPack,new Name("Veteran pack"), merchItems);
        }
        
        #endregion
    }
}