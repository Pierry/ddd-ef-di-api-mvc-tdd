using SpaUserControl.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using SpaUserControl.Domain.Entities;
using SpaUserControl.Domain.Interfaces.Repositories;
using System.Linq;

namespace SpaUserControl.Services.Services
{
    public class ItemService : IItemService
    {
        private IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public IEnumerable<Item> Get(int page)
        {
            var Page = page > 0 ? (page * 20) : page;
            return _itemRepository.Get().Skip(page).Take(20);
        }

        public Item GetByGuid(Guid id)
        {
            return _itemRepository.Get(id);
        }

        public void Create(Product product, Order order, int amont)
        {
            var item = new Item(product, order, amont);
            _itemRepository.Create(item);
        }

        public void ChangeAmont(Guid id, int newAmont)
        {
            var item = _itemRepository.Get(id);
            item.ChangeAmont(newAmont);

            _itemRepository.Update(item);
        }
        
        public void Delete(Guid id)
        {
            var item = _itemRepository.Get(id);
            _itemRepository.Delete(item);
        }

        public void Dispose()
        {
            _itemRepository.Dispose();
        }
    }
}
