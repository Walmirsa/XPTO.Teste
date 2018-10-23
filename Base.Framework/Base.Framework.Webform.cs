using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Base.Framework.Generico;

namespace Base.Framework.WebForm
{
    namespace Objetos
    {
        public class Localizar
        {
            #region object

            public object Controle(System.Web.UI.Control control, string nomeControleLocalizar)
            {
                object controle = null;
                RetornarControle(control, nomeControleLocalizar, ref controle);
                return controle;
            }

            private void RetornarControle(System.Web.UI.Control control, string nomeControleLocalizar, ref object controle)
            {
                foreach (System.Web.UI.Control ctl in control.Controls)
                {
                    if (ctl != null && ctl.ID != null && ctl.ID.Trim() == nomeControleLocalizar.Trim())
                    {
                        controle = ctl;
                        return;
                    }
                    RetornarControle(ctl, nomeControleLocalizar, ref controle);
                }
            }

            #endregion object

            #region TextBox

            #region por nome

            public System.Web.UI.WebControls.TextBox Controle(System.Web.UI.Control control, string nomeControleLocalizar, System.Web.UI.WebControls.TextBox controle)
            {
                controle = null;
                RetornarControle(control, nomeControleLocalizar, ref controle);
                return controle;
            }

            private void RetornarControle(System.Web.UI.Control control, string nomeControleLocalizar, ref System.Web.UI.WebControls.TextBox controle)
            {
                foreach (System.Web.UI.Control ctl in control.Controls)
                {
                    if (ctl is System.Web.UI.WebControls.TextBox && ctl.ID.Trim() == nomeControleLocalizar.Trim())
                    {
                        controle = (System.Web.UI.WebControls.TextBox)ctl;
                        return;
                    }
                    RetornarControle(ctl, nomeControleLocalizar, ref controle);
                }
            }

            #endregion por nome

            #region por atributo

            public System.Web.UI.WebControls.TextBox ControlePorAtributo(System.Web.UI.Control control, string nomeAtributo, System.Web.UI.WebControls.TextBox controle)
            {
                controle = null;
                RetornarControlePorAtributo(control, nomeAtributo, string.Empty, ref controle);
                return controle;
            }

            public System.Web.UI.WebControls.TextBox ControlePorAtributo(System.Web.UI.Control control, string nomeAtributo, string valorAtributo, System.Web.UI.WebControls.TextBox controle)
            {
                controle = null;
                RetornarControlePorAtributo(control, nomeAtributo, valorAtributo, ref controle);
                return controle;
            }

            private void RetornarControlePorAtributo(System.Web.UI.Control control, string nomeAtributo, string valorAtributo, ref System.Web.UI.WebControls.TextBox controle)
            {
                foreach (System.Web.UI.Control ctl in control.Controls)
                {
                    if (ctl is System.Web.UI.WebControls.TextBox)
                    {
                        System.Web.UI.WebControls.TextBox controleLocalizado = (System.Web.UI.WebControls.TextBox)ctl;

                        if (controleLocalizado.Attributes[nomeAtributo] != null)
                        {
                            if (string.IsNullOrEmpty(valorAtributo.Trim()) || controleLocalizado.Attributes[nomeAtributo].Trim() == valorAtributo.Trim())
                            {
                                controle = controleLocalizado;
                                return;
                            }
                        }
                    }
                    RetornarControlePorAtributo(ctl, nomeAtributo, valorAtributo, ref controle);
                }
            }

            #endregion por atributo

            #endregion TextBox

            #region CheckBox

            #region por nome

            public System.Web.UI.WebControls.CheckBox Controle(System.Web.UI.Control control, string nomeControleLocalizar, System.Web.UI.WebControls.CheckBox controle)
            {
                controle = null;
                RetornarControle(control, nomeControleLocalizar, ref controle);
                return controle;
            }

            private void RetornarControle(System.Web.UI.Control control, string nomeControleLocalizar, ref System.Web.UI.WebControls.CheckBox controle)
            {
                foreach (System.Web.UI.Control ctl in control.Controls)
                {
                    if (ctl is System.Web.UI.WebControls.CheckBox && ctl.ID.Trim() == nomeControleLocalizar.Trim())
                    {
                        controle = (System.Web.UI.WebControls.CheckBox)ctl;
                        return;
                    }
                    RetornarControle(ctl, nomeControleLocalizar, ref controle);
                }
            }

