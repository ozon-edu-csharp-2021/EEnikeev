using System;
using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests.MerchPackTests
{
    public class MerchPackTest
    {
        [Fact]
        public void CreateMerchPackWithNullName()
        {
            Assert.Throws<ArgumentNullException>(() => 
                new MerchPack(1, null, new MerchItemList(new List<MerchItem>())));
        }
        
        [Fact]
        public void CreateMerchPackWithNullStringInName()
        {
            Assert.Throws<ArgumentNullException>(() => 
                new MerchPack(1, new MerchPackName(null), new MerchItemList(new List<MerchItem>())));
        }
        
        [Fact]
        public void CreateMerchPackWithEmptyName()
        {
            Assert.Throws<ArgumentException>(() => 
                new MerchPack(1, new MerchPackName(""), new MerchItemList(new List<MerchItem>())));
        }
        
        [Fact]
        public void CreateMerchPackWithNullItems()
        {
            Assert.Throws<ArgumentNullException>(() => 
                new MerchPack(1, new MerchPackName("pack"), null));
        }
        
        [Fact]
        public void CreateMerchPackWithNullValueInItems()
        {
            Assert.Throws<ArgumentNullException>(() => 
                new MerchPack(1, new MerchPackName(null), new MerchItemList(null)));
        }
    }
}