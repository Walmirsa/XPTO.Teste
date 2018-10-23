using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPTO.Entidades
{
	/// <summary>
	/// Classe gerada para a tabela : log.
	/// </summary>

	[Serializable]
	public class log
	{

	#region | Variáveis

	string _descricao;
	int _idLog;
	DateTime _Data;
	string _Arquivo;
	bool _Sucesso;

	#endregion | Variáveis

	#region | Construtores

	public log() { }
	public log(string descricao,int idLog,DateTime Data,string Arquivo,bool Sucesso)
	{
	 _descricao=descricao;
	 _idLog=idLog;
	 _Data=Data;
	 _Arquivo=Arquivo;
	 _Sucesso=Sucesso;
	}

	#endregion | Construtores
	#region | Get/Set

	public string descricao{ get { return _descricao; } set { _descricao = value; }} 
	public int idLog{ get { return _idLog; } set { _idLog = value; }} 
	public DateTime Data{ get { return _Data; } set { _Data = value; }} 
	public string Arquivo{ get { return _Arquivo; } set { _Arquivo = value; }} 
	public bool Sucesso{ get { return _Sucesso; } set { _Sucesso = value; }} 

	#endregion | Get/Set
	}
}