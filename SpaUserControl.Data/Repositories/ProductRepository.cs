using SpaUserControl.Domain.Entities;
using SpaUserControl.Domain.Interfaces.Repositories;

namespace SpaUserControl.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
    }
}
