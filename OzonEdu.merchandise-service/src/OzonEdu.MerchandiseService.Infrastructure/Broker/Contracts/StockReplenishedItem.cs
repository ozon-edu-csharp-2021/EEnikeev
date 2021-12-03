namespace OzonEdu.MerchandiseService.Infrastructure.Broker.Contracts
{
    public class StockReplenishedItem
    {
        public long Sku { get; set;  }

        public int ItemTypeId { get; set; }

        public string ItemTypeName { get; set; } = string.Empty;

        public int? ClothingSize { get; set; }

        public StockReplenishedItem(long sku, int itemTypeId, int? clothingSize)
        {
            Sku = sku;
            ItemTypeId = itemTypeId;
            ClothingSize = clothingSize;
        }

        public StockReplenishedItem()
        {
            
        }

        public override string ToString()
        {
            return $"Sku: {Sku}," +
                   $"ItemType: {ItemTypeId}," +
                   $"ItemTypeName: {(string.IsNullOrEmpty(ItemTypeName) ? "none" : ItemTypeName)}" +
                   $"{(ClothingSize is null ? "" : $", ClothingSize: {ClothingSize}")}";
        }
    }
}