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
        public Quantity Quantity { get; }
        public MinimalQuantity MinimalQuantity { get; }
        public string Tag { get; }

        #endregion

        public MerchItem(Sku sku, Name name, ItemEntity type, ClothingSize clothingSize, Quantity quantity, MinimalQuantity minimalQuantity, string tag)
        {
            Sku = ValidateSku(sku);
            Name = ValidateName(name);
            Type = ValidateItemType(type);
            ClothingSize = ValidateClothingSize(clothingSize);
            Quantity = ValidateQuantity(quantity);
            MinimalQuantity = ValidateMinimalQuantity(minimalQuantity);
            Tag = tag;
        }

        #region Methods

        /// <summary> Проверяет валидность sku </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Sku ValidateSku(Sku sku)
        {
            if (sku == null) throw new ArgumentNullException("sku cannot be null");
            return sku;
        }

        /// <summary> Проверяет валидность name </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Name ValidateName(Name name)
        {
            if (name == null) throw new ArgumentNullException("name cannot be null");
            return name;
        }

        /// <summary> Проверяет валидность item type </summary>
        /// <param name="itemType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        ItemEntity ValidateItemType(ItemEntity itemType)
        {
            if (itemType == null) throw new ArgumentNullException("item type cannot be null");
            return itemType;
        }

        /// <summary> Проверяет валидность clothing size </summary>
        /// <param name="clothingSize"></param>
        /// <returns></returns>
        ClothingSize ValidateClothingSize(ClothingSize clothingSize)
        {
            return clothingSize;
        }

        /// <summary> Проверяет валидность quantity </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        Quantity ValidateQuantity(Quantity quantity)
        {
            if (quantity == null) throw new ArgumentNullException("quantity type cannot be null");
            if (quantity.Value < 0) throw new ArgumentException("quantity cannot be less than zero");
            return quantity;
        }

        /// <summary> Проверяет валидность minimal quantity </summary>
        /// <param name="minimalQuantity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        MinimalQuantity ValidateMinimalQuantity(MinimalQuantity minimalQuantity)
        {
            if (minimalQuantity.Value < 0) throw new ArgumentException("quantity cannot be less than zero");
            return minimalQuantity;
        }
        
        


        #endregion
        
        
    }
}