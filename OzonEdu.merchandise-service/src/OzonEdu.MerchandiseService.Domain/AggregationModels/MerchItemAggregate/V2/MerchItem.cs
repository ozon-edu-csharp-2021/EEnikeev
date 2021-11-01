using System;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate.V2
{
    public class MerchItem : Entity
    {
        public Sku sku { get; }
        
        public Quantity Quantity { get; }

        public MerchItem(Sku sku, Quantity quantity)
        {
            this.sku = ValidateSku(sku);
            Quantity = ValidateQuantity(quantity);
        }

        #region Methods

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