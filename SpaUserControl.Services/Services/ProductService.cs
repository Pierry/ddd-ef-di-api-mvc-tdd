using SpaUserControl.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using SpaUserControl.Domain.Entities;
using SpaUserControl.Domain.Interfaces.Repositories;

namespace SpaUserControl.Services.Services
{
    public class ProductService : ServiceBase<Product>, IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> Get(int page)
        {
            var Page = page > 0 ? (page * 20) : page;
            return _productRepository.Get().Skip(page).Take(20);
        }

        public Product GetByGuid(Guid id)
        {
            return _productRepository.Get(id);
        }

        public void Create(string title, string description, decimal price)
        {
            var product = new Product(title, description, price);
            _productRepository.Create(product);
        }

        public void ChangeData(Guid id, string description, decimal price)
        {
            var product = _productRepository.Get(id);
            product.ChangeData(description, price);

            _productRepository.Update(product);
        }

        public void Remove(Guid id)
        {
            var product = _productRepository.Get(id);
            _productRepository.Delete(product);
        }

        public void Dispose()
        {
            _productRepository.Dispose();
        }
        
    }
}
