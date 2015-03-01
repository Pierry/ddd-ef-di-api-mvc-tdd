using SpaUserControl.Common.Resources;
using SpaUserControl.Common.Validation;
using System;

namespace SpaUserControl.Domain.Entities
{
    public class Item
    {
        public int ItemId { get; set; }
        public Guid ItemGuid { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
        public int Amont { get; set; }
        public decimal Total { get; private set; }

        protected Item()
        {

        }

        public Item(Product product, Order order, int amont)
        {
            Product = product;
            Order = order;
            Amont = amont;
            Total = Product.Price * amont;

            Validate();
        }

        public void ChangeAmont(int amont)
        {
            Amont = amont;

            Validate();
        }

        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(Product, Notifications.NotNull);
            AssertionConcern.AssertArgumentNotNull(Order, Notifications.NotNull);
            AssertionConcern.AssertArgumentNotZero(Amont, Notifications.IsZero);
        }
    }
}
