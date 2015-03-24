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
        public int OrderId { get; private set; }
        public int Amont { get; set; }
        public decimal Total { get; private set; }

        protected Item() { }

        public Item(Product product, int amont)
        {
            Product = product;
            Amont = amont;
            Total = Product.Price * amont;

            Validate();
        }

        public void SetOrderId(int orderId)
        {
            OrderId = orderId;
        }

        public void ChangeAmont(int amont)
        {
            Amont = amont;

            Validate();
        }

        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(Product, Notifications.NotNull);
            AssertionConcern.AssertArgumentNotZero(Amont, Notifications.IsZero);
        }
    }
}
