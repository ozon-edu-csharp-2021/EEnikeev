using System;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate.V1;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate.V1;
using OzonEdu.MerchandiseService.Domain.Factory;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests.EmployeeTests
{
    public class EmployeeTest
    {
        
        
        [Fact]
        public void CreateEmployeeWithNullFirstname()
        {
            Assert.Throws<ArgumentNullException>(() => new Employee(
                100500,
                null,
                new EmployeeName("last"),
                new PositionEntity(Position.Manager),
                new EmployeeEmail("employee@ozon.ru"),
                null,
                new MerchIssued(false)));
        }
        
        [Fact]
        public void CreateEmployeeWithNullFirstnameValue()
        {
            Assert.Throws<ArgumentNullException>(() => new Employee(
                100500,
                new EmployeeName(null),
                new EmployeeName("last"),
                new PositionEntity(Position.Manager),
                new EmployeeEmail("employee@ozon.ru"),
                null,
                new MerchIssued(false)));
        }
        
        [Fact]
        public void CreateEmployeeWithEmptyFirstname()
        {
            Assert.Throws<ArgumentException>(() => new Employee(
                100500,
                new EmployeeName(""),
                new EmployeeName("last"),
                new PositionEntity(Position.Manager),
                new EmployeeEmail("employee@ozon.ru"),
                null,
                new MerchIssued(false)));
        }
        
        [Fact]
        public void CreateEmployeeWithNullLastName()
        {
            Assert.Throws<ArgumentNullException>(() => new Employee(
                100500,
                new EmployeeName("first"),
                null,
                new PositionEntity(Position.Manager),
                new EmployeeEmail("employee@ozon.ru"),
                null,
                new MerchIssued(false)));
        }
        
        [Fact]
        public void CreateEmployeeWithNullLastnameValue()
        {
            Assert.Throws<ArgumentNullException>(() => new Employee(
                100500,
                new EmployeeName("first"),
                new EmployeeName(null),
                new PositionEntity(Position.Manager),
                new EmployeeEmail("employee@ozon.ru"),
                null,
                new MerchIssued(false)));
        }
        
        [Fact]
        public void CreateEmployeeWithEmptyLastname()
        {
            Assert.Throws<ArgumentException>(() => new Employee(
                100500,
                new EmployeeName("first"),
                new EmployeeName(""),
                new PositionEntity(Position.Manager),
                new EmployeeEmail("employee@ozon.ru"),
                null,
                new MerchIssued(false)));
        }
        
        [Fact]
        public void CreateEmployeeWithNullPosition()
        {
            Assert.Throws<ArgumentNullException>(() => new Employee(
                100500,
                new EmployeeName("first"),
                new EmployeeName("last"),
                null,
                new EmployeeEmail("employee@ozon.ru"),
                null,
                new MerchIssued(false)));
        }
        
        [Fact]
        public void CreateEmployeeWithNullPositionType()
        {
            Assert.Throws<ArgumentNullException>(() => new Employee(
                100500,
                new EmployeeName("first"),
                new EmployeeName("last"),
                new PositionEntity(null),
                new EmployeeEmail("employee@ozon.ru"),
                null,
                new MerchIssued(false)));
        }
        
        [Fact]
        public void CreateEmployeeWithNullEmail()
        {
            Assert.Throws<ArgumentNullException>(() => new Employee(
                100500,
                new EmployeeName("first"),
                new EmployeeName("last"),
                new PositionEntity(Position.Manager),
                null,
                null,
                new MerchIssued(false)));
        }
        
        [Fact]
        public void CreateEmployeeWithEmptyEmail()
        {
            Assert.Throws<ArgumentException>(() => new Employee(
                100500,
                new EmployeeName("first"),
                new EmployeeName("last"),
                new PositionEntity(Position.Manager),
                new EmployeeEmail(""),
                null,
                new MerchIssued(false)));
        }
        
        [Fact]
        public void CreateEmployeeWithEmailWithoutDog()
        {
            Assert.Throws<ArgumentException>(() => new Employee(
                100500,
                new EmployeeName("first"),
                new EmployeeName("last"),
                new PositionEntity(Position.Manager),
                new EmployeeEmail("email"),
                null,
                new MerchIssued(false)));
        }
        
        [Fact]
        public void CreateEmployeeWithNullGivenStatus()
        {
            Assert.Throws<ArgumentException>(() => new Employee(
                100500,
                new EmployeeName("first"),
                new EmployeeName("last"),
                new PositionEntity(Position.Manager),
                new EmployeeEmail("email"),
                null,
                null));
        }
        
        [Fact]
        public void CreateEmployeeWithNullMerchAndTrueGivenStatus()
        {
            Assert.Throws<ArgumentException>(() => new Employee(
                100500,
                new EmployeeName("first"),
                new EmployeeName("last"),
                new PositionEntity(Position.Manager),
                new EmployeeEmail("email"),
                null,
                new MerchIssued(true)));
        }
        
        
        [Fact]
        public void CheckMerchIsGivenFalse()
        {
            var emp = new Employee(
                100500,
                new EmployeeName("first"),
                new EmployeeName("last"),
                new PositionEntity(Position.Manager),
                new EmployeeEmail("employee@ozon.ru"),
                null,
                new MerchIssued(false));

            var pack = MerchPackFactory.GetStarterPack(ClothingSize.M);
            
            Assert.Equal(emp.IsGiven(pack.Id),false);
        }
        
        [Fact]
        public void CheckMerchIsNotGivenIfIsNotStock()
        {
            var emp = new Employee(
                100500,
                new EmployeeName("first"),
                new EmployeeName("last"),
                new PositionEntity(Position.Manager),
                new EmployeeEmail("employee@ozon.ru"),
                null,
                new MerchIssued(false));

            var pack = MerchPackFactory.GetStarterPack(ClothingSize.M);
            emp.GiveMerch(pack, false);
            Assert.Equal(emp.IsGiven(pack.Id),false);
        }
        
        [Fact]
        public void CheckMerchIsGivenTrue()
        {
            var emp = new Employee(
                100500,
                new EmployeeName("first"),
                new EmployeeName("last"),
                new PositionEntity(Position.Manager),
                new EmployeeEmail("employee@ozon.ru"),null,
                new MerchIssued(false));

            var pack = MerchPackFactory.GetStarterPack(ClothingSize.M);
            emp.GiveMerch(pack, true);
            Assert.Equal(emp.IsGiven(pack.Id),true);
        }
        
    }
}