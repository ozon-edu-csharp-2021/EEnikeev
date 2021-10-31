using System;
using FluentAssertions;
using OzonEdu.MerchandiseService.Domain.AggregationModels;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests.MerchItemTests
{
    public class MerchItemNullArgumentsTest
    {

        [Fact]
        public void CreateMerchItemWithNullSku()
        {
            Assert.Throws<ArgumentNullException>(() => new MerchItem(
                null,
                new Name("name"),
                new ItemEntity(ItemType.Bag),
                ClothingSize.L,
                new Quantity(10),
                new MinimalQuantity(5),
                new Tag("some tag")));
        }
        
        [Fact]
        public void CreateMerchItemWithNullName()
        {
            Assert.Throws<ArgumentNullException>(() => new MerchItem(
                new Sku(100500),
                null,
                new ItemEntity(ItemType.Bag),
                ClothingSize.L,
                new Quantity(10),
                new MinimalQuantity(5),
                new Tag("some tag")));
        }
        
        [Fact]
        public void CreateMerchItemWithEmptyName()
        {
            Assert.Throws<ArgumentException>(() => new MerchItem(
                new Sku(100500),
                new Name(""),
                new ItemEntity(ItemType.Bag),
                ClothingSize.L,
                new Quantity(10),
                new MinimalQuantity(5),
                new Tag("some tag")));
        }
        
        [Fact]
        public void CreateMerchItemWithNullType()
        {
            Assert.Throws<ArgumentNullException>(() => new MerchItem(
                new Sku(100500),
                new Name("some name"),
                null,
                ClothingSize.L,
                new Quantity(10),
                new MinimalQuantity(5),
                new Tag("some tag")));
        }
        
        [Fact]
        public void CreateMerchItemWithNullItemType()
        {
            Assert.Throws<ArgumentNullException>(() => new MerchItem(
                new Sku(100500),
                new Name("some name"),
                new ItemEntity(null),
                ClothingSize.L,
                new Quantity(10),
                new MinimalQuantity(5),
                new Tag("some tag")));
        }
        
        [Fact]
        public void CreateMerchItemWithNullQuantity()
        {
            Assert.Throws<ArgumentNullException>(() => new MerchItem(
                new Sku(100500),
                new Name("some tshirt"),
                new ItemEntity(ItemType.TShirt),
                ClothingSize.L,
                null,
                new MinimalQuantity(5),
                new Tag("some tag")));
        }
        
        [Fact]
        public void CreateMerchItemWithNegativeQuantity()
        {
            Assert.Throws<ArgumentException>(() => new MerchItem(
                new Sku(100500),
                new Name("some tshirt"),
                new ItemEntity(ItemType.TShirt),
                ClothingSize.L,
                new Quantity(-10),
                new MinimalQuantity(5),
                new Tag("some tag")));
        }

        [Fact]
        public void IncreaseMerchItemQuantity()
        {
            // Arrange
            int quantity = 10;
            
            var item = new MerchItem(
                new Sku(100500),
                new Name("some tshirt"),
                new ItemEntity(ItemType.TShirt),
                ClothingSize.L,
                new Quantity(quantity),
                new MinimalQuantity(5),
                new Tag("some tag"));
            // Act

            var valueToIncrease = 10;

            item.IncreaseQuantity(valueToIncrease);

            // Assert
            item.Quantity.Value.Should().Be(20, $"because we sum {quantity} and {valueToIncrease}");

        }
        
        [Fact]
        public void IncreaseMerchItemNegativeQuantity()
        {
            // Arrange
            int quantity = 10;
            
            var item = new MerchItem(
                new Sku(100500),
                new Name("some tshirt"),
                new ItemEntity(ItemType.TShirt),
                ClothingSize.L,
                new Quantity(quantity),
                new MinimalQuantity(5),
                new Tag("some tag"));
            // Act

            var valueToIncrease = -10;

            // Assert
            Assert.Throws<ArgumentException>(() => item.IncreaseQuantity(valueToIncrease));

        }

    }
}