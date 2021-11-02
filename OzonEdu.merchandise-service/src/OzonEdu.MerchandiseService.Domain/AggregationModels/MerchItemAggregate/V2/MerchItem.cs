using System;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate.V2
{
    public class MerchItem : Entity
    {
        public Sku sku { get; }
        
        public Quantity Quantity { get; private set; }

        public MerchItem(Sku sku, Quantity quantity)
        {
            this.sku = ValidateSku(sku);
            Quantity = ValidateQuantity(quantity);
        }

        #region Methods
        
        public void IncreaseQuantity(int valueToIncrease)
        {
            if (valueToIncrease < 0) throw new ArgumentException($"Value to increase cannot be less than zero: {valueToIncrease}");
            
            Quantity = new Quantity(this.Quantity.Value + valueToIncrease);
        }

        public void DecreaseQuantity(int quantityToGiveOut)
        {
            if (quantityToGiveOut < 0) throw new ArgumentException(
                $"Items to give out cannot be less than zero: {quantityToGiveOut}");
            if (Quantity.Value < quantityToGiveOut) throw new ArgumentException(
                "Not enough items to decrease");
            
            Quantity = new Quantity(this.Quantity.Value - quantityToGiveOut);
        }

        Sku ValidateSku(Sku sku)
        {
            if (sku == null) throw new ArgumentNullException("Sku cannot be null");
            return sku;
        }
        
        Quantity ValidateQuantity(Quantity quantity)
        {
            if (quantity == null) throw new ArgumentNullException("Quantity type cannot be null");
            if (quantity.Value < 0) throw new ArgumentException("Quantity cannot be less than zero");
            return quantity;
        }

        #endregion
    }
}