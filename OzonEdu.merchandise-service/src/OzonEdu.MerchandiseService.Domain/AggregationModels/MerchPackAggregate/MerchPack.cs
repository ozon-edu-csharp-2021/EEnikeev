using System;
using OzonEdu.MerchandiseService.Domain.Contracts;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
    public sealed class MerchPack : Entity, IAggregateRoot
    {
        #region Properties
        
        public MerchPackName Name { get; }
        
        public MerchItemList MerchItems { get; }

        #endregion

        public MerchPack(int id, MerchPackName name, MerchItemList merchItems)
        {
            Id = id;
            Name = ValidateName(name);
            MerchItems = ValidateMerchItems(merchItems);
        }

        MerchPackName ValidateName(MerchPackName name)
        {
            if (name == null || name.Value == null)
                throw new ArgumentNullException("Merch package name cannot be null");
            if (name.Value == "") throw new ArgumentException("Merch package name cannot be empty");
            return name;
        }

        MerchItemList ValidateMerchItems(MerchItemList items)
        {
            if (items == null || items.Items == null)
                throw new ArgumentNullException("Merch items connot be null");
            return items;

        }
        
    }
}