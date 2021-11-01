using System;
using FluentAssertions;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate.V1;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests.MerchItemTests
{
    public class MerchItemTest
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
        public void CreateMerchItemWithNullNameValue()
        {
            Assert.Throws<ArgumentNullException>(() => new MerchItem(
                new Sku(100500),
                new Name(null),
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
            Assert.Throws<NegativeQuantityException>(() => new MerchItem(
                new Sku(100500),
                new Name("some tshirt"),
                new ItemEntity(ItemType.TShirt),
                ClothingSize.L,
                new Quantity(-10),
                new MinimalQuantity(5),
                new Tag("some tag")));
        }
        
        [Fact]
        public void CreateMerchItemWithNegativeMinimalQuantity()
        {
            Assert.Throws<NegativeQuantityException>(() => new MerchItem(
                new Sku(100500),
                new Name("some tshirt"),
                new ItemEntity(ItemType.TShirt),
                ClothingSize.L,
                new Quantity(10),
                new MinimalQuantity(-5),
                new Tag("some tag")));
        }

        [Fact]
        public void IncreaseMerchItemQuantitySuccess()
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
            Assert.Throws<NegativeQuantityException>(() => item.IncreaseQuantity(valueToIncrease));

        }
        
        [Fact]
        public void GiveOutMerchItemNegativeQuantity()
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
            var valueToGiveOut = -5;

            // Assert
            Assert.Throws<NegativeQuantityException>(() => item.GiveOutItems(valueToGiveOut));

        }
        
        [Fact]
        public void GiveOutMerchItemQuantityMoreThanCurrentQuantity()
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
            var valueToGiveOut = 20;

            // Assert
            Assert.Throws<NotEnoughQuantityException>(() => item.GiveOutItems(valueToGiveOut));

        }
        
        [Fact]
        public void GiveOutMerchItemQuantitySuccess()
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
            var valueToGiveOut = 5;
            item.GiveOutItems(valueToGiveOut);
                
            // Assert
            item.Quantity.Value.Should().Be(5, $"because we substract {quantity} and {valueToGiveOut}");

        }
        
        [Fact]
        public void SetClothesWithNullClothingSize()
        {
           Assert.Throws<ClothingSizeException>(() => new MerchItem(
                new Sku(100500),
                new Name("some tshirt"),
                new ItemEntity(ItemType.TShirt),
                null,
                new Quantity(10),
                new MinimalQuantity(5),
                new Tag("some tag")));

        }
        
        [Fact]
        public void SetClothingSizeToItemWithoutClothingSize()
        {
            Assert.Throws<ClothingSizeException>(() => new MerchItem(
                new Sku(100500),
                new Name("some bag"),
                new ItemEntity(ItemType.Bag),
                ClothingSize.M, 
                new Quantity(10),
                new MinimalQuantity(5),
                new Tag("some tag")));
        }

    }
}