            #endregion por nome

            #region por atributo

            public System.Web.UI.WebControls.CheckBox ControlePorAtributo(System.Web.UI.Control control, string nomeAtributo, System.Web.UI.WebControls.CheckBox controle)
            {
                controle = null;
                RetornarControlePorAtributo(control, nomeAtributo, string.Empty, ref controle);
                return controle;
            }

            public System.Web.UI.WebControls.CheckBox ControlePorAtributo(System.Web.UI.Control control, string nomeAtributo, string valorAtributo, System.Web.UI.WebControls.CheckBox controle)
            {
                controle = null;
                RetornarControlePorAtributo(control, nomeAtributo, valorAtributo, ref controle);
                return controle;
            }

            private void RetornarControlePorAtributo(System.Web.UI.Control control, string nomeAtributo, string valorAtributo, ref System.Web.UI.WebControls.CheckBox controle)
            {
                foreach (System.Web.UI.Control ctl in control.Controls)
                {
                    if (ctl is System.Web.UI.WebControls.CheckBox)
                    {
                        System.Web.UI.WebControls.CheckBox controleLocalizado = (System.Web.UI.WebControls.CheckBox)ctl;

                        if (controleLocalizado.Attributes[nomeAtributo] != null)
                        {
                            if (string.IsNullOrEmpty(valorAtributo.Trim()) || controleLocalizado.Attributes[nomeAtributo].Trim() == valorAtributo.Trim())
                            {
                                controle = controleLocalizado;
                                return;
                            }
                        }
                    }
                    RetornarControlePorAtributo(ctl, nomeAtributo, valorAtributo, ref controle);
                }
            }

            #endregion por atributo

            #endregion CheckBox

            #region DropDownList

            #region por nome

            public System.Web.UI.WebControls.DropDownList Controle(System.Web.UI.Control control, string nomeControleLocalizar, System.Web.UI.WebControls.DropDownList controle)
            {
                controle = null;
                RetornarControle(control, nomeControleLocalizar, ref controle);
                return controle;
            }

            private void RetornarControle(System.Web.UI.Control control, string nomeControleLocalizar, ref System.Web.UI.WebControls.DropDownList controle)
            {
                foreach (System.Web.UI.Control ctl in control.Controls)
                {
                    if (ctl is System.Web.UI.WebControls.DropDownList && ctl.ID.Trim() == nomeControleLocalizar.Trim())
                    {
                        controle = (System.Web.UI.WebControls.DropDownList)ctl;
                        return;
                    }
                    RetornarControle(ctl, nomeControleLocalizar, ref controle);
                }
            }

            #endregion por nome

            #region por atributo

            public System.Web.UI.WebControls.DropDownList ControlePorAtributo(System.Web.UI.Control control, string nomeAtributo, System.Web.UI.WebControls.DropDownList controle)
            {
                controle = null;
                RetornarControlePorAtributo(control, nomeAtributo, string.Empty, ref controle);
                return controle;
            }

            public System.Web.UI.WebControls.DropDownList ControlePorAtributo(System.Web.UI.Control control, string nomeAtributo, string valorAtributo, System.Web.UI.WebControls.DropDownList controle)
            {
                controle = null;
                RetornarControlePorAtributo(control, nomeAtributo, valorAtributo, ref controle);
                return controle;
            }

            private void RetornarControlePorAtributo(System.Web.UI.Control control, string nomeAtributo, string valorAtributo, ref System.Web.UI.WebControls.DropDownList controle)
            {
                foreach (System.Web.UI.Control ctl in control.Controls)
                {
                    if (ctl is System.Web.UI.WebControls.DropDownList)
                    {
                        System.Web.UI.WebControls.DropDownList controleLocalizado = (System.Web.UI.WebControls.DropDownList)ctl;

                        if (controleLocalizado.Attributes[nomeAtributo] != null)
                        {
                            if (string.IsNullOrEmpty(valorAtributo.Trim()) || controleLocalizado.Attributes[nomeAtributo].Trim() == valorAtributo.Trim())
                            {
                                controle = controleLocalizado;
                                return;
                            }
                        }
                    }
                    RetornarControlePorAtributo(ctl, nomeAtributo, valorAtributo, ref controle);
                }
            }

