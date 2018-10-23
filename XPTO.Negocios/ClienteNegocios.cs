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
	/// Classe Clase Negocios para a tabela : Cliente.
	/// </summary>
	public class ClienteNegocios : NegocioBase
	{
		public List<Cliente> Listar()
		{
			using (SqlDb db = new SqlDb(_funcoes.GetConnectionStringsSQL(_conexaoSQL), SqlDb.TipoConexao.ConnectionString))
			{
				using (ClienteDados dados = new ClienteDados(db))
				{
					return dados.Listar();
				}
			}
		}
        public bool ClienteExiste(long idUsuario)
        {
            using (SqlDb db = new SqlDb(_funcoes.GetConnectionStringsSQL(_conexaoSQL), SqlDb.TipoConexao.ConnectionString))
            {
                using (ClienteDados dados = new ClienteDados(db))
                {
                    Cliente cliente = new Cliente();
                    cliente = dados.Selecionar(idUsuario);
                    return cliente == null ? false : true;                   
                }
            }
        }


        public Cliente Selecionar(long id)
		{
			using (SqlDb db = new SqlDb(_funcoes.GetConnectionStringsSQL(_conexaoSQL), SqlDb.TipoConexao.ConnectionString))
			{
				using (ClienteDados dados = new ClienteDados(db))
				{
					return dados.Selecionar(id);
				}
			}
		}

		public Cliente Inserir(Cliente Cliente)
		{
			using (SqlDb db = new SqlDb(_funcoes.GetConnectionStringsSQL(_conexaoSQL), SqlDb.TipoConexao.ConnectionString))
			{
				using (ClienteDados dados = new ClienteDados(db))
				{
                    Cliente.idCliente = dados.Inserir(Cliente);
                    return (Cliente);
				}
			}
		}
        public Cliente Atualizar(Cliente Cliente)
        {
            using (SqlDb db = new SqlDb(_funcoes.GetConnectionStringsSQL(_conexaoSQL), SqlDb.TipoConexao.ConnectionString))
            {
                using (ClienteDados dados = new ClienteDados(db))
                {
                    dados.Atualizar(Cliente);
                    return (Cliente);
                }
            }
        }

    }
}
