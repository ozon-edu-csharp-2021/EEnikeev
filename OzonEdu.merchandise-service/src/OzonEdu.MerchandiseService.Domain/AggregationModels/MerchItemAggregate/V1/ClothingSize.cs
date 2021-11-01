using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate.V1
{
    /// <summary> Размер одежды </summary>
    public class ClothingSize : Enumeration
    {
        public static ClothingSize XS = new ClothingSize(1, nameof(XS));
        public static ClothingSize S = new ClothingSize(2, nameof(S));
        public static ClothingSize M = new ClothingSize(3, nameof(M));
        public static ClothingSize L = new ClothingSize(4, nameof(L));
        public static ClothingSize XL = new ClothingSize(5, nameof(XL));
        public static ClothingSize XXL = new ClothingSize(6, nameof(XXL));
        
        public ClothingSize(int id, string name) : base(id, name)
        {
        }
    }
}