            #endregion por atributo

            #endregion DropDownList

            #region Button

            #region por nome

            public System.Web.UI.WebControls.Button Controle(System.Web.UI.Control control, string nomeControleLocalizar, System.Web.UI.WebControls.Button controle)
            {
                controle = null;
                RetornarControle(control, nomeControleLocalizar, ref controle);
                return controle;
            }

            private void RetornarControle(System.Web.UI.Control control, string nomeControleLocalizar, ref System.Web.UI.WebControls.Button controle)
            {
                foreach (System.Web.UI.Control ctl in control.Controls)
                {
                    if (ctl is System.Web.UI.WebControls.Button && ctl.ID.Trim() == nomeControleLocalizar.Trim())
                    {
                        controle = (System.Web.UI.WebControls.Button)ctl;
                        return;
                    }
                    RetornarControle(ctl, nomeControleLocalizar, ref controle);
                }
            }

            #endregion por nome

            #region por atributo

            public System.Web.UI.WebControls.Button ControlePorAtributo(System.Web.UI.Control control, string nomeAtributo, System.Web.UI.WebControls.Button controle)
            {
                controle = null;
                RetornarControlePorAtributo(control, nomeAtributo, string.Empty, ref controle);
                return controle;
            }

            public System.Web.UI.WebControls.Button ControlePorAtributo(System.Web.UI.Control control, string nomeAtributo, string valorAtributo, System.Web.UI.WebControls.Button controle)
            {
                controle = null;
                RetornarControlePorAtributo(control, nomeAtributo, valorAtributo, ref controle);
                return controle;
            }

            private void RetornarControlePorAtributo(System.Web.UI.Control control, string nomeAtributo, string valorAtributo, ref System.Web.UI.WebControls.Button controle)
            {
                foreach (System.Web.UI.Control ctl in control.Controls)
                {
                    if (ctl is System.Web.UI.WebControls.Button)
                    {
                        System.Web.UI.WebControls.Button controleLocalizado = (System.Web.UI.WebControls.Button)ctl;

                        if (controleLocalizado.Attributes[nomeAtributo] != null)
                        {
                            if (string.IsNullOrEmpty(valorAtributo.Trim()) || controleLocalizado.Attributes[nomeAtributo].Trim() == valorAtributo.Trim())
                            {
                                controle = controleLocalizado;
                                return;
                            }
                        }
                    }
                    RetornarControlePorAtributo(ctl, nomeAtributo, valorAtributo, ref controle);
                }
            }

            #endregion por atributo

            #endregion Button
        }

        public class Preencher
        {
            //Caso seja necessário usar o caracter & em uma querystring, usar no lugar a combinação de caracters [#*#]
            //Essa combinação será substituída por & nas funções

            #region Menu

            #region Exemplo de XML que deve ser passado
            //<?xml version="1.0" encoding="ISO-8859-1"?>
            //<itens>
            //    <item nivel="0" text="Texto 1" value="1" url=""  target="" imageurl="" tooltip="">
            //        <item nivel="1" text="Texto 10" value="10" url="" target="" imageurl="" tooltip="">
            //            <item nivel="2" text="Texto 100" value="100" url="http://intrabmfbovespa/" target="Corpo" imageurl="" tooltip=""/>
            //        </item>
            //    </item>
            //    <item nivel="0" text="Texto 2" value="2" url="" target="" imageurl="" tooltip="">
            //        <item nivel="1" text="Texto 20" value="20" url="http://www.bovespa.com.br/Principal.asp" target="Corpo" imageurl="" tooltip=""/>
            //    </item>
            //    <item nivel="0" text="Texto 3" value="3" url="" target="" imageurl="" tooltip="">
            //        <item nivel="1" text="Texto 30" value="30" url="DivideTAB.aspx" target="Corpo" imageurl="" tooltip=""/>
            //    </item>
            //</itens>
            #endregion

            public void Executar(string strXml, System.Web.UI.WebControls.Menu objMenu)
            {
                try
                {
                    XmlDocument objXml = new XmlDocument();
                    objXml.LoadXml(strXml);
                    Executar(objXml, objMenu, string.Empty);
                }
                catch (Exception oEx)
                {
                    throw new Erro(oEx.Message, "Base", "Base.cs", GetType().FullName.ToString(), "Executar(string strXml, System.Web.UI.WebControls.Menu objMenu)", "Base.log");
                }
            }

