using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate.V1
{
    /// <summary> Тип товара </summary>
    public class ItemType : Enumeration
    {
        public static ItemType TShirt = new ItemType(1, nameof(TShirt));
        public static ItemType Sweatshirt = new ItemType(2, nameof(Sweatshirt));
        public static ItemType Notepad = new ItemType(3, nameof(Notepad));
        public static ItemType Bag = new ItemType(4, nameof(Bag));
        public static ItemType Pen = new ItemType(5, nameof(Pen));
        public static ItemType Socks = new ItemType(6, nameof(Socks));
        
        public ItemType(int id, string name) : base(id, name)
        {
        }
    }
}