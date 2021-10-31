using OzonEdu.merchandise_service.Infrastructure.Models.Interfaces;

namespace OzonEdu.merchandise_service.Models.Mocks
{
    public class MerchItemMock : IMerchItem
    {
        private static long _id;
        
        public long Id { get; set; }
        
        public string Name { get; set; }
        
        /// <summary> Мерч выдан </summary>
        public bool IsIssued { get; set; }

        public MerchItemMock(string name)
        {
            this.Id = _id++;
            this.Name = name;
        }
    }
}