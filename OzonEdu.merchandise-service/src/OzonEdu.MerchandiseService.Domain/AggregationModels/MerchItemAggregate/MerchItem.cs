using System;
using OzonEdu.MerchandiseService.Domain.Events;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate
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
            if (valueToIncrease < 0) throw new NegativeQuantityException(
                $"Value to increase cannot be less than zero: {valueToIncrease}");
            
            Quantity = new Quantity(this.Quantity.Value + valueToIncrease);
        }

        public void GiveOutItems(int quantityToGiveOut)
        {
            if (quantityToGiveOut < 0) throw new NegativeQuantityException(
                $"Items to give out cannot be less than zero: {quantityToGiveOut}");
            if (Quantity.Value < quantityToGiveOut) throw new NotEnoughQuantityException(
                "Not enough items to give out");
            
            Quantity = new Quantity(this.Quantity.Value - quantityToGiveOut);

            if (MinimalQuantity != null && Quantity.Value <= MinimalQuantity.Value)
                AddReachedMinimumQuantityDomainEvent(Sku);
        }

        void AddReachedMinimumQuantityDomainEvent(Sku sku)
        {
            var orderStartedDomainEvent = new ReachedMinimumMerchItemQuantityDomainEvent(sku);
            this.AddDomainEvent(orderStartedDomainEvent);
        }
        
        

        #region Validations

        Sku ValidateSku(Sku sku)
        {
            if (sku == null) throw new ArgumentNullException(
                "Sku cannot be null");
            return sku;
        }

        Name ValidateName(Name name)
        {
            if (name == null || name.Value is null) throw new ArgumentNullException(
                "Name cannot be null");
            if (name.Value == "") throw new ArgumentException(
                "Name cannot be empty");
            return name;
        }

        ItemEntity ValidateItemType(ItemEntity itemType)
        {
            if (itemType == null || itemType.ItemType == null) throw new ArgumentNullException(
                "Item type cannot be null");
            return itemType;
        }

        ClothingSize ValidateClothingSize(ClothingSize clothingSize)
        {
            if (this.Type.ItemType.Equals(ItemType.TShirt) || this.Type.ItemType.Equals(ItemType.Sweatshirt))
            {
                if (clothingSize == null)
                    throw new ClothingSizeException($"Item with type {this.Type.ItemType.Name} must have size");
            }
            else if (clothingSize != null)
                throw new ClothingSizeException($"Item with type {this.Type.ItemType.Name} cannot get size");

            return clothingSize;
        }

        Quantity ValidateQuantity(Quantity quantity)
        {
            if (quantity == null) throw new ArgumentNullException(
                "Quantity type cannot be null");
            if (quantity.Value < 0) throw new NegativeQuantityException(
                "Quantity cannot be less than zero");
            return quantity;
        }

        MinimalQuantity ValidateMinimalQuantity(MinimalQuantity minimalQuantity)
        {
            if (minimalQuantity.Value < 0) throw new NegativeQuantityException(
                $"Quantity cannot be less than zero: {minimalQuantity}");
            return minimalQuantity;
        }

        Tag ValidateTag(Tag tag)
        {
            return tag;
        }


        #endregion
        
        #endregion


        
    }
}