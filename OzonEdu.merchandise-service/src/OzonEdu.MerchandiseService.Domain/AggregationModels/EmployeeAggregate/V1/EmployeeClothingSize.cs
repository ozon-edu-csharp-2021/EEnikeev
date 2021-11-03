using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate.V1
{
    public class EmployeeClothingSize : Enumeration
    {
        public static EmployeeClothingSize XS = new EmployeeClothingSize(1, nameof(XS));
        public static EmployeeClothingSize S = new EmployeeClothingSize(2, nameof(S));
        public static EmployeeClothingSize M = new EmployeeClothingSize(3, nameof(M));
        public static EmployeeClothingSize L = new EmployeeClothingSize(4, nameof(L));
        public static EmployeeClothingSize XL = new EmployeeClothingSize(5, nameof(XL));
        public static EmployeeClothingSize XXL = new EmployeeClothingSize(6, nameof(XXL));
        
        public EmployeeClothingSize(int id, string name) : base(id, name)
        {
        }

        
    }
}