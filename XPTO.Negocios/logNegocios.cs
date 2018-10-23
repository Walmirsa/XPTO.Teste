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
	/// Classe Clase Negocios para a tabela : log.
	/// </summary>
	public class logNegocios : NegocioBase
	{
		public List<log> Listar(long idUsuarioAuditoria)
		{
			using (SqlDb db = new SqlDb(_funcoes.GetConnectionStringsSQL(_conexaoSQL), SqlDb.TipoConexao.ConnectionString))
			{
				using (logDados dados = new logDados(db))
				{
					return dados.Listar();
				}
			}
		}

		public log Selecionar(long id, long idUsuarioAuditoria)
		{
			using (SqlDb db = new SqlDb(_funcoes.GetConnectionStringsSQL(_conexaoSQL), SqlDb.TipoConexao.ConnectionString))
			{
				using (logDados dados = new logDados(db))
				{
					return dados.Selecionar(id);
				}
			}
		}

		public log Manutencao(log log, long idUsuarioAuditoria)
		{
			using (SqlDb db = new SqlDb(_funcoes.GetConnectionStringsSQL(_conexaoSQL), SqlDb.TipoConexao.ConnectionString))
			{
				using (logDados dados = new logDados(db))
				{
					if (log.idLog > 0)
					{
						log.idLog = dados.Inserir(log);
					}
					else
					{
						dados.Atualizar(log);
					}
					return (log);
				}
			}
		}

	}
}
