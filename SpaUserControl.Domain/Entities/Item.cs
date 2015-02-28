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
        public int Qtd { get; set; }
        public decimal Total { get; private set; }

        protected Item()
        {

        }

        public Item(Product product, Order order, int qtd)
        {
            Product = product;
            Order = order;
            Qtd = qtd;
            Total = Product.Price * qtd;

            Validate();
        }

        public void ChangeProduct(Product product, int qtd)
        {
            Product = product;
            Qtd = qtd;
            Total = Product.Price * qtd;

            Validate();
        }

        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(Product, Notifications.NotNull);
            AssertionConcern.AssertArgumentNotNull(Order, Notifications.NotNull);
            AssertionConcern.AssertArgumentNotZero(Qtd, Notifications.IsZero);
        }
    }
}
