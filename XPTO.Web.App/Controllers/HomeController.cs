using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XPTO.Negocios;
using XPTO.Entidades;

namespace XPTO.Web.App.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult Index(HttpPostedFileBase postedFile)
        {

            string filePath = string.Empty;
            if (postedFile != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                filePath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filePath);
                log log = new log();

                using (StreamReader sr = new StreamReader(filePath))
                {
                    using (ImportacaoNegocios importacaoNegocios = new ImportacaoNegocios())
                    {
                        
                        log = importacaoNegocios.ImportarArquivo(sr);
                    }
                }
          
                ViewBag.Message = log.descricao.ToString();
                              
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}