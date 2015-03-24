using System;
using System.Collections.Generic;
using SpaUserControl.Common.Resources;
using SpaUserControl.Common.Validation;

namespace SpaUserControl.Domain.Entities
{
    public class Order
    {
        protected Order()
        {
        }

        public Order(User user, Item item)
        {
            Items = new List<Item>();
            Date = DateTime.Now;
            OrderGuid = new Guid();
            User = user;

            AddToItems(item);
            UpdateTotal(item);

            Validate();
        }

        public int OrderId { get; set; }
        public Guid OrderGuid { get; set; }
        public DateTime Date { get; private set; }
        public decimal Total { get; private set; }
        public List<Item> Items { get; private set; }
        public User User { get; set; }

        public void AddToItems(Item item)
        {
            Items.Add(item);
            UpdateTotal(item);

            Validate();
        }

        private void UpdateTotal(Item item)
        {
            Total = Total + (item.Product.Price*item.Amont);

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