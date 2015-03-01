using SpaUserControl.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaUserControl.Domain.Entities;
using SpaUserControl.Domain.Interfaces.Repositories;

namespace SpaUserControl.Services.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order> Get(int page)
        {
            var Page = page > 0 ? (page * 20) : page;
            return _orderRepository.Get().Skip(page).Take(20);
        }

        public Order GetByGuid(Guid id)
        {
            return _orderRepository.Get(id);
        }

        public IEnumerable<Order> GetByUserGuid(Guid id)
        {
            return _orderRepository.GetByUserGuid(id);
        }

        public void AddItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void Create(User user, Item item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

       
    }
}
