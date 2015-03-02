using Microsoft.Practices.Unity;
using SpaUserControl.Data.Repositories;
using SpaUserControl.Domain.Entities;
using SpaUserControl.Domain.Interfaces.Repositories;
using SpaUserControl.Domain.Interfaces.Services;
using SpaUserControl.Services.Services;

namespace SpaUserControl.WebApi.Resolver
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserService, UserService>(new HierarchicalLifetimeManager());
            container.RegisterType<IProductRepository, ProductRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IProductService, ProductService>(new HierarchicalLifetimeManager());

            container.RegisterType<User, User>(new HierarchicalLifetimeManager());
        }
    }
}