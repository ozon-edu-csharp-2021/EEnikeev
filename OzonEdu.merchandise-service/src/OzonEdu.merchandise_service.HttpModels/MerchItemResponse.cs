namespace OzonEdu.merchandise_service.HttpModels
{
    /// <summary> Модель ответа </summary>
    public class MerchItemResponse
    {
        /// <summary> Идентификатор мерча </summary>
        public long Id { get; set; }
        
        /// <summary> Название мерча </summary>
        public string Name { get; set; }
    }
}