namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.DtoModels
{
    public class MerchItem
    {
        public long Id { get; set; }
        
        public long SkuId { get; set; }
        
        public string Name { get; set; }
        
        public int ClothingSizeId { get; set; }

    }
}