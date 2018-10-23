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
	/// Classe Clase dados para a tabela : Cliente.
	/// </summary>
	public class ClienteDados : DadosBaseSQL
	{
		public ClienteDados(SqlDb db) : base(db) { }
		public List<Cliente> Listar()
		{
			List<Cliente> lista = new List<Cliente>();
			SqlDataReader dataReader = null;
			try 
			{ 
				dataReader = _db.ExecuteReader("listarCliente;");
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

		private Cliente Carregar(SqlDataReader dataReader)
		{
			Cliente entidade = new Cliente();
			entidade.Ativo = RetornarCampo(dataReader["Ativo"], entidade.Ativo);
			entidade.Email = RetornarCampo(dataReader["Email"], entidade.Email);
			entidade.idCliente = RetornarCampo(dataReader["idCliente"], entidade.idCliente);
			entidade.Nascimento = RetornarCampo(dataReader["Nascimento"], entidade.Nascimento);
			entidade.Sexo = RetornarCampo(dataReader["Sexo"], entidade.Sexo);
			entidade.PrimeiroNome = RetornarCampo(dataReader["PrimeiroNome"], entidade.PrimeiroNome);
			entidade.SegundoNome = RetornarCampo(dataReader["SegundoNome"], entidade.SegundoNome);
			return entidade;
		}

		public Cliente Selecionar(long id)
		{
			Cliente retorno = null;
			SqlDataReader dataReader = null;
			try
			{
				dataReader = _db.ExecuteReader("Exec SelecionarClienteByID @idCliente;", new SqlParameter("@idCliente", id));
				if (dataReader.Read())
				{
					retorno = new Cliente();
					retorno.Ativo = RetornarCampo(dataReader["Ativo"], retorno.Ativo);
					retorno.Email = RetornarCampo(dataReader["Email"], retorno.Email);
					retorno.idCliente = RetornarCampo(dataReader["idCliente"], retorno.idCliente);
					retorno.Nascimento = RetornarCampo(dataReader["Nascimento"], retorno.Nascimento);
					retorno.Sexo = RetornarCampo(dataReader["Sexo"], retorno.Sexo);
					retorno.PrimeiroNome = RetornarCampo(dataReader["PrimeiroNome"], retorno.PrimeiroNome);
					retorno.SegundoNome = RetornarCampo(dataReader["SegundoNome"], retorno.SegundoNome);
				}
			}
			catch (Erro oErro){GravarLogErro(oErro.Mensagem);} 
			catch (Exception oEx){GravarLogErro(oEx.Message);} 
			finally{dataReader.Close();} 
			return retorno;
		}

		public int Inserir(Cliente Cliente)
		{
			int id = -1;
			try
			{
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter("@Ativo", Cliente.Ativo));
				parametros.Add(new SqlParameter("@Email", Cliente.Email));
				parametros.Add(new SqlParameter("@idCliente", Cliente.idCliente));
				parametros.Add(new SqlParameter("@Nascimento", Cliente.Nascimento));
				parametros.Add(new SqlParameter("@Sexo", Cliente.Sexo));
				parametros.Add(new SqlParameter("@PrimeiroNome", Cliente.PrimeiroNome));
				parametros.Add(new SqlParameter("@SegundoNome", Cliente.SegundoNome));
				id = RetornarCampo(_db.ExecuteScalar("Exec InserirCliente @Ativo, @Email, @idCliente, @Nascimento, @Sexo, @PrimeiroNome, @SegundoNome;", parametros), id);
			}
			catch (Erro oErro){GravarLogErro(oErro.Mensagem);} 
			catch (Exception oEx){GravarLogErro(oEx.Message);} 
			return id; 
		}

		public void Atualizar(Cliente Cliente)
		{
			try
			{
				List<SqlParameter> parametros = new List<SqlParameter>();
				parametros.Add(new SqlParameter("@Ativo", Cliente.Ativo));
				parametros.Add(new SqlParameter("@Email", Cliente.Email));
				parametros.Add(new SqlParameter("@idCliente", Cliente.idCliente));
				parametros.Add(new SqlParameter("@Nascimento", Cliente.Nascimento));
				parametros.Add(new SqlParameter("@Sexo", Cliente.Sexo));
				parametros.Add(new SqlParameter("@PrimeiroNome", Cliente.PrimeiroNome));
				parametros.Add(new SqlParameter("@SegundoNome", Cliente.SegundoNome));
				_db.ExecuteNonQuery("Exec AtualizarCliente @Ativo, @Email, @idCliente, @Nascimento, @Sexo, @PrimeiroNome, @SegundoNome;", parametros);
			}
			catch (Erro oErro){GravarLogErro(oErro.Mensagem);} 
			catch (Exception oEx){GravarLogErro(oEx.Message);} 
		}

	}
}
