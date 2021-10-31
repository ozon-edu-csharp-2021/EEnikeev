using OzonEdu.MerchandiseService.Models.Interfaces;

namespace OzonEdu.MerchandiseService.Models.Mocks
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