namespace OzonEdu.merchandise_service.Infrastructure.Models.Interfaces
{
    /// <summary> Некий мерч </summary>
    public interface IMerchItem
    {
        /// <summary> Идентификатор мерча </summary>
        long Id { get; set; }

        /// <summary> Название мерча </summary>
        string Name { get; set; }
        
        /// <summary> Мерч выдан </summary>
        bool IsIssued { get; set; }
    }
}