using System.IO;
using System.Linq;
using XPTO.Entidades;
using System;
using System.Globalization;

namespace XPTO.Negocios
{
    public class ImportacaoNegocios : NegocioBase
    {
        public log ImportarArquivo(StreamReader Arquivo)
        {

            log log = new log();

            Enumeradores.RelatorioTipo tipo = Enumeradores.RelatorioTipo.Nulo;

            var Linhas = Arquivo.ReadLine().Split(';');
            foreach (var linha in Linhas)
            {
                var Colunas = linha.Split(',');
                switch (Colunas.Count())
                {
                    case 3:
                        tipo = Enumeradores.RelatorioTipo.Vendas;
                        break;
                    case 7:
                        tipo = Enumeradores.RelatorioTipo.Clientes;
                        break;
                    default:
                        log.descricao = "Arquivo fora de padrão!!!!";
                        log.Sucesso = false;
                        return log;
                        break;
                }
                if (tipo == Enumeradores.RelatorioTipo.Clientes)
                {
                    Cliente cliente = new Cliente();

                    cliente.idCliente = int.Parse(Colunas[0].ToString());
                    cliente.PrimeiroNome = Colunas[1].ToString();
                    cliente.SegundoNome = Colunas[2].ToString();
                    cliente.Nascimento = DateTime.Parse(Colunas[3].ToString(), new CultureInfo("en-US", true));
                    cliente.Sexo = Colunas[4].ToString();
                    cliente.Email = Colunas[5].ToString();
                    cliente.Ativo = Colunas[6].ToString() == "true" ? true : false;

                    using (ClienteNegocios clienteNegocios = new ClienteNegocios())
                    {
                        if (clienteNegocios.ClienteExiste(cliente.idCliente))
                        {
                            clienteNegocios.Atualizar(cliente);
                        }
                        else
                        {
                            clienteNegocios.Inserir(cliente);
                        }
                    }
                }
                if (tipo == Enumeradores.RelatorioTipo.Vendas)
                {
                    Produto produto = new Produto();
                    produto.idProduto= int.Parse(Colunas[0].ToString());
                    produto.Descricao = Colunas[2].ToString();
                    using (ProdutoNegocios produtoNegocios = new ProdutoNegocios())
                    {
                        if (produtoNegocios.ExisteProduto(Colunas[2].ToString()))
                        {
                            produtoNegocios.Atualizar(produto);
                        }
                        else
                        {
                            produto.idProduto = produtoNegocios.Inserir(produto);
                        }
                    }
                    using (VendaNegocios vendaNegocios = new VendaNegocios())
                    {
                        Venda venda = new Venda();
                        venda.idProduto = produto.idProduto;
                        venda.idCliente = int.Parse(Colunas[0].ToString());
                        
                        if (vendaNegocios.ExisteVenda(venda.idProduto, venda.idCliente ))
                        {
                            vendaNegocios.Atualizar(venda);
                        }
                        else
                        {
                            vendaNegocios.Inserir(venda);                            
                        }
                    }
                }   
            }


            log.descricao = tipo == Enumeradores.RelatorioTipo.Vendas ? "Arquivo de Produtos Importado!" : "Arquivo de Clientes Importado!";
            log.Sucesso = true;
            return log;
        }
    }
}