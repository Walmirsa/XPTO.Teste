using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPTO.Entidades
{
	/// <summary>
	/// Classe gerada para a tabela : Cliente.
	/// </summary>

	[Serializable]
	public class Cliente
	{

	#region | Variáveis

	bool _Ativo;
	string _Email;
	int _idCliente;
	DateTime _Nascimento;
	string _Sexo;
	string _PrimeiroNome;
	string _SegundoNome;

	#endregion | Variáveis

	#region | Construtores

	public Cliente() { }
	public Cliente(bool Ativo,string Email,int idCliente,DateTime Nascimento,string Sexo,string PrimeiroNome,string SegundoNome)
	{
	 _Ativo=Ativo;
	 _Email=Email;
	 _idCliente=idCliente;
	 _Nascimento=Nascimento;
	 _Sexo=Sexo;
	 _PrimeiroNome=PrimeiroNome;
	 _SegundoNome=SegundoNome;
	}

	#endregion | Construtores
	#region | Get/Set

	public bool Ativo{ get { return _Ativo; } set { _Ativo = value; }} 
	public string Email{ get { return _Email; } set { _Email = value; }} 
	public int idCliente{ get { return _idCliente; } set { _idCliente = value; }} 
	public DateTime Nascimento{ get { return _Nascimento; } set { _Nascimento = value; }} 
	public string Sexo{ get { return _Sexo; } set { _Sexo = value; }} 
	public string PrimeiroNome{ get { return _PrimeiroNome; } set { _PrimeiroNome = value; }} 
	public string SegundoNome{ get { return _SegundoNome; } set { _SegundoNome = value; }} 

	#endregion | Get/Set
	}
}