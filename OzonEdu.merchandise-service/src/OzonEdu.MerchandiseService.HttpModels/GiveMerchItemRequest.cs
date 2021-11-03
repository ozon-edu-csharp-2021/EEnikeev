namespace OzonEdu.MerchandiseService.HttpModels
{
    public class GiveMerchItemRequest
    {
        public int EmployeeId { get; set; }
        
        public int MerchId { get; set; }
        
        public int SizeId { get; set; }
    }
}