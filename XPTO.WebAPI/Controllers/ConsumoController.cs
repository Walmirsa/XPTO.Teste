using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XPTO.Entidades;
using XPTO.Negocios;

namespace XPTO.WebAPI.Controllers
{
    public class ConsumoController : ApiController
    {
        // GET api/values
        public IEnumerable<Relat> Get()
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
            var result = relat.ToList();
            return result;         
        }       
    }
}
