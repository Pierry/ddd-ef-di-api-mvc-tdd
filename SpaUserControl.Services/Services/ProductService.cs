using SpaUserControl.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaUserControl.Domain.Entities;

namespace SpaUserControl.Services.Services
{
    public class ProductService : IProductService
    {
        public void ChangeData(string description, decimal price)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Get(int page)
        {
            throw new NotImplementedException();
        }

        public Product GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
