using SpaUserControl.Common.Resources;
using SpaUserControl.Common.Validation;
using System;
using System.Collections.Generic;

namespace SpaUserControl.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public Guid OrderGuid { get; set; }
        public DateTime Date { get; private set; }
        public decimal Total { get; private set; }
        public List<Item> Items { get; private set; }
        public User User { get; set; }

        protected Order()
        {

        }

        public Order(User user, Item item)
        {
            Date = DateTime.Now;            
            OrderGuid = new Guid();
            User = user;

            AddToItems(item);            
            UpdateTotal(item);

            Validate();
        }

        public void AddToItems(Item item)
        {
            Total = Total + (item.Product.Price * item.Qtd);
            Items.Add(item);

            Validate();
        }
        
        private void UpdateTotal(Item item)
        {
            Total = Total + (item.Product.Price * item.Qtd);

            Validate();
        }

        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(Total, Notifications.NotNull);
            AssertionConcern.AssertArgumentNotZero(Total, Notifications.IsZero);
            AssertionConcern.AssertArgumentNotNull(Items, Notifications.NotNull);
            AssertionConcern.AssertArgumentNotNull(User, Notifications.NotNull);
        }

    }
}