            public void Executar(XmlDocument objXml, System.Web.UI.WebControls.Menu objMenu)
            {
                try
                {
                    Executar(objXml, objMenu, string.Empty);
                }
                catch (Exception oEx)
                {
                    throw new Erro(oEx.Message, "Base", "Base.cs", GetType().FullName.ToString(), "Executar(XmlDocument objXml, System.Web.UI.WebControls.Menu objMenu)", "Base.log");
                }
            }

            public void Executar(string strXml, System.Web.UI.WebControls.Menu objMenu, string FullPathImagem)
            {
                try
                {
                    XmlDocument objXml = new XmlDocument();
                    objXml.LoadXml(strXml);
                    Executar(objXml, objMenu, FullPathImagem.Trim());
                }
                catch (Exception oEx)
                {
                    throw new Erro(oEx.Message, "Base", "Base.cs", GetType().FullName.ToString(), "Executar(string strXml, System.Web.UI.WebControls.Menu objMenu, string FullPathImagem)", "Base.log");
                }
            }

            public void Executar(XmlDocument objXml, System.Web.UI.WebControls.Menu objMenu, string FullPathImagem)
            {
                try
                {
                    foreach (XmlNode objXmlNode in objXml.SelectNodes("/itens/item"))
                    {
                        ExecutarChild(objXmlNode, null, objMenu, FullPathImagem);
                    }
                }
                catch (Exception oEx)
                {
                    throw new Erro(oEx.Message, "Base", "Base.cs", GetType().FullName.ToString(), "Executar(XmlDocument objXml, System.Web.UI.WebControls.Menu objMenu, string FullPathImagem)", "Base.log");
                }
            }

            private void ExecutarChild(XmlNode objXmlNode, System.Web.UI.WebControls.MenuItem objMenuItem, System.Web.UI.WebControls.Menu objMnu, string Imagem)
            {
                try
                {
                    int intNivel = -1;
                    string strText = "Nó com problema";
                    string strValue = "";
                    string strURL = "";
                    string strTarget = "";
                    string strImageUrl = "";
                    string strToolTip = "";
                    System.Web.UI.WebControls.MenuItem objMenuItemBase;

                    if ((objXmlNode.NodeType == XmlNodeType.Text) || ((objXmlNode.NodeType == XmlNodeType.XmlDeclaration) && (objMenuItem == null))) { return; }

                    if (objXmlNode.Attributes["nivel"] != null) { intNivel = int.Parse(objXmlNode.Attributes["nivel"].Value.Trim()); }
                    if (objXmlNode.Attributes["text"] != null) { strText = objXmlNode.Attributes["text"].Value.Trim(); }
                    if (objXmlNode.Attributes["value"] != null) { strValue = objXmlNode.Attributes["value"].Value.Trim(); }
                    if (objXmlNode.Attributes["url"] != null) { strURL = objXmlNode.Attributes["url"].Value.Trim().Replace("[#*#]", "&"); }
                    if (objXmlNode.Attributes["target"] != null) { strTarget = objXmlNode.Attributes["target"].Value.Trim(); }
                    if (objXmlNode.Attributes["imageurl"] != null) { strImageUrl = objXmlNode.Attributes["imageurl"].Value.Trim(); }
                    if (objXmlNode.Attributes["tooltip"] != null) { strToolTip = objXmlNode.Attributes["tooltip"].Value.Trim(); }

                    objMenuItemBase = new System.Web.UI.WebControls.MenuItem();
                    if (strText.Trim() != "") { objMenuItemBase.Text = strText.Trim(); }
                    if (strValue.Trim() != "") { objMenuItemBase.Value = strValue.Trim(); }
                    if (strURL.Trim() != "") { objMenuItemBase.NavigateUrl = strURL.Trim(); }
                    if (strToolTip.Trim() != "") { objMenuItemBase.ToolTip = strToolTip.Trim(); }

                    if (strImageUrl.Trim() != "")
                    {
                        objMenuItemBase.ImageUrl = strImageUrl.Trim();
                    }
                    else if (objXmlNode.HasChildNodes && Imagem.Trim() != "")
                    {
                        objMenuItemBase.ImageUrl = Imagem.Trim();
                    }


                    if (objMenuItemBase.NavigateUrl.Trim() == "")
                    {
                        objMenuItemBase.Selectable = false;
                    }
                    else
                    {
                        if (strTarget.Trim() != "") { objMenuItemBase.Target = strTarget.Trim(); }
                        objMenuItemBase.Selectable = true;
                    }

                    if (objMenuItem == null || intNivel == 0)
                    {
                        objMnu.Items.Add(objMenuItemBase);
                    }
                    else
                    {
                        objMenuItem.ChildItems.Add(objMenuItemBase);
                    }

                    if (objXmlNode.HasChildNodes)
                    {
                        foreach (XmlNode objXmlNodeSub in objXmlNode.ChildNodes)
                        {
                            ExecutarChild(objXmlNodeSub, objMenuItemBase, objMnu, Imagem);
                        }
                    }
                }
                catch (Exception oEx)
                {
                    throw new Erro(oEx.Message, "Base", "Base.cs", GetType().FullName.ToString(), "ExecutarChild(XmlNode objXmlNode, System.Web.UI.WebControls.MenuItem objMenuItem, System.Web.UI.WebControls.Menu objMnu, string Imagem)", "Base.log");
                }
            }

