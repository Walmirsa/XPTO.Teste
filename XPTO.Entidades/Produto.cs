using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPTO.Entidades
{
	/// <summary>
	/// Classe gerada para a tabela : Produto.
	/// </summary>

	[Serializable]
	public class Produto
	{

	#region | Variáveis

	int _idProduto;
	string _Descricao;

	#endregion | Variáveis

	#region | Construtores

	public Produto() { }
	public Produto(int idProduto,string Descricao)
	{
	 _idProduto=idProduto;
	 _Descricao=Descricao;
	}

	#endregion | Construtores
	#region | Get/Set

	public int idProduto{ get { return _idProduto; } set { _idProduto = value; }} 
	public string Descricao{ get { return _Descricao; } set { _Descricao = value; }} 

	#endregion | Get/Set
	}
}