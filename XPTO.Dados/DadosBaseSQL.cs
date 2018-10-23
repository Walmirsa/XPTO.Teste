using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Base.Framework.Generico;
using Base.Framework.WindowsForm;
using XPTO.Entidades;

namespace XPTO.Dados
{
    public class DadosBaseSQL : DadosBase
    {
        #region | Variáveis

        public SqlDb _db = null;

        #endregion | Variáveis

        #region | Construtores

        public DadosBaseSQL(SqlDb db) 
        {
            if (_db == null) { _db = db; }
        }

        public DadosBaseSQL(string itemConexao) 
        {
            if (_db == null)
            {
                _db = new SqlDb(_funcoes.GetConnectionStringsSQL(itemConexao), SqlDb.TipoConexao.ConnectionString);
            }
        }

        #endregion | Construtores
    }
}