            #endregion

            #region TreeView

            #region Exemplo de XML que deve ser passado
            //<?xml version="1.0" encoding="ISO-8859-1"?>
            //<itens>
            //    <item nivel="0" text="Texto 1" value="1" url=""  target="" imageurl="" tooltip="">
            //        <item nivel="1" text="Texto 10" value="10" url="" target="" imageurl="" tooltip="">
            //            <item nivel="2" text="Texto 100" value="100" url="http://intrabmfbovespa/" target="Corpo" imageurl="" tooltip=""/>
            //        </item>
            //    </item>
            //    <item nivel="0" text="Texto 2" value="2" url="" target="" imageurl="" tooltip="">
            //        <item nivel="1" text="Texto 20" value="20" url="http://www.bovespa.com.br/Principal.asp" target="Corpo" imageurl="" tooltip=""/>
            //    </item>
            //    <item nivel="0" text="Texto 3" value="3" url="" target="" imageurl="" tooltip="">
            //        <item nivel="1" text="Texto 30" value="30" url="DivideTAB.aspx" target="Corpo" imageurl="" tooltip=""/>
            //    </item>
            //</itens>
            #endregion

            public void Executar(string strXml, System.Web.UI.WebControls.TreeView objTreeView)
            {
                try
                {
                    XmlDocument objXml = new XmlDocument();
                    objXml.LoadXml(strXml);
                    Executar(objXml, objTreeView, string.Empty);
                }
                catch (Exception oEx)
                {
                    throw new Erro(oEx.Message, "Base", "Base.cs", GetType().FullName.ToString(), "Executar(string strXml, System.Web.UI.WebControls.TreeView objTreeView)", "Base.log");
                }
            }

            public void Executar(XmlDocument objXml, System.Web.UI.WebControls.TreeView objTreeView)
            {
                try
                {
                    Executar(objXml, objTreeView, string.Empty);
                }
                catch (Exception oEx)
                {
                    throw new Erro(oEx.Message, "Base", "Base.cs", GetType().FullName.ToString(), "Executar(XmlDocument objXml, System.Web.UI.WebControls.TreeView objTreeView)", "Base.log");
                }
            }

            public void Executar(string strXml, System.Web.UI.WebControls.TreeView objTreeView, string FullPathImagem)
            {
                try
                {
                    XmlDocument objXml = new XmlDocument();
                    objXml.LoadXml(strXml);
                    Executar(objXml, objTreeView, FullPathImagem.Trim());
                }
                catch (Exception oEx)
                {
                    throw new Erro(oEx.Message, "Base", "Base.cs", GetType().FullName.ToString(), "Executar(string strXml, System.Web.UI.WebControls.TreeView objTreeView, string FullPathImagem))", "Base.log");
                }
            }

