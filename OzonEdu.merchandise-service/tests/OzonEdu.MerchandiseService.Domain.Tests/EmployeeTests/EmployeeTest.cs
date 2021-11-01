using System;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests.EmployeeTests
{
    public class EmployeeTest
    {
        [Fact]
        public void CreateEmployeeWithNullId()
        {
            Assert.Throws<ArgumentNullException>(() => new Employee(
                null,
                new EmployeeName("first"),
                new EmployeeName("last"),
                new PositionEntity(Position.Manager),
                new MerchIssued(false)));
        }
        
        [Fact]
        public void CreateEmployeeWithNullFirstname()
        {
            Assert.Throws<ArgumentNullException>(() => new Employee(
                new EmployeeId(100500),
                null,
                new EmployeeName("last"),
                new PositionEntity(Position.Manager),
                new MerchIssued(false)));
        }
        
        [Fact]
        public void CreateEmployeeWithNullFirstnameValue()
        {
            Assert.Throws<ArgumentNullException>(() => new Employee(
                new EmployeeId(100500),
                new EmployeeName(null),
                new EmployeeName("last"),
                new PositionEntity(Position.Manager),
                new MerchIssued(false)));
        }
        
        [Fact]
        public void CreateEmployeeWithEmptyFirstname()
        {
            Assert.Throws<ArgumentException>(() => new Employee(
                new EmployeeId(100500),
                new EmployeeName(""),
                new EmployeeName("last"),
                new PositionEntity(Position.Manager),
                new MerchIssued(false)));
        }
        
        [Fact]
        public void CreateEmployeeWithNullLastName()
        {
            Assert.Throws<ArgumentNullException>(() => new Employee(
                new EmployeeId(100500),
                new EmployeeName("first"),
                null,
                new PositionEntity(Position.Manager),
                new MerchIssued(false)));
        }
        
        [Fact]
        public void CreateEmployeeWithNullLastnameValue()
        {
            Assert.Throws<ArgumentNullException>(() => new Employee(
                new EmployeeId(100500),
                new EmployeeName("first"),
                new EmployeeName(null),
                new PositionEntity(Position.Manager),
                new MerchIssued(false)));
        }
        
        [Fact]
        public void CreateEmployeeWithEmptyLastname()
        {
            Assert.Throws<ArgumentException>(() => new Employee(
                new EmployeeId(100500),
                new EmployeeName("first"),
                new EmployeeName(""),
                new PositionEntity(Position.Manager),
                new MerchIssued(false)));
        }
        
        [Fact]
        public void CreateEmployeeWithNullPosition()
        {
            Assert.Throws<ArgumentNullException>(() => new Employee(
                new EmployeeId(100500),
                new EmployeeName("first"),
                new EmployeeName("last"),
                null,
                new MerchIssued(false)));
        }
        
        [Fact]
        public void CreateEmployeeWithNullPositionType()
        {
            Assert.Throws<ArgumentNullException>(() => new Employee(
                new EmployeeId(100500),
                new EmployeeName("first"),
                new EmployeeName("last"),
                new PositionEntity(null),
                new MerchIssued(false)));
        }
        
        [Fact]
        public void CreateEmployeeWithNullMerchIssue()
        {
            Assert.Throws<ArgumentNullException>(() => new Employee(
                new EmployeeId(100500),
                new EmployeeName("first"),
                new EmployeeName("last"),
                new PositionEntity(Position.Manager),
                null));
        }
    }
}