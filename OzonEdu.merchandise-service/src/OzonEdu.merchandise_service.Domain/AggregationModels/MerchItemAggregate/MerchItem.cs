using System;
using System.ComponentModel;
using OzonEdu.merchandise_service.DomainBase.Models;

namespace OzonEdu.merchandise_service.Domain.AggregationModels.MerchItemAggregate
{
    /// <summary> Мерч </summary>
    public class MerchItem : Entity
    {
        #region Properties

        public Sku Sku { get; }
        public Name Name { get; }
        public ItemEntity Type { get; }
        public ClothingSize ClothingSize { get; }
        public Quantity Quantity { get; private set; }
        public MinimalQuantity MinimalQuantity { get; }
        public Tag Tag { get; }

        #endregion

        public MerchItem(Sku sku, 
            Name name, 
            ItemEntity type, 
            ClothingSize clothingSize, 
            Quantity quantity, 
            MinimalQuantity minimalQuantity, 
            Tag tag)
        {
            Sku = ValidateSku(sku);
            Name = ValidateName(name);
            Type = ValidateItemType(type);
            ClothingSize = ValidateClothingSize(clothingSize);
            Quantity = ValidateQuantity(quantity);
            MinimalQuantity = ValidateMinimalQuantity(minimalQuantity);
            Tag = ValidateTag(tag);
        }

        #region Methods

        public void IncreaseQuantity(int valueToIncrease)
        {
            if (valueToIncrease < 0) throw new ArgumentException("Value to increase cannot be less than zero");
            Quantity = new Quantity(this.Quantity.Value + valueToIncrease);
        }
        
        Sku ValidateSku(Sku sku)
        {
            if (sku == null) throw new ArgumentNullException("Sku cannot be null");
            return sku;
        }

        Name ValidateName(Name name)
        {
            if (name == null) throw new ArgumentNullException("Name cannot be null");
            if (name.Value == "") throw new ArgumentException("Name cannot be empty");
            return name;
        }

        ItemEntity ValidateItemType(ItemEntity itemType)
        {
            if (itemType == null || itemType.ItemType == null) throw new ArgumentNullException("Item type cannot be null");
            return itemType;
        }

        ClothingSize ValidateClothingSize(ClothingSize clothingSize)
        {
            return clothingSize;
        }

        Quantity ValidateQuantity(Quantity quantity)
        {
            if (quantity == null) throw new ArgumentNullException("Quantity type cannot be null");
            if (quantity.Value < 0) throw new ArgumentException("Quantity cannot be less than zero");
            return quantity;
        }

        MinimalQuantity ValidateMinimalQuantity(MinimalQuantity minimalQuantity)
        {
            if (minimalQuantity.Value < 0) throw new ArgumentException("Quantity cannot be less than zero");
            return minimalQuantity;
        }

        Tag ValidateTag(Tag tag)
        {
            return tag;
        }


        #endregion


        
    }
}