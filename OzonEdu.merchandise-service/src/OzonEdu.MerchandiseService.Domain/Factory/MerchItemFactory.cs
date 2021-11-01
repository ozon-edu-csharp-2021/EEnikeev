using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;

namespace OzonEdu.MerchandiseService.Domain.Factory
{
    public static class MerchItemFactory
    {
        #region TShirt
        
        public static MerchItem GetTShirt(ClothingSize size)
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
        
        public static MerchItem[] GetTShirts(int count, ClothingSize size)
        {
            MerchItem[] items = new MerchItem[count];
            for (int i = 0; i < count; i++)
            {
                items[i] = GetTShirt(size);
            }

            return items;
        }
        
        #endregion

        #region Sweatshirt

        public static MerchItem GetSweatshirt(ClothingSize size)
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
        
        public static MerchItem[] GetSweatshirts(int count, ClothingSize size)
        {
            MerchItem[] items = new MerchItem[count];
            for (int i = 0; i < count; i++)
            {
                items[i] = GetSweatshirt(size);
            }

            return items;
        }
        
        #endregion
        
        #region Notepad
        
        public static MerchItem GetNotepad()
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
        
        public static MerchItem[] GetNotepads(int count)
        {
            MerchItem[] items = new MerchItem[count];
            for (int i = 0; i < count; i++)
            {
                items[i] = GetNotepad();
            }

            return items;
        }
        
        #endregion

        #region Bag

        public static MerchItem GetBag()
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
        
        public static MerchItem[] GetBags(int count)
        {
            MerchItem[] items = new MerchItem[count];
            for (int i = 0; i < count; i++)
            {
                items[i] = GetBag();
            }

            return items;
        }

        #endregion
        
        #region Pen

        public static MerchItem GetPen()
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
        
        public static MerchItem[] GetPens(int count)
        {
            MerchItem[] items = new MerchItem[count];
            for (int i = 0; i < count; i++)
            {
                items[i] = GetPen();
            }

            return items;
        }

        #endregion
        
        #region Socks

        public static MerchItem GetSocks()
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
        
        public static MerchItem[] GetSocks(int count)
        {
            MerchItem[] items = new MerchItem[count];
            for (int i = 0; i < count; i++)
            {
                items[i] = GetSocks();
            }

            return items;
        }

        #endregion
    }
}