using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XPTO.Entidades;
using XPTO.Negocios;

namespace XPTO.Web.App.Controllers
{
    public class ConsumoController : Controller
    {
        // GET: Consumo
        public ActionResult Index()
        {
            List<Venda> vendas = new List<Venda>();
            Produto produto = new Produto();
            Cliente cliente = new Cliente();

            List<Relat> relat = new List<Relat>();

            using (VendaNegocios vendanegocios = new VendaNegocios())
            {
                using (ClienteNegocios clientenegocios = new ClienteNegocios())
                {
                    using (ProdutoNegocios produtoNegocios = new ProdutoNegocios())
                    {
                        vendas = vendanegocios.Listar();
                        foreach (Venda venda in vendas)
                        {
                            produto = produtoNegocios.Selecionar(venda.idProduto);
                            cliente = clientenegocios.Selecionar(venda.idCliente);

                            Relat l = new Relat();
                            l.PrimeiroNome = cliente.PrimeiroNome;
                            l.SegundoNome = cliente.SegundoNome;
                            l.Sexo = cliente.Sexo;
                            l.Email = cliente.Email;
                            l.Nascimento = cliente.Nascimento;
                            l.Produto = produto.Descricao;
                            relat.Add(l);
                        }
                    }
                }
            }

            var Result = relat.ToList();
            return View(Result);

          
        }
    }
}