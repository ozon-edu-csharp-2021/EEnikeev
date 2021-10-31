namespace OzonEdu.MerchandiseService.Models.Interfaces
{
   public interface IMerchItem
    {
        long Id { get; set; }

        string Name { get; set; }
        
        bool IsIssued { get; set; }
    }
}