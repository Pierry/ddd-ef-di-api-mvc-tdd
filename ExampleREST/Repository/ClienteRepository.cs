using System.Collections.Generic;
using System.Linq;
using ExampleREST.Models;

namespace ExampleREST.Repository
{
    public class ClienteRepository
    {
        private readonly DomainContext _domainContext = new DomainContext();

        public bool Add(ClienteModel cliente)
        {
            var c = new Table
                    {
                        Id = cliente.IdCliente,
                        Nome = cliente.Nome
                    };
            _domainContext.Table.Add(c);
            _domainContext.SaveChanges();
            return true;
        }

        public bool Uodate(ClienteModel cliente)
        {
            Table cli = _domainContext.Table.FirstOrDefault(c => c.Id == cliente.IdCliente);
            if (cli != null)
            {
                cli.Nome = cliente.Nome;
                _domainContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<ClienteModel> Get()
        {
            var clientes = from i in _domainContext.Table
                select new ClienteModel
                       {
                           IdCliente = i.Id,
                           Nome = i.Nome
                       };
            if (clientes.Any())
            {
                return clientes.ToList();
            }
            return null;
        }


        public ClienteModel Get(int id)
        {
            Table cliente = _domainContext.Table.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                return null;
            }
            var clienteTratado = new ClienteModel
                                 {
                                     IdCliente = cliente.Id,
                                     Nome = cliente.Nome
                                 };
            return clienteTratado;
        }

        public bool Remove(int id)
        {
            Table cliente = _domainContext.Table.FirstOrDefault(c => c.Id == id);
            if (cliente != null)
            {
                _domainContext.Table.Remove(cliente);
                _domainContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}