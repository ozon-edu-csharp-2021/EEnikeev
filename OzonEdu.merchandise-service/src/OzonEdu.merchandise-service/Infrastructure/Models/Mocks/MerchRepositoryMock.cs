using System.Collections.Generic;
using OzonEdu.merchandise_service.Infrastructure.Models.Interfaces;

namespace OzonEdu.merchandise_service.Models.Mocks
{
    /// <summary> Имитация какого-то хранилища с мерчами </summary>
    public class MerchRepositoryMock
    {
        /// <summary> Список мерчей </summary>
        private Dictionary<long, MerchItemMock> _items;

        public MerchRepositoryMock()
        {
            // наполняем список для проверки
            _items = new Dictionary<long, MerchItemMock>();

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

        /// <summary> Возвращает мерч по id </summary>
        /// <param name="id"> id мерча </param>
        /// <returns> IMerchItem? </returns>
        public MerchItemMock GetMerchById(long id)
        {
            if (_items.ContainsKey(id)) return _items[id];
            return null;
        }

        /// <summary> Возвращает информацию о выдаче мерча </summary>
        /// <param name="id"> id мерча </param>
        /// <returns> bool? </returns>
        public bool? GetMerchIsIssuedInfo(long id)
        {
            if (_items.ContainsKey(id)) return _items[id].IsIssued;
            return null;
        }

        /// <summary> Выдает мерч </summary>
        /// <param name="id"> id мерча </param>
        /// <returns> bool? </returns>
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