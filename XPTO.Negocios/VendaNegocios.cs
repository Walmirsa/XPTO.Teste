using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Base.Framework.Generico;
using XPTO.Entidades;
using XPTO.Dados;

namespace XPTO.Negocios
{
	/// <summary>
	/// Classe Clase Negocios para a tabela : Venda.
	/// </summary>
	public class VendaNegocios : NegocioBase
	{
		public List<Venda> Listar()
		{
			using (SqlDb db = new SqlDb(_funcoes.GetConnectionStringsSQL(_conexaoSQL), SqlDb.TipoConexao.ConnectionString))
			{
				using (VendaDados dados = new VendaDados(db))
				{
					return dados.Listar();
				}
			}
		}

		public Venda Selecionar(long id)
		{
			using (SqlDb db = new SqlDb(_funcoes.GetConnectionStringsSQL(_conexaoSQL), SqlDb.TipoConexao.ConnectionString))
			{
				using (VendaDados dados = new VendaDados(db))
				{
					return dados.Selecionar(id);
				}
			}
		}

        public bool ExisteVenda(long Produto, long Cliente)
        {
            using (SqlDb db = new SqlDb(_funcoes.GetConnectionStringsSQL(_conexaoSQL), SqlDb.TipoConexao.ConnectionString))
            {
                using (VendaDados dados = new VendaDados(db))
                {
                    Venda venda = new Venda();
                    venda = dados.SelecionarByClienteProduto(Cliente, Produto);
                    return venda == null ? false : true;                    
                }
            }
        }

        public Venda Manutencao(Venda Venda)
		{
			using (SqlDb db = new SqlDb(_funcoes.GetConnectionStringsSQL(_conexaoSQL), SqlDb.TipoConexao.ConnectionString))
			{
				using (VendaDados dados = new VendaDados(db))
				{
					if (Venda.idVenda > 0)
					{
						Venda.idVenda = dados.Inserir(Venda);
					}
					else
					{
						dados.Atualizar(Venda);
					}
					return (Venda);
				}
			}
		}
        public Venda Inserir(Venda Venda)
        {
            using (SqlDb db = new SqlDb(_funcoes.GetConnectionStringsSQL(_conexaoSQL), SqlDb.TipoConexao.ConnectionString))
            {
                using (VendaDados dados = new VendaDados(db))
                {  
                    Venda.idVenda = dados.Inserir(Venda);                   
                    return (Venda);
                }
            }
        }
        public Venda Atualizar(Venda Venda)
        {
            using (SqlDb db = new SqlDb(_funcoes.GetConnectionStringsSQL(_conexaoSQL), SqlDb.TipoConexao.ConnectionString))
            {
                using (VendaDados dados = new VendaDados(db))
                {
                    dados.Atualizar(Venda);
                    return (Venda);
                }
            }
        }

    }
}
