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
	/// Classe Clase dados para a tabela : log.
	/// </summary>
	public class logDados : DadosBaseSQL
	{
		public logDados(SqlDb db) : base(db) { }
		public List<log> Listar()
		{
			List<log> lista = new List<log>();
			SqlDataReader dataReader = null;
			try 
			{ 
				dataReader = _db.ExecuteReader("listarlog;");
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

		private log Carregar(SqlDataReader dataReader)
		{
			log entidade = new log();
			entidade.descricao = RetornarCampo(dataReader["descricao"], entidade.descricao);
			entidade.idLog = RetornarCampo(dataReader["idLog"], entidade.idLog);
			entidade.Data = RetornarCampo(dataReader["Data"], entidade.Data);
			entidade.Arquivo = RetornarCampo(dataReader["Arquivo"], entidade.Arquivo);
			entidade.Sucesso = RetornarCampo(dataReader["Sucesso"], entidade.Sucesso);
			return entidade;
		}

		public log Selecionar(long id)
		{
			log retorno = null;
			SqlDataReader dataReader = null;
			try
			{
				dataReader = _db.ExecuteReader("Exec SelecionarlogByID @idlog;", new SqlParameter("@Idlog", id));
				if (dataReader.Read())
				{
					retorno = new log();
					retorno.descricao = RetornarCampo(dataReader["descricao"], retorno.descricao);
					retorno.idLog = RetornarCampo(dataReader["idLog"], retorno.idLog);
					retorno.Data = RetornarCampo(dataReader["Data"], retorno.Data);
					retorno.Arquivo = RetornarCampo(dataReader["Arquivo"], retorno.Arquivo);
					retorno.Sucesso = RetornarCampo(dataReader["Sucesso"], retorno.Sucesso);
				}
			}
			catch (Erro oErro){GravarLogErro(oErro.Mensagem);} 
			catch (Exception oEx){GravarLogErro(oEx.Message);} 
			finally{dataReader.Close();} 
			return retorno;
		}

		public int Inserir(log log)
		{
			int id = -1;
			try
			{
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter("@descricao", log.descricao));
				parametros.Add(new SqlParameter("@idLog", log.idLog));
				parametros.Add(new SqlParameter("@Data", log.Data));
				parametros.Add(new SqlParameter("@Arquivo", log.Arquivo));
				parametros.Add(new SqlParameter("@Sucesso", log.Sucesso));
				id = RetornarCampo(_db.ExecuteScalar("Exec Inserirlog @descricao, @idLog, @Data, @Arquivo, @Sucesso;", parametros), id);
			}
			catch (Erro oErro){GravarLogErro(oErro.Mensagem);} 
			catch (Exception oEx){GravarLogErro(oEx.Message);} 
			return id; 
		}

		public void Atualizar(log log)
		{
			try
			{
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter("@descricao", log.descricao));
				parametros.Add(new SqlParameter("@idLog", log.idLog));
				parametros.Add(new SqlParameter("@Data", log.Data));
				parametros.Add(new SqlParameter("@Arquivo", log.Arquivo));
				parametros.Add(new SqlParameter("@Sucesso", log.Sucesso));
				_db.ExecuteNonQuery("Exec Atualizarlog @descricao, @idLog, @Data, @Arquivo, @Sucesso;", parametros);
			}
			catch (Erro oErro){GravarLogErro(oErro.Mensagem);} 
			catch (Exception oEx){GravarLogErro(oEx.Message);} 
		}

	}
}
