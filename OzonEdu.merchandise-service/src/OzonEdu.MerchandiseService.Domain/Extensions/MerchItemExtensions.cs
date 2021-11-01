using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;

namespace OzonEdu.MerchandiseService.Domain.Extensions
{
    public static class MerchItemExtensions
    {
        #region TShirt
        
        public static MerchItem GetTShirt(this MerchItem item, ClothingSize size)
        {
            return new MerchItem(
                new Sku(10),
                new Name("Some tshirt"),
                new ItemEntity(ItemType.TShirt),
                size, 
                new Quantity(10),
                new MinimalQuantity(0),
                new Tag("tshirts"));
        }
        
        public static MerchItem[] GetTShirts(this MerchItem item, int count, ClothingSize size)
        {
            MerchItem[] items = new MerchItem[count];
            for (int i = 0; i < count; i++)
            {
                items[i] = GetTShirt(item, size);
            }

            return items;
        }
        
        #endregion

        #region Sweatshirt

        public static MerchItem GetSweatshirt(this MerchItem item, ClothingSize size)
        {
            return new MerchItem(
                new Sku(20),
                new Name("Some sweatshirt"),
                new ItemEntity(ItemType.Sweatshirt),
                size, 
                new Quantity(10),
                new MinimalQuantity(0),
                new Tag("sweatshirts"));
        }
        
        public static MerchItem[] GetSweatshirts(this MerchItem item, int count, ClothingSize size)
        {
            MerchItem[] items = new MerchItem[count];
            for (int i = 0; i < count; i++)
            {
                items[i] = GetSweatshirt(item, size);
            }

            return items;
        }
        
        #endregion
        
        #region Notepad
        
        public static MerchItem GetNotepad(this MerchItem item)
        {
            return new MerchItem(
                new Sku(30),
                new Name("Some notepad"),
                new ItemEntity(ItemType.Notepad),
                null, 
                new Quantity(10),
                new MinimalQuantity(0),
                new Tag("notepads"));
        }
        
        public static MerchItem[] GetNotepads(this MerchItem item, int count)
        {
            MerchItem[] items = new MerchItem[count];
            for (int i = 0; i < count; i++)
            {
                items[i] = GetNotepad(item);
            }

            return items;
        }
        
        #endregion

        #region Bag

        public static MerchItem GetBag(this MerchItem item)
        {
            return new MerchItem(
                new Sku(40),
                new Name("Some bag"),
                new ItemEntity(ItemType.Bag),
                null, 
                new Quantity(10),
                new MinimalQuantity(0),
                new Tag("bags"));
        }
        
        public static MerchItem[] GetBags(this MerchItem item, int count)
        {
            MerchItem[] items = new MerchItem[count];
            for (int i = 0; i < count; i++)
            {
                items[i] = GetBag(item);
            }

            return items;
        }

        #endregion
        
        #region Pen

        public static MerchItem GetPen(this MerchItem item)
        {
            return new MerchItem(
                new Sku(50),
                new Name("Some pen"),
                new ItemEntity(ItemType.Pen),
                null, 
                new Quantity(10),
                new MinimalQuantity(0),
                new Tag("pens"));
        }
        
        public static MerchItem[] GetPens(this MerchItem item, int count)
        {
            MerchItem[] items = new MerchItem[count];
            for (int i = 0; i < count; i++)
            {
                items[i] = GetPen(item);
            }

            return items;
        }

        #endregion
        
        #region Socks

        public static MerchItem GetSocks(this MerchItem item)
        {
            return new MerchItem(
                new Sku(60),
                new Name("Some socks"),
                new ItemEntity(ItemType.Socks),
                null, 
                new Quantity(10),
                new MinimalQuantity(0),
                new Tag("socks"));
        }
        
        public static MerchItem[] GetSocks(this MerchItem item, int count)
        {
            MerchItem[] items = new MerchItem[count];
            for (int i = 0; i < count; i++)
            {
                items[i] = GetSocks(item);
            }

            return items;
        }

        #endregion
    }
}