            public void Executar(XmlDocument objXml, System.Web.UI.WebControls.TreeView objTreeView, string FullPathImagem)
            {
                try
                {
                    foreach (XmlNode objXmlNode in objXml.SelectNodes("/itens/item"))
                    {
                        ExecutarChild(objXmlNode, null, objTreeView, FullPathImagem);
                    }
                }
                catch (Exception oEx)
                {
                    throw new Erro(oEx.Message, "Base", "Base.cs", GetType().FullName.ToString(), "Executar(XmlDocument objXml, System.Web.UI.WebControls.TreeView objTreeView, string FullPathImagem)", "Base.log");
                }
            }

            private void ExecutarChild(XmlNode objXmlNode, System.Web.UI.WebControls.TreeNode objTreeNode, System.Web.UI.WebControls.TreeView objTV, string Imagem)
            {
                try
                {
                    int intNivel = -1; ;
                    string strText = "Nó com problema";
                    string strValue = "";
                    string strURL = "";
                    string strTarget = "";
                    string strImageUrl = "";
                    string strToolTip = "";
                    System.Web.UI.WebControls.TreeNode objTreeNodeBase;

                    if ((objXmlNode.NodeType == XmlNodeType.Text) || ((objXmlNode.NodeType == XmlNodeType.XmlDeclaration) && (objTreeNode == null))) { return; }

                    if (objXmlNode.Attributes["nivel"] != null) { intNivel = int.Parse(objXmlNode.Attributes["nivel"].Value.Trim()); }
                    if (objXmlNode.Attributes["text"] != null) { strText = objXmlNode.Attributes["text"].Value.Trim(); }
                    if (objXmlNode.Attributes["value"] != null) { strValue = objXmlNode.Attributes["value"].Value.Trim(); }
                    if (objXmlNode.Attributes["url"] != null) { strURL = objXmlNode.Attributes["url"].Value.Trim().Replace("[#*#]", "&"); }
                    if (objXmlNode.Attributes["target"] != null) { strTarget = objXmlNode.Attributes["target"].Value.Trim(); }
                    if (objXmlNode.Attributes["imageurl"] != null) { strImageUrl = objXmlNode.Attributes["imageurl"].Value.Trim(); }
                    if (objXmlNode.Attributes["tooltip"] != null) { strToolTip = objXmlNode.Attributes["tooltip"].Value.Trim(); }

                    objTreeNodeBase = new System.Web.UI.WebControls.TreeNode();
                    if (strText.Trim() != "") { objTreeNodeBase.Text = strText.Trim(); }
                    if (strValue.Trim() != "") { objTreeNodeBase.Value = strValue.Trim(); }
                    if (strURL.Trim() != "") { objTreeNodeBase.NavigateUrl = strURL.Trim(); }
                    if (strToolTip.Trim() != "") { objTreeNodeBase.ToolTip = strToolTip.Trim(); }

                    if (strImageUrl.Trim() != "")
                    {
                        objTreeNodeBase.ImageUrl = strImageUrl.Trim();
                    }
                    else if (objXmlNode.HasChildNodes && Imagem.Trim() != "")
                    {
                        objTreeNodeBase.ImageUrl = Imagem.Trim();
                    }

                    if (objTreeNodeBase.NavigateUrl.Trim() == "")
                    {
                        objTreeNodeBase.SelectAction = TreeNodeSelectAction.None;
                    }
                    else
                    {
                        if (strTarget.Trim() != "") { objTreeNodeBase.Target = strTarget.Trim(); }
                        objTreeNodeBase.SelectAction = TreeNodeSelectAction.Select;
                    }

                    if (objTreeNode == null || intNivel == 0)
                    {
                        objTV.Nodes.Add(objTreeNodeBase);
                    }
                    else
                    {
                        objTreeNode.ChildNodes.Add(objTreeNodeBase);
                    }

                    if (objXmlNode.HasChildNodes)
                    {
                        foreach (XmlNode objXmlNodeSub in objXmlNode.ChildNodes)
                        {
                            ExecutarChild(objXmlNodeSub, objTreeNodeBase, objTV, Imagem);
                        }
                    }
                }
                catch (Exception oEx)
                {
                    throw new Erro(oEx.Message, "Base", "Base.cs", GetType().FullName.ToString(), "ExecutarChild(XmlNode objXmlNode, System.Web.UI.WebControls.TreeNode objTreeNode, System.Web.UI.WebControls.TreeView objTV, string Imagem)", "Base.log");
                }
            }

            #endregion
        }
    }

