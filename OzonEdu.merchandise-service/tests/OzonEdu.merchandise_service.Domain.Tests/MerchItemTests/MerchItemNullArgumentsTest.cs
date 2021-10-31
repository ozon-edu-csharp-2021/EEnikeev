using System;
using OzonEdu.merchandise_service.Domain.AggregationModels.MerchItemAggregate;
using Xunit;

namespace OzonEdu.merchandise_service.Domain.Tests.MerchItemTests
{
    
    public class MerchItemNullArgumentsTest
    {

        [Fact]
        public void CreateMerchItemWithNullSku()
        {
            // arrange
            
            // act
            var merchItem = new MerchItem(null,
                new Name("name"), 
                new ItemEntity(ItemType.Bag),
                ClothingSize.L,
                new Quantity(10),
                new MinimalQuantity(5),
                "tag");
            // assert
            //Assert.Throws(ArgumentNullException,)

        }
        
        
        
    }
}