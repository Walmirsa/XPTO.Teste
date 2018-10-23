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
	/// Classe Clase Negocios para a tabela : Produto.
	/// </summary>
	public class ProdutoNegocios : NegocioBase
	{
		public List<Produto> Listar()
		{
			using (SqlDb db = new SqlDb(_funcoes.GetConnectionStringsSQL(_conexaoSQL), SqlDb.TipoConexao.ConnectionString))
			{
				using (ProdutoDados dados = new ProdutoDados(db))
				{
					return dados.Listar();
				}
			}
		}
        public List<Produto> ListarByDescricao(string descricao)
        {
            using (SqlDb db = new SqlDb(_funcoes.GetConnectionStringsSQL(_conexaoSQL), SqlDb.TipoConexao.ConnectionString))
            {
                using (ProdutoDados dados = new ProdutoDados(db))
                {
                    return dados.Listar();
                }
            }
        }
        public bool ExisteProduto(string descricao)
        {
            using (SqlDb db = new SqlDb(_funcoes.GetConnectionStringsSQL(_conexaoSQL), SqlDb.TipoConexao.ConnectionString))
            {
                using (ProdutoDados dados = new ProdutoDados(db))
                {
                    Produto produto = new Produto();
                    produto = dados.SelecionarByDescricao(descricao);
                    return produto == null ? false : true;                    
                }
            }
        }



        public Produto Selecionar(long id)
		{
			using (SqlDb db = new SqlDb(_funcoes.GetConnectionStringsSQL(_conexaoSQL), SqlDb.TipoConexao.ConnectionString))
			{
				using (ProdutoDados dados = new ProdutoDados(db))
				{
					return dados.Selecionar(id);
				}
			}
		}

		public int Inserir(Produto Produto)
		{
			using (SqlDb db = new SqlDb(_funcoes.GetConnectionStringsSQL(_conexaoSQL), SqlDb.TipoConexao.ConnectionString))
			{
				using (ProdutoDados dados = new ProdutoDados(db))
				{
                    return dados.Inserir(Produto);                 
				}
			}
		}
        public void Atualizar(Produto Produto)
        {
            using (SqlDb db = new SqlDb(_funcoes.GetConnectionStringsSQL(_conexaoSQL), SqlDb.TipoConexao.ConnectionString))
            {
                using (ProdutoDados dados = new ProdutoDados(db))
                {
                    dados.Atualizar(Produto);
                }
            }
        }
    }
}
