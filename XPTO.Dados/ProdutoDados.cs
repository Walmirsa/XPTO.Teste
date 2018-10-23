using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Base.Framework.Generico;
using XPTO.Entidades;

namespace XPTO.Dados
{
	/// <summary>
	/// Classe Clase dados para a tabela : Produto.
	/// </summary>
	public class ProdutoDados : DadosBaseSQL
	{
		public ProdutoDados(SqlDb db) : base(db) { }
		public List<Produto> Listar()
		{
			List<Produto> lista = new List<Produto>();
			SqlDataReader dataReader = null;
			try 
			{ 
				dataReader = _db.ExecuteReader("listarProduto;");
				while (dataReader.Read())
				{
					lista.Add(Carregar(dataReader));
				}
			} 
			catch (Erro oErro){GravarLogErro(oErro.Mensagem);} 
			catch (Exception oEx){GravarLogErro(oEx.Message);} 
			finally{dataReader.Close();} 
			return lista;
		}
      
        private Produto Carregar(SqlDataReader dataReader)
		{
			Produto entidade = new Produto();
			entidade.idProduto = RetornarCampo(dataReader["idProduto"], entidade.idProduto);
			entidade.Descricao = RetornarCampo(dataReader["Descricao"], entidade.Descricao);
			return entidade;
		}

		public Produto Selecionar(long id)
		{
			Produto retorno = null;
			SqlDataReader dataReader = null;
			try
			{
				dataReader = _db.ExecuteReader("Exec SelecionarProdutoByID @idProduto;", new SqlParameter("@IdProduto", id));
				if (dataReader.Read())
				{
					retorno = new Produto();
					retorno.idProduto = RetornarCampo(dataReader["idProduto"], retorno.idProduto);
					retorno.Descricao = RetornarCampo(dataReader["Descricao"], retorno.Descricao);
				}
			}
			catch (Erro oErro){GravarLogErro(oErro.Mensagem);} 
			catch (Exception oEx){GravarLogErro(oEx.Message);} 
			finally{dataReader.Close();} 
			return retorno;
		}

        public Produto SelecionarByDescricao(string Descricao)
        {
            Produto retorno = null;
            SqlDataReader dataReader = null;
            try
            {
                dataReader = _db.ExecuteReader("Exec SelecionarProdutoByDescricao @descricao;", new SqlParameter("@descricao", Descricao));
                if (dataReader.Read())
                {
                    retorno = new Produto();
                    retorno.idProduto = RetornarCampo(dataReader["idProduto"], retorno.idProduto);
                    retorno.Descricao = RetornarCampo(dataReader["Descricao"], retorno.Descricao);
                }
            }
            catch (Erro oErro) { GravarLogErro(oErro.Mensagem); }
            catch (Exception oEx) { GravarLogErro(oEx.Message); }
            finally { dataReader.Close(); }
            return retorno;
        }





        public int Inserir(Produto Produto)
		{
			int id = -1;
			try
			{
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter("@idProduto", Produto.idProduto));
				parametros.Add(new SqlParameter("@Descricao", Produto.Descricao));
				id = RetornarCampo(_db.ExecuteScalar("Exec InserirProduto @idProduto, @Descricao;", parametros), id);
			}
			catch (Erro oErro){GravarLogErro(oErro.Mensagem);} 
			catch (Exception oEx){GravarLogErro(oEx.Message);} 
			return id; 
		}

		public void Atualizar(Produto Produto)
		{
			try
			{
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter("@idProduto", Produto.idProduto));
				parametros.Add(new SqlParameter("@Descricao", Produto.Descricao));
				_db.ExecuteNonQuery("Exec AtualizarProduto @idProduto, @Descricao;", parametros);
			}
			catch (Erro oErro){GravarLogErro(oErro.Mensagem);} 
			catch (Exception oEx){GravarLogErro(oEx.Message);} 
		}

	}
}
