using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExampleREST.Models;
using ExampleREST.Repository;

namespace ExampleREST.Controllers
{
    public class ClienteController : ApiController
    {
        private readonly ClienteRepository _clienteRepository = new ClienteRepository();

        // GET api/cliente
        public List<ClienteModel> Get()
        {
            return _clienteRepository.Get();
        }

        // GET api/cliente/5
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage response;
            ClienteModel cliente = _clienteRepository.Get(id);
            if (cliente == null)
            {
                response = new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, cliente);
            }
            return response;
        }

        // POST api/cliente
        public HttpResponseMessage Post(ClienteModel cliente)
        {
            HttpError error;
            if (ModelState.IsValid)
            {
                if (!_clienteRepository.Add(cliente))
                {
                    error = new HttpError("Erro na atualização");
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, error);
                }
                return Request.CreateResponse(HttpStatusCode.Created, cliente);
            }
            error = new HttpError("Dados inválidos");
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, error);
        }

        // PUT api/cliente/5
        public HttpResponseMessage Put(ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteRepository.Uodate(cliente);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            var error = new HttpError("Erro ao efetuar a atualização");
            return Request.CreateResponse(HttpStatusCode.BadRequest, error);
        }

        // DELETE api/cliente/5
        public HttpResponseMessage Delete(ClienteModel cliente)
        {
            if (_clienteRepository.Remove(cliente.IdCliente))
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}