using System;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Factory;
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
                new EmployeeDateTime(DateTime.Now),
                new EmployeeEmail("employee@ozon.ru"),
                null,
                new MerchIssued(false),
                null));
        }
        
        [Fact]
        public void CreateEmployeeWithNullFirstnameValue()
        {
            Assert.Throws<ArgumentNullException>(() => new Employee(
                100500,
                new EmployeeName(null),
                new EmployeeName("last"),
                new EmployeeDateTime(DateTime.Now),
                new EmployeeEmail("employee@ozon.ru"),
                null,
                new MerchIssued(false),
                null));
        }
        
        [Fact]
        public void CreateEmployeeWithEmptyFirstname()
        {
            Assert.Throws<ArgumentException>(() => new Employee(
                100500,
                new EmployeeName(""),
                new EmployeeName("last"),
                new EmployeeDateTime(DateTime.Now),
                new EmployeeEmail("employee@ozon.ru"),
                null,
                new MerchIssued(false),
                null));
        }
        
        [Fact]
        public void CreateEmployeeWithNullLastName()
        {
            Assert.Throws<ArgumentNullException>(() => new Employee(
                100500,
                new EmployeeName("first"),
                null,
                new EmployeeDateTime(DateTime.Now),
                new EmployeeEmail("employee@ozon.ru"),
                null,
                new MerchIssued(false),
                null));
        }
        
        [Fact]
        public void CreateEmployeeWithNullLastnameValue()
        {
            Assert.Throws<ArgumentNullException>(() => new Employee(
                100500,
                new EmployeeName("first"),
                new EmployeeName(null),
                new EmployeeDateTime(DateTime.Now),
                new EmployeeEmail("employee@ozon.ru"),
                null,
                new MerchIssued(false),
                null));
        }
        
        [Fact]
        public void CreateEmployeeWithEmptyLastname()
        {
            Assert.Throws<ArgumentException>(() => new Employee(
                100500,
                new EmployeeName("first"),
                new EmployeeName(""),
                new EmployeeDateTime(DateTime.Now),
                new EmployeeEmail("employee@ozon.ru"),
                null,
                new MerchIssued(false),
                null));
        }
        
        [Fact]
        public void CreateEmployeeWithNullEmail()
        {
            Assert.Throws<ArgumentNullException>(() => new Employee(
                100500,
                new EmployeeName("first"),
                new EmployeeName("last"),
                new EmployeeDateTime(DateTime.Now),
                null,
                null,
                new MerchIssued(false),
                null));
        }
        
        [Fact]
        public void CreateEmployeeWithEmptyEmail()
        {
            Assert.Throws<ArgumentException>(() => new Employee(
                100500,
                new EmployeeName("first"),
                new EmployeeName("last"),
                new EmployeeDateTime(DateTime.Now),
                new EmployeeEmail(""),
                null,
                new MerchIssued(false),
                null));
        }
        
        [Fact]
        public void CreateEmployeeWithEmailWithoutDog()
        {
            Assert.Throws<ArgumentException>(() => new Employee(
                100500,
                new EmployeeName("first"),
                new EmployeeName("last"),
                new EmployeeDateTime(DateTime.Now),
                new EmployeeEmail("email"),
                null,
                new MerchIssued(false),
                null));
        }
        
        [Fact]
        public void CreateEmployeeWithNullGivenStatus()
        {
            Assert.Throws<ArgumentException>(() => new Employee(
                100500,
                new EmployeeName("first"),
                new EmployeeName("last"),
                new EmployeeDateTime(DateTime.Now),
                new EmployeeEmail("email"),
                null,
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
                new EmployeeDateTime(DateTime.Now),
                new EmployeeEmail("email"),
                null,
                new MerchIssued(true),
                null));
        }
        
        [Fact]
        public void CreateEmployeeWithNullMerchAndGivenDate()
        {
            Assert.Throws<ArgumentException>(() => new Employee(
                100500,
                new EmployeeName("first"),
                new EmployeeName("last"),
                new EmployeeDateTime(DateTime.Now),
                new EmployeeEmail("email"),
                null,
                new MerchIssued(false),
                new EmployeeDateTime(DateTime.Now)));
        }
        
        [Fact]
        public void CreateEmployeeWithTrueGivenMerchAndNullGivenDate()
        {
            Assert.Throws<ArgumentException>(() => new Employee(
                100500,
                new EmployeeName("first"),
                new EmployeeName("last"),
                new EmployeeDateTime(DateTime.Now),
                new EmployeeEmail("email"),
                new EmployeeMerchPack(MerchPackFactory.GetStarterPack(ClothingSize.M)),
                new MerchIssued(true),
                null));
        }

        [Fact]
        public void CreateEmployeeWithFalseGivenMerchAndGivenDate()
        {
            Assert.Throws<ArgumentException>(() => new Employee(
                100500,
                new EmployeeName("first"),
                new EmployeeName("last"),
                new EmployeeDateTime(DateTime.Now),
                new EmployeeEmail("email"),
                new EmployeeMerchPack(MerchPackFactory.GetStarterPack(ClothingSize.M)),
                new MerchIssued(false),
                new EmployeeDateTime(DateTime.Now)));
        }
        
        [Fact]
        public void CheckMerchIsGivenFalse()
        {
            var emp = new Employee(
                100500,
                new EmployeeName("first"),
                new EmployeeName("last"),
                new EmployeeDateTime(DateTime.Now),
                new EmployeeEmail("employee@ozon.ru"),
                null,
                new MerchIssued(false),
                null);

            var pack = MerchPackFactory.GetStarterPack(ClothingSize.M);
            
            Assert.Equal(emp.IsGiven(pack.Id),false);
        }
        
        [Fact]
        public void GiveMerchWhenItIsNotInStock()
        {
            var emp = new Employee(
                100500,
                new EmployeeName("first"),
                new EmployeeName("last"),
                new EmployeeDateTime(DateTime.Now),
                new EmployeeEmail("employee@ozon.ru"),
                null,
                new MerchIssued(false),
                null);

            var pack = MerchPackFactory.GetStarterPack(ClothingSize.M);
            emp.GiveMerch(pack, false);
            Assert.Equal(emp.IsGiven(pack.Id),false);
        }
        
        [Fact]
        public void GiveMerchWhenItIsNotGiven()
        {
            var emp = new Employee(
                100500,
                new EmployeeName("first"),
                new EmployeeName("last"),
                new EmployeeDateTime(DateTime.Now),
                new EmployeeEmail("employee@ozon.ru"),
                null,
                new MerchIssued(false),
                null);

            var pack = MerchPackFactory.GetStarterPack(ClothingSize.M);
            emp.GiveMerch(pack, true);
            Assert.Equal(emp.IsGiven(pack.Id),true);
        }
        
        [Fact]
        public void GiveMerchWhenItIsNotGiven2()
        {
            var emp = new Employee(
                100500,
                new EmployeeName("first"),
                new EmployeeName("last"),
                new EmployeeDateTime(DateTime.Now),
                new EmployeeEmail("employee@ozon.ru"),
                new EmployeeMerchPack(MerchPackFactory.GetStarterPack(ClothingSize.M)),
                new MerchIssued(false),
                null);

            var pack = MerchPackFactory.GetStarterPack(ClothingSize.M);
            emp.GiveMerch(pack, true);
            Assert.Equal(emp.IsGiven(pack.Id),true);
        }

        
        [Fact]
        public void GiveMerchEarlierThanMinYearsBeforeNextIssue()
        {
            var emp = new Employee(
                100500,
                new EmployeeName("first"),
                new EmployeeName("last"),
                new EmployeeDateTime(DateTime.Now),
                new EmployeeEmail("employee@ozon.ru"),
                new EmployeeMerchPack(MerchPackFactory.GetStarterPack(ClothingSize.M)),
                new MerchIssued(true),
                new EmployeeDateTime(DateTime.Now));
            
            var pack = MerchPackFactory.GetStarterPack(ClothingSize.M);
            Assert.Throws<InvalidOperationException>(() => emp.GiveMerch(pack, true));
        }
        
        [Fact]
        public void GiveMerchLaterThanMinYearsBeforeNextIssue()
        {
            var emp = new Employee(
                100500,
                new EmployeeName("first"),
                new EmployeeName("last"),
                new EmployeeDateTime(DateTime.Now),
                new EmployeeEmail("employee@ozon.ru"),
                new EmployeeMerchPack(MerchPackFactory.GetStarterPack(ClothingSize.M)),
                new MerchIssued(true),
                new EmployeeDateTime(DateTime.Now.AddYears(-Employee.MinYearsBeforeNextIssue)));
            
            var pack = MerchPackFactory.GetStarterPack(ClothingSize.M);
            emp.GiveMerch(pack, true);
            Assert.Equal(emp.IsGiven(pack.Id),true);
            
        }
        
        
        
        
    }
}