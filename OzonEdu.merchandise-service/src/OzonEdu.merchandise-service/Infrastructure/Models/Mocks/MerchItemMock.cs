using OzonEdu.merchandise_service.Infrastructure.Models.Interfaces;

namespace OzonEdu.merchandise_service.Models.Mocks
{
    /// <summary> Некий мерч </summary>
    public class MerchItemMock : IMerchItem
    {
        // генератор id
        private static long _id;
        
        /// <summary> Идентификатор мерча </summary>
        public long Id { get; set; }
        
        /// <summary> Название мерча </summary>
        public string Name { get; set; }
        
        /// <summary> Мерч выдан </summary>
        public bool IsIssued { get; set; }

        /// <summary> Создает экземпляр типа MerchItemMock </summary>
        /// <param name="name"> Имя мерча </param>
        public MerchItemMock(string name)
        {
            this.Id = _id++;
            this.Name = name;
        }
    }
}