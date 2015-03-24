using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaUserControl.Domain.Entities;

namespace Tests.Domain
{
    [TestClass]
    public class OrderTest
    {
        private readonly Order _order;

        public OrderTest()
        {
            _order = new Order(
                new User(1,
                    new Guid(),
                    "Pierry Borges",
                    "pieerry@gmail.com"
                    ),
                new Item(
                    new Product(
                        "Mouse Microsoft",
                        "Microsoft Wireless Mouse",
                        new decimal(20.00)),
                    2
                    ));
        }

        [TestMethod]
        public void AddToItems()
        {
            _order.AddToItems(new Item(
                new Product("iPad Mini", "Apple iPad Mini 32 GB Wifi", new decimal(500.00)), 3));
        }

    }
}