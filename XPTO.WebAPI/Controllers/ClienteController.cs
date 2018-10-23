using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XPTO.Entidades;
using XPTO.Negocios;

namespace XPTO.WebAPI.Controllers
{
    public class ClienteController : ApiController
    {
        // GET api/values
        public IEnumerable<Cliente> Get()
        {
            using (ClienteNegocios clientenegocios = new ClienteNegocios())
            {
                var Result = clientenegocios.Listar().ToList();
                return Result;
            }            
        }
        
    }
}