    public class Funcoes : Base.Framework.Generico.Funcoes { }

    public class WebConfig
    {
        public string Ler(string Chave)
        {
            if (ConfigurationManager.AppSettings[Chave.Trim()] != null)
            {
                return ConfigurationManager.AppSettings[Chave.Trim()].Trim();
            }
            else
            {
                return "";
            }
        }

        public string[,] ListarConnectionStrings(bool Selecione)
        {
            string[,] lista = new string[ConfigurationManager.ConnectionStrings.Count + (Selecione ? 1 : 0), 2];
            if (Selecione)
            {
                lista[0, 1] = "Selecione...";
                lista[0, 0] = string.Empty;
            }
            for (int i = 0; i < ConfigurationManager.ConnectionStrings.Count; i++)
            {
                lista[i + (Selecione ? 1 : 0), 1] = ConfigurationManager.ConnectionStrings[i].Name.Trim();
                lista[i + (Selecione ? 1 : 0), 0] = ConfigurationManager.ConnectionStrings[i].ToString().Trim();
            }

            return lista;
        }
    }

    public class Excel
    {
        public void Download(DataSet objDS)
        {
            try
            {
                GridView objGV = new GridView();
                objGV.DataSource = objDS;
                objGV.DataBind();

                Download(objGV);
            }
            catch (Erro oErro)
            {
                throw new Erro(oErro.Mensagem);
            }
        }

        public void Download(string NomePlanilha, DataSet objDS)
        {
            try
            {
                GridView objGV = new GridView();
                objGV.DataSource = objDS;
                objGV.DataBind();

                Download(NomePlanilha.Trim(), objGV);
            }
            catch (Erro oErro)
            {
                throw new Erro(oErro.Mensagem);
            }
        }

        public void Download(DataSet objDS, int Index)
        {
            try
            {
                GridView objGV = new GridView();
                objGV.DataSource = objDS.Tables[Index];
                objGV.DataBind();

                Download(objGV);
            }
            catch (Erro oErro)
            {
                throw new Erro(oErro.Mensagem);
            }
        }

        public void Download(string NomePlanilha, DataSet objDS, int Index)
        {
            try
            {
                GridView objGV = new GridView();
                objGV.DataSource = objDS.Tables[Index];
                objGV.DataBind();

                Download(NomePlanilha.Trim(), objGV);
            }
            catch (Erro oErro)
            {
                throw new Erro(oErro.Mensagem);
            }
        }

        public void Download(DataSet objDS, string NameDS)
        {
            try
            {
                GridView objGV = new GridView();
                objGV.DataSource = objDS.Tables[NameDS];
                objGV.DataBind();

                Download(objGV);
            }
            catch (Erro oErro)
            {
                throw new Erro(oErro.Mensagem);
            }
        }

        public void Download(string NomePlanilha, DataSet objDS, string NameDS)
        {
            try
            {
                GridView objGV = new GridView();
                objGV.DataSource = objDS.Tables[NameDS];
                objGV.DataBind();

                Download(NomePlanilha.Trim(), objGV);
            }
            catch (Erro oErro)
            {
                throw new Erro(oErro.Mensagem);
            }
        }

        public void Download(GridView objGV)
        {
            try
            {
                Download("Planilha", objGV);
            }
            catch (Erro oErro)
            {
                throw new Erro(oErro.Mensagem);
            }
        }

        public void Download(string NomePlanilha, GridView objGV)
        {
            try
            {
                if (objGV.Rows.Count + 1 > 65535)
                {
                    throw new Erro("A quantidade máxima de linhas para uma planilha excel é 65535.");
                }

                StringWriter stringWrite = new StringWriter();
                HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
                HtmlForm form = new HtmlForm();
                Boolean booAllowPaging = objGV.AllowPaging;

                objGV.AllowPaging = false;
                objGV.DataBind();

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + NomePlanilha.Trim() + ".xls");
                HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";

                form.Controls.Add(objGV);
                objGV.RenderControl(htmlWrite);

                objGV.AllowPaging = booAllowPaging;
                objGV.DataBind();

                HttpContext.Current.Response.Write(stringWrite.ToString());
                HttpContext.Current.Response.End();
            }
            catch (Erro oErro)
            {
                throw new Erro(oErro.Mensagem);
            }
        }
    }
}

