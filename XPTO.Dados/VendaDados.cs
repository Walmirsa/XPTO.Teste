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
	/// Classe Clase dados para a tabela : Venda.
	/// </summary>
	public class VendaDados : DadosBaseSQL
	{
		public VendaDados(SqlDb db) : base(db) { }
		public List<Venda> Listar()
		{
			List<Venda> lista = new List<Venda>();
			SqlDataReader dataReader = null;
			try 
			{ 
				dataReader = _db.ExecuteReader("listarVenda;");
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

		private Venda Carregar(SqlDataReader dataReader)
		{
			Venda entidade = new Venda();
			entidade.idProduto = RetornarCampo(dataReader["idProduto"], entidade.idProduto);
			entidade.idVenda = RetornarCampo(dataReader["idVenda"], entidade.idVenda);
			entidade.idCliente = RetornarCampo(dataReader["idCliente"], entidade.idCliente);
			return entidade;
		}

		public Venda Selecionar(long id)
		{
			Venda retorno = null;
			SqlDataReader dataReader = null;
			try
			{
				dataReader = _db.ExecuteReader("Exec SelecionarVendaByID @idVenda;", new SqlParameter("@IdVenda", id));
				if (dataReader.Read())
				{
					retorno = new Venda();
					retorno.idProduto = RetornarCampo(dataReader["idProduto"], retorno.idProduto);
					retorno.idVenda = RetornarCampo(dataReader["idVenda"], retorno.idVenda);
					retorno.idCliente = RetornarCampo(dataReader["idCliente"], retorno.idCliente);
				}
			}
			catch (Erro oErro){GravarLogErro(oErro.Mensagem);} 
			catch (Exception oEx){GravarLogErro(oEx.Message);} 
			finally{dataReader.Close();} 
			return retorno;
		}

        public Venda SelecionarByClienteProduto(long Cliente,long Produto)
        {
            Venda retorno = null;
            SqlDataReader dataReader = null;
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@Produto", Produto));                
                parametros.Add(new SqlParameter("@Cliente", Cliente));
                
                dataReader = _db.ExecuteReader("Exec SelecionarByClienteProduto @Produto,@Cliente;", parametros);
                if (dataReader.Read())
                {
                    retorno = new Venda();
                    retorno.idProduto = RetornarCampo(dataReader["idProduto"], retorno.idProduto);
                    retorno.idVenda = RetornarCampo(dataReader["idVenda"], retorno.idVenda);
                    retorno.idCliente = RetornarCampo(dataReader["idCliente"], retorno.idCliente);
                }
            }
            catch (Erro oErro) { GravarLogErro(oErro.Mensagem); }
            catch (Exception oEx) { GravarLogErro(oEx.Message); }
            finally { dataReader.Close(); }
            return retorno;
        }




        public int Inserir(Venda Venda)
		{
			int id = -1;
			try
			{
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter("@idProduto", Venda.idProduto));
				parametros.Add(new SqlParameter("@idVenda", Venda.idVenda));
				parametros.Add(new SqlParameter("@idCliente", Venda.idCliente));
				id = RetornarCampo(_db.ExecuteScalar("Exec InserirVenda @idProduto, @idVenda, @idCliente;", parametros), id);
			}
			catch (Erro oErro){GravarLogErro(oErro.Mensagem);} 
			catch (Exception oEx){GravarLogErro(oEx.Message);} 
			return id; 
		}

		public void Atualizar(Venda Venda)
		{
			try
			{
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter("@idProduto", Venda.idProduto));
				parametros.Add(new SqlParameter("@idVenda", Venda.idVenda));
				parametros.Add(new SqlParameter("@idCliente", Venda.idCliente));
				_db.ExecuteNonQuery("Exec AtualizarVenda @idProduto, @idVenda, @idCliente;", parametros);
			}
			catch (Erro oErro){GravarLogErro(oErro.Mensagem);} 
			catch (Exception oEx){GravarLogErro(oEx.Message);} 
		}

	}
}
