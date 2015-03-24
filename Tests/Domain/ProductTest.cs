using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaUserControl.Domain.Entities;

namespace Tests.Domain
{
    [TestClass]
    public class ProductTest
    {
        private readonly Product _product;

        public ProductTest()
        {
            _product = new Product("Keyboard", "Microsoft Keyboard", new decimal(39.00));
        }

        [TestMethod]
        public void ChangeData()
        {
            _product.ChangeData("Avell Keyboard", new decimal(32.00));
        }
    }
}