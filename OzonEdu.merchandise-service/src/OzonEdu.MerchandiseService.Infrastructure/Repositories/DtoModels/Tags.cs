namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.DtoModels
{
    public class Tags
    {
        public long Id { get; set; }
        
        public long MerchItemId { get; set; }
        
        public string Tag { get; set; }
    }
}