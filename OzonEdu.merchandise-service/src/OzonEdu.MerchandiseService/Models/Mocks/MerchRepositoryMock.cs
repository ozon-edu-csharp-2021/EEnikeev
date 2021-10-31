using System.Collections.Generic;
using OzonEdu.merchandise_service.Infrastructure.Models.Interfaces;

namespace OzonEdu.merchandise_service.Models.Mocks
{
    /// <summary> Имитация какого-то хранилища с мерчами </summary>
    public class MerchRepositoryMock
    {
        /// <summary> Список мерчей </summary>
        private Dictionary<long, IMerchItem> _items;

        
        public MerchRepositoryMock()
        {
            
            _items = new Dictionary<long, IMerchItem>();

            var merch = new MerchItemMock("Футболка");
            _items.Add(merch.Id, merch);
            
            merch = new MerchItemMock("Толстовка"){IsIssued = true};
            _items.Add(merch.Id, merch);
            
            merch = new MerchItemMock("Кепка");
            _items.Add(merch.Id, merch);
            
            merch = new MerchItemMock("Сумка"){IsIssued = true};
            _items.Add(merch.Id, merch);
            
            merch= new MerchItemMock("Ручка");
            _items.Add(merch.Id, merch);
        }

        
        public IMerchItem? GetMerchById(long id)
        {
            if (_items.ContainsKey(id)) return _items[id];
            return null;
        }

        
        public bool? GetMerchIsIssuedInfo(long id)
        {
            if (_items.ContainsKey(id)) return _items[id].IsIssued;
            return null;
        }

        
        public bool? IssueMerch(long id)
        {
            if (!_items.ContainsKey(id)) return null;

            // Если уже выдан, то false
            if (_items[id].IsIssued) return false;
            
            // Если еще не выдан, то выдаем
            _items[id].IsIssued = true;
            return true;
        }
        
        
        
    }
}