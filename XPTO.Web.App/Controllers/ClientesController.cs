using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XPTO.Negocios;

namespace XPTO.Web.App.Views
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            using (ClienteNegocios clientenegocios = new ClienteNegocios())
            {
                var Result = clientenegocios.Listar().ToList();
                return View(Result);
            }
        }
    }
}