namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.DtoModels
{
    public class MerchPackItemsTable
    {
        public int Id { get; set; }
        
        public int PackId { get; set; }
        
        public long MerchItemId { get; set; }
        
        public int Quantity { get; set; }
    }
}