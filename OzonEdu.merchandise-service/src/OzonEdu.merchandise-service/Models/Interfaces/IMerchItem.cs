namespace OzonEdu.merchandise_service.Infrastructure.Models.Interfaces
{
   public interface IMerchItem
    {
        long Id { get; set; }

        string Name { get; set; }
        
        bool IsIssued { get; set; }
    }
}