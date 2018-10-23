using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPTO.Entidades
{
	/// <summary>
	/// Classe gerada para a tabela : Venda.
	/// </summary>

	[Serializable]
	public class Venda
	{

	#region | Variáveis

	int _idProduto;
	int _idVenda;
	int _idCliente;

	#endregion | Variáveis

	#region | Construtores

	public Venda() { }
	public Venda(int idProduto,int idVenda,int idCliente)
	{
	 _idProduto=idProduto;
	 _idVenda=idVenda;
	 _idCliente=idCliente;
	}

	#endregion | Construtores
	#region | Get/Set

	public int idProduto{ get { return _idProduto; } set { _idProduto = value; }} 
	public int idVenda{ get { return _idVenda; } set { _idVenda = value; }} 
	public int idCliente{ get { return _idCliente; } set { _idCliente = value; }} 

	#endregion | Get/Set
	}
}