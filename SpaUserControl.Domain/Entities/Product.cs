using SpaUserControl.Common.Resources;
using SpaUserControl.Common.Validation;
using System;

namespace SpaUserControl.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public Guid ProductGuid{ get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        protected Product()
        {

        }

        public Product(string title, string description, decimal price)
        {
            Title = title;
            Description = description;
            Price = price;

            Validate();
        }

        public void ChangeData(string description, decimal price)
        {
            Description = description;
            Price = price;

            Validate();
        }


        public void Validate()
        {
            AssertionConcern.AssertArgumentNotEmpty(Title, Notifications.IsEmpty);
            AssertionConcern.AssertArgumentNotEmpty(Description, Notifications.IsEmpty);
            AssertionConcern.AssertArgumentNotNull(Price, Notifications.IsZero);
        }
    }

}