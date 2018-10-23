using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Xml;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using Base.Framework.Generico;

namespace Base.Framework.WindowsForm
{
    namespace Objetos
    {
        public class Preencher
        {
            #region TreeView

            #region Exemplo de XML que deve ser passado
            //<?xml version="1.0" encoding="ISO-8859-1"?>
            //<itens>
            //    <item nivel="0" text="Texto 1" tag="1" imageindex="" selectedimageindex="" tooltip="">
            //        <item nivel="1" text="Texto 10" tag="" imageindex="2" selectedimageindex="2" tooltip="">
            //            <item nivel="2" text="Texto 100" tag="" imageindex="1" selectedimageindex="0" tooltip=""/>
            //        </item>
            //    </item>
            //    <item nivel="0" text="Texto 2" tag="" imageindex="" selectedimageindex="" tooltip="">
            //        <item nivel="1" text="Texto 20" tag="" imageindex="" selectedimageindex="" tooltip=""/>
            //    </item>
            //    <item nivel="0" text="Texto 3" tag="" imageindex="" selectedimageindex="" tooltip="">
            //        <item nivel="1" text="Texto 30" tag="" imageindex="" selectedimageindex="" tooltip=""/>
            //    </item>
            //</itens>
            #endregion

            public void Executar(string strXml, System.Windows.Forms.TreeView objTreeView)
            {
                try
                {
                    XmlDocument objXml = new XmlDocument();
                    objXml.LoadXml(strXml);
                    Executar(objXml, objTreeView, -1, -1);
                }
                catch (Exception oEx)
                {
                    throw new Erro(oEx.Message, "Base", "Base.cs", "Base.WindowsForm.Objetos.Preencher", "Executar(string strXml, System.Windows.Forms.TreeView objTreeView)", "Base.log");
                }
            }

            public void Executar(XmlDocument objXml, System.Windows.Forms.TreeView objTreeView)
            {
                try
                {
                    Executar(objXml, objTreeView, -1, -1);
                }
                catch (Exception oEx)
                {
                    throw new Erro(oEx.Message, "Base", "Base.cs", "Base.WindowsForm.Objetos.Preencher", "Executar(XmlDocument objXml, System.Windows.Forms.TreeView objTreeView)", "Base.log");
                }
            }

            public void Executar(string strXml, System.Windows.Forms.TreeView objTreeView, int intImageIndex, int intSelectedImageIndex)
            {
                try
                {
                    XmlDocument objXml = new XmlDocument();
                    objXml.LoadXml(strXml);
                    Executar(objXml, objTreeView, intImageIndex, intSelectedImageIndex);
                }
                catch (Exception oEx)
                {
                    throw new Erro(oEx.Message, "Base", "Base.cs", "Base.WindowsForm.Objetos.Preencher", "Executar(string strXml, System.Windows.Forms.TreeView objTreeView, int intImageIndex, int intSelectedImageIndex)", "Base.log");
                }
            }

            public void Executar(XmlDocument objXml, System.Windows.Forms.TreeView objTreeView, int intImageIndex, int intSelectedImageIndex)
            {
                try
                {
                    foreach (XmlNode objXmlNode in objXml.SelectNodes("/itens/item"))
                    {
                        ExecutarChild(objXmlNode, null, objTreeView, intImageIndex, intSelectedImageIndex);
                    }
                }
                catch (Exception oEx)
                {
                    throw new Erro(oEx.Message, "Base", "Base.cs", "Base.WindowsForm.Objetos.Preencher", "Executar(XmlDocument objXml, System.Windows.Forms.TreeView objTreeView, int intImageIndex, int intSelectedImageIndex)", "Base.log");
                }
            }

            private void ExecutarChild(XmlNode objXmlNode, System.Windows.Forms.TreeNode objTreeNode, System.Windows.Forms.TreeView objTV, int ImageIndex, int SelectedImageIndex)
            {
                try
                {
                    int intNivel = -1;
                    string strText = "Nó com problema";
                    string strTag = "";
                    string strtooltiptext = "";
                    int intImageIndex = -1;
                    int intSelectedImageIndex = -1;
                    System.Windows.Forms.TreeNode objTreeNodeBase;

                    if ((objXmlNode.NodeType == XmlNodeType.Text) || ((objXmlNode.NodeType == XmlNodeType.XmlDeclaration) && (objTreeNode == null))) { return; }

                    if (objXmlNode.Attributes["nivel"] != null) { intNivel = int.Parse(objXmlNode.Attributes["nivel"].Value.Trim()); }
                    if (objXmlNode.Attributes["text"] != null) { strText = objXmlNode.Attributes["text"].Value.Trim(); }
                    if (objXmlNode.Attributes["tag"] != null) { strTag = objXmlNode.Attributes["tag"].Value.Trim(); }
                    if (objXmlNode.Attributes["tooltip"] != null) { strtooltiptext = objXmlNode.Attributes["tooltip"].Value.Trim(); }

                    objTreeNodeBase = new System.Windows.Forms.TreeNode();
                    if (strText.Trim() != "") { objTreeNodeBase.Text = strText.Trim(); }
                    if (strTag.Trim() != "") { objTreeNodeBase.Tag = strTag.Trim(); }
                    if (strtooltiptext.Trim() != "") { objTreeNodeBase.ToolTipText = strtooltiptext.Trim(); }

                    if (int.TryParse(objXmlNode.Attributes["imageindex"].Value, out intImageIndex))
                    {
                        objTreeNodeBase.ImageIndex = intImageIndex;
                    }
                    else if (ImageIndex >= 0)
                    {
                        objTreeNodeBase.ImageIndex = ImageIndex;
                    }

                    if (int.TryParse(objXmlNode.Attributes["selectedimageindex"].Value, out intSelectedImageIndex))
                    {
                        objTreeNodeBase.SelectedImageIndex = intSelectedImageIndex;
                    }
                    else if (ImageIndex >= 0)
                    {
                        objTreeNodeBase.SelectedImageIndex = SelectedImageIndex;
                    }

                    if (objTreeNode == null || intNivel == 0)
                    {
                        objTV.Nodes.Add(objTreeNodeBase);
                    }
                    else
                    {
                        objTreeNode.Nodes.Add(objTreeNodeBase);
                    }

                    if (objXmlNode.HasChildNodes)
                    {
                        foreach (XmlNode objXmlNodeSub in objXmlNode.ChildNodes)
                        {
                            ExecutarChild(objXmlNodeSub, objTreeNodeBase, objTV, ImageIndex, SelectedImageIndex);
                        }
                    }
                }
                catch (Exception oEx)
                {
                    throw new Erro(oEx.Message, "Base", "Base.cs", "Base.WindowsForm.Objetos.Preencher", "ExecutarChild(XmlNode objXmlNode, System.Windows.Forms.TreeNode objTreeNode, System.Windows.Forms.TreeView objTV, int ImageIndex, int SelectedImageIndex)", "Base.log");
                }
            }

            #endregion
        }
    }

    public class Impressao
    {
        #region | Exemplo
        //Declarar variáveis abaixo no escopo da classe
        //public Impressao _impressao = new Impressao();
        //public PrintDocument _printDocument = new PrintDocument();

        //private void bttImprimir_Click(object sender, EventArgs e)
        //{
        //    if (dgvDados.Rows.Count <= 0) { return; }

        //    _impressao.LimparMemoria();
        //    _impressao.InserirTitulo(string.Concat("Recebimento no Período de ", _dataIni, " até ", _dataFim));
        //    _impressao.InserirCabecalho(string.Concat("Recebimento |   Pedido   | Cliente                            | Valor"));
        //    for (int i = 0; i < dgvDados.Rows.Count; i++)
        //    {
        //        _impressao.InserirLinhaDetalhe(string.Concat(dgvDados.Rows[i].Cells[0].Value.ToString().Trim(), "  | ", dgvDados.Rows[i].Cells[1].Value.ToString().Trim(), " | ", _funcoes.Left(string.Concat(dgvDados.Rows[i].Cells[2].Value.ToString().Trim(), _funcoes.Espaco(34)), 34), " | R$ ", _funcoes.Right(string.Concat(_funcoes.Espaco(10), dgvDados.Rows[i].Cells[3].Value.ToString().Trim()), 10)));
        //    }
        //    _impressao.InserirRodape(string.Concat(_funcoes.Espaco(52), "Valor Total R$ ", _funcoes.Right(string.Concat(_funcoes.Espaco(10), _valorTOtal), 10)));
        //    _printDocument = new PrintDocument();
        //    _printDocument.PrintPage += new PrintPageEventHandler(this._printDocument_PrintPage);
        //    _printDocument.Print();
        //}

        //private void _printDocument_PrintPage(object sender, PrintPageEventArgs ev)
        //{
        //    _impressao.Imprimir(ref ev, _printDocument.DefaultPageSettings.Landscape, true, false);
        //}
        #endregion | Exemplo

        long _paginaImpressao = 0;
        List<string> _titulo = new List<string>();
        List<string> _cabecalho = new List<string>();
        List<string> _linhasDetalhe = new List<string>();
        List<string> _rodape = new List<string>();

        Funcoes _funcoes = new Funcoes();

        public void LimparMemoria()
        {
            _paginaImpressao = 0;
            _titulo = new List<string>();
            _cabecalho = new List<string>();
            _linhasDetalhe = new List<string>();
            _rodape = new List<string>();
        }

        public void InserirTitulo(string texto) { _titulo.Add(texto); }
        public void InserirCabecalho(string texto) { _cabecalho.Add(texto); }
        public void InserirLinhaDetalhe(string texto) { _linhasDetalhe.Add(texto); }
        public void InserirRodape(string texto) { _rodape.Add(texto); }

        public void Imprimir(ref PrintPageEventArgs ev, bool landScape, bool centralizarTitulo)
        {
            Imprimir(ref  ev, landScape, 0, centralizarTitulo, false);
        }
        public void Imprimir(ref PrintPageEventArgs ev, bool landScape, bool centralizarTitulo, bool centralizatRodape)
        {
            Imprimir(ref  ev, landScape, 0, centralizarTitulo, centralizatRodape);
        }
        public void Imprimir(ref PrintPageEventArgs ev, bool landScape, long quantidadeLinhasPorPagina, bool centralizarTitulo)
        {
            Imprimir(ref  ev, landScape, quantidadeLinhasPorPagina, centralizarTitulo, false);
        }
        public void Imprimir(ref PrintPageEventArgs ev, bool landScape, long quantidadeLinhasPorPagina, bool centralizarTitulo, bool centralizatRodape)
        {
            Font font = new Font("Courier New", 12);
            Font fontNegrito = new Font("Courier New", 12, FontStyle.Bold);
            float qtdMaxColunas = landScape ? 110 : 77;
            int larguraPagina = landScape ? 1168 : 826;
            int alturaLinha = 15;
            float larguraLetra = (float)10.33;
            long qtdMaxLinhas = (landScape ? 55 : 78) - 3 - _titulo.Count - _cabecalho.Count;
            if (quantidadeLinhasPorPagina != 0 && quantidadeLinhasPorPagina < qtdMaxLinhas) { qtdMaxLinhas = quantidadeLinhasPorPagina; }
            long qtdMaxLinhasRodape = qtdMaxLinhas;
            if (_linhasDetalhe.Count < qtdMaxLinhas && _linhasDetalhe.Count > 0) { qtdMaxLinhas = _linhasDetalhe.Count; }
            int altura = 0;
            int alturaRodape = 0;
            int iLinha = 0;

            #region | Título
            ImprimirCaixa(ev, new Pen(Brushes.Black), new Rectangle(10, 10, ((20 * _titulo.Count) - (_titulo.Count * 2)), (larguraPagina - 10)));
            _paginaImpressao++;
            ev.Graphics.DrawString(_funcoes.Right(string.Concat("000", _paginaImpressao.ToString()), 3), fontNegrito, Brushes.Black, larguraPagina - 50, 11);
            for (int iTitulo = 0; iTitulo < _titulo.Count; iTitulo++)
            {
                if (centralizarTitulo)
                {
                    ev.Graphics.DrawString(_titulo[iTitulo], fontNegrito, Brushes.Black, (((qtdMaxColunas - (float)_titulo[iTitulo].Length) / (float)2) * larguraLetra), (11 + (iTitulo * alturaLinha)));
                }
                else
                {
                    ev.Graphics.DrawString(_titulo[iTitulo], fontNegrito, Brushes.Black, 15, (11 + (iTitulo * alturaLinha)));
                }
            }
            #endregion | Título

            #region | Cabeçalho & Linhas Detalhe
            if (_linhasDetalhe.Count > 0)
            {
                #region | Cabeçalho
                altura = ((20 * _titulo.Count) - (_titulo.Count * 2)) + 15;
                ImprimirCaixa(ev, new Pen(Brushes.Black), new Rectangle(10, altura, ((20 * _cabecalho.Count) - (_cabecalho.Count * 2)), (larguraPagina - 10)));
                for (int iCabecalho = 0; iCabecalho < _cabecalho.Count; iCabecalho++)
                {
                    ev.Graphics.DrawString(_cabecalho[iCabecalho], fontNegrito, Brushes.Black, 15, (altura + (iCabecalho * alturaLinha)));
                }
                #endregion | Cabeçalho

                #region | Linhas Detalhe
                altura = altura + ((20 * _cabecalho.Count) - (_cabecalho.Count * 2)) + 5;
                alturaRodape = altura;
                for (iLinha = 0; iLinha < qtdMaxLinhas; iLinha++)
                {
                    if (_linhasDetalhe[0].Trim() == "<#LinhaSimples#>")
                    {
                        ev.Graphics.DrawString(_funcoes.Caracter((long)qtdMaxColunas, "-"), font, Brushes.Black, 15, altura + (iLinha * alturaLinha));
                    }
                    else if (_linhasDetalhe[0].Trim() == "<#LinhaDupla#>")
                    {
                        ev.Graphics.DrawString(_funcoes.Caracter((long)qtdMaxColunas, "="), font, Brushes.Black, 15, altura + (iLinha * alturaLinha));
                    }
                    else
                    {
                        ev.Graphics.DrawString(_linhasDetalhe[0], font, Brushes.Black, 15, altura + (iLinha * alturaLinha));
                    }
                    _linhasDetalhe.Remove(_linhasDetalhe[0]);
                    alturaRodape = ((altura + (iLinha * alturaLinha)) + (alturaLinha * 2));
                }
                #endregion | Linhas Detalhe
            }
            #endregion | Cabeçalho & Linhas Detalhe

            #region | Rodapé
            if (_rodape.Count > 0 && _linhasDetalhe.Count <= 0 && (iLinha + (_rodape.Count + 2)) <= qtdMaxLinhasRodape)
            {
                if (alturaRodape == 0) { alturaRodape = ((20 * _titulo.Count) - (_titulo.Count * 2)) + 15; }
                int qtdRodape = _rodape.Count;
                ImprimirCaixa(ev, new Pen(Brushes.Black), new Rectangle(10, alturaRodape, ((20 * qtdRodape) - (_rodape.Count * 2)), (larguraPagina - 10)));
                for (int iRodape = 0; iRodape < qtdRodape; iRodape++)
                {
                    if (centralizatRodape)
                    {
                        ev.Graphics.DrawString(_rodape[0], fontNegrito, Brushes.Black, (((qtdMaxColunas - (float)_rodape[0].Length) / (float)2) * larguraLetra), (alturaRodape + (iRodape * alturaLinha)));
                    }
                    else
                    {
                        ev.Graphics.DrawString(_rodape[0], fontNegrito, Brushes.Black, 15, (alturaRodape + (iRodape * alturaLinha)));
                    }
                    _rodape.Remove(_rodape[0]);
                }
            }
            #endregion | Rodapé

            ev.HasMorePages = _linhasDetalhe.Count > 0 || _rodape.Count > 0;
        }

        private void ImprimirCaixa(PrintPageEventArgs ev, Pen pen, Rectangle rectangle)
        {
            ev.Graphics.DrawLine(pen, new Point(rectangle.X, rectangle.Y), new Point(rectangle.Height, rectangle.Y)); //Superior
            ev.Graphics.DrawLine(pen, new Point(rectangle.Height, rectangle.Y), new Point(rectangle.Height, (rectangle.Y + rectangle.Width))); //Direita
            ev.Graphics.DrawLine(pen, new Point(rectangle.X, (rectangle.Y + rectangle.Width)), new Point(rectangle.Height, (rectangle.Y + rectangle.Width))); //Inferior
            ev.Graphics.DrawLine(pen, new Point(rectangle.X, rectangle.Y), new Point(rectangle.X, (rectangle.Y + rectangle.Width))); //Esquerda
        }
    }

    public class Funcoes : Base.Framework.Generico.Funcoes
    {
        public enum TipoTextoOK { Conter, Nao_Conter }

        public void BackColorDMI(Form mdiForm, Color color)
        {
            foreach (Control control in mdiForm.Controls)
            {
                if (control is MdiClient)
                {
                    control.BackColor = color;
                    break;
                }
            }
        }

        public void CentralizaHeadersDGV(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        public void FormataTextBoxValor(TextBox textBox, int qtdDec)
        {
            //private void TextBox1_TextChanged(object sender, EventArgs e)
            //{
            //    if (_pular) { return; }
            //    _pular = true;
            //    _funcoes.FormataTextBoxValor((TextBox)sender, 2);
            //    _pular = false;
            //}

            int selectionStartAntes = textBox.SelectionStart;
            int tamanho = textBox.Text.Trim().Length;

            string texto = textBox.Text.Trim().Replace(",", string.Empty).Replace(".", string.Empty);
            long aux = 0;
            if (!long.TryParse(texto, out aux)) { return; }
            texto = aux.ToString();
            string textoFormatado = string.Empty;
            for (int i = 0; i < texto.Trim().Length; i++)
            {
                if (char.IsDigit(texto, i)) { textoFormatado = string.Concat(textoFormatado.Trim(), texto.Substring(i, 1)); }
            }
            if (!string.IsNullOrEmpty(textoFormatado.Trim()))
            {
                if (textoFormatado.Trim().Length <= qtdDec)
                {
                    for (int i = tamanho; i < qtdDec; i++)
                    {
                        textoFormatado = string.Concat("0", textoFormatado.Trim());
                    }
                    textoFormatado = string.Concat("0,", textoFormatado.Trim());
                }
                else
                {
                    textoFormatado = string.Concat(long.Parse(textoFormatado.Substring(0, textoFormatado.Trim().Length - qtdDec)).ToString("###,###,###"), ",", Right(textoFormatado.Trim(), qtdDec));
                }
            }

            textBox.Text = textoFormatado.Trim();
            int selectionStartDepois = (selectionStartAntes + textBox.Text.Trim().Length - tamanho) > 0 ? (selectionStartAntes + textBox.Text.Trim().Length - tamanho) : 0;
            textBox.Select(selectionStartDepois, 0);
        }

        public string InputBox(string prompt, string title) { return InputBox(prompt, title, string.Empty, -1, -1); }
        public string InputBox(string prompt, string title, string defaultResponse) { return InputBox(prompt, title, defaultResponse, -1, -1); }
        public string InputBox(string prompt, string title, int x, int y) { return InputBox(prompt, title, string.Empty, x, y); }
        public string InputBox(string prompt, string title, string defaultResponse, int x, int y) 
        {
            return Microsoft.VisualBasic.Interaction.InputBox(prompt, title, defaultResponse, x, y);
        }

        public void TelaCheia(Form form) 
        {
            form.Location = new Point(0, 0);
            form.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        public void RecebeFoco(TextBox obj, Color cor)
        {
            obj.BackColor = cor;
            obj.SelectAll();
        }

        public void RecebeFoco(MaskedTextBox obj, Color cor)
        {
            obj.BackColor = cor;
            obj.SelectAll();
        }

        public void RecebeFoco(ComboBox obj, Color cor)
        {
            obj.BackColor = cor;
        }

        public void RecebeFoco(ListBox obj, Color cor)
        {
            obj.BackColor = cor;
        }

        public void PerdeFoco(TextBox obj)
        {
            obj.BackColor = Color.White;
        }

        public void PerdeFoco(MaskedTextBox obj)
        {
            obj.BackColor = Color.White;
        }

        public void PerdeFoco(ComboBox obj)
        {
            obj.BackColor = Color.White;
        }

        public void PerdeFoco(ListBox obj)
        {
            obj.BackColor = Color.White;
        }

        public void ExibirErro(string Mensagem, string Titulo)
        {
            MessageBox.Show(Mensagem.Trim(), Titulo.Trim(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ExibirErro(string Mensagem, string Titulo, Form objForm)
        {
            MessageBox.Show(Mensagem.Trim(), Titulo.Trim(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            objForm.Hide();
            objForm.Close();
        }

        public void ExibirInformacao(string Mensagem, string Titulo)
        {
            MessageBox.Show(Mensagem.Trim(), Titulo.Trim(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ExibirInformacao(string Mensagem, string Titulo, System.Windows.Forms.Form objForm)
        {
            MessageBox.Show(Mensagem.Trim(), Titulo.Trim(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            objForm.Hide();
            objForm.Close();
        }

        public void ExibirExclamacao(string Mensagem, string Titulo)
        {
            MessageBox.Show(Mensagem.Trim(), Titulo.Trim(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
       
        public void ExibirExclamacao(string Mensagem, string Titulo, Form objForm)
        {
            MessageBox.Show(Mensagem.Trim(), Titulo.Trim(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            objForm.Hide();
            objForm.Close();
        }

        public bool ExibirConfirmacao(string Mensagem, string Titulo)
        {
            if (MessageBox.Show(Mensagem.Trim(),
                                Titulo.Trim(),
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ExibirConfirmacao(string Mensagem, string Titulo, Form objForm)
        {
            if (MessageBox.Show(Mensagem.Trim(),
                                Titulo.Trim(),
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                objForm.Hide();
                objForm.Close();

                return false;
            }
        }

        public bool TextoOK(KeyPressEventArgs e)
        {
            return ((int)e.KeyChar != 34 && (int)e.KeyChar != 39);
        }

        public bool TextoOK(KeyPressEventArgs e, string Texto, TipoTextoOK Tipo)
        {
            if (Tipo == TipoTextoOK.Conter)
            {
                if (Texto.IndexOf(e.KeyChar, 0) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (Tipo == TipoTextoOK.Nao_Conter)
            {
                if (Texto.IndexOf(e.KeyChar, 0) > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class AppConfig
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

        public void Gravar(string Path, string File, string Chave, string Valor)
        {
            try
            {
                string FullPathName = "";

                if (Path.Trim().Substring(Path.Trim().Length - 1, 1) != "\\") { Path = Path.Trim() + "\\"; }

                XmlDocument objXml = new XmlDocument();
                objXml.Load(FullPathName + File);
                objXml.SelectSingleNode("/configuration/appSettings/add[@key='" + Chave + "']").Attributes["value"].InnerText = Valor;
                objXml.Save(FullPathName + File);

                if (Path.ToUpper().Trim().Substring(Path.Trim().Length - 11, 11) == "\\BIN\\DEBUG\\" || Path.ToUpper().Trim().Substring(Path.Trim().Length - 13, 13) == "\\BIN\\RELEASE\\")
                {
                    //Atualiza também o App.config, se estiver sendo executado pelo executável
                    string PathAppConfig = "";
                    string[] arrPath;
                    arrPath = Path.Split(new char[] { '\\' });
                    for (int intFor = 0; intFor <= arrPath.Length - 4; intFor++)
                    {
                        PathAppConfig = PathAppConfig.Trim() + arrPath[intFor] + "\\";
                    }
                    PathAppConfig = PathAppConfig.Trim() + "App.config";

                    if (System.IO.File.Exists(PathAppConfig))
                    {
                        XmlDocument objXmlDesenv = new XmlDocument();
                        objXmlDesenv.Load(PathAppConfig);
                        objXmlDesenv.SelectSingleNode("/configuration/appSettings/add[@key='" + Chave + "']").Attributes["value"].InnerText = Valor;
                        objXmlDesenv.Save(PathAppConfig);
                    }
                }
            }
            catch (Exception oEx)
            {
                throw new Erro(oEx.Message, "Base", "Base.cs", GetType().FullName.ToString(), "Gravar(PathFile/Chave/Valor)", "Base.log");
            }
        }
    }

    namespace Graficos
    {
        public class Dados
        {
            #region | Variáveis
            string _descricao = string.Empty;
            long _quantidade = 0;
            float _percentual = 0;
            string _cor = string.Empty;
            bool _totalizar = true;
            #endregion | Variáveis

            #region | Construtores
            public Dados() { }

            public Dados(string descricao, long quantidade, float percentual, string cor)
            {
                _descricao = descricao;
                _quantidade = quantidade;
                _percentual = percentual;
                _cor = cor;
            }

            public Dados(string descricao, long quantidade, float percentual, string cor, bool totalizar)
            {
                _descricao = descricao;
                _quantidade = quantidade;
                _percentual = percentual;
                _cor = cor;
                _totalizar = totalizar;
            }
            #endregion | Construtores

            #region | Get/Set
            public string Descricao
            {
                get { return _descricao; }
                set { _descricao = value; }
            }

            public long Quantidade
            {
                get { return _quantidade; }
                set { _quantidade = value; }
            }

            public float Percentual
            {
                get { return _percentual; }
                set { _percentual = value; }
            }

            public string Cor
            {
                get { return _cor; }
                set { _cor = value; }
            }

            public bool Totalizar
            {
                get { return _totalizar; }
                set { _totalizar = value; }
            }
            #endregion | Get/Set
        }

        public class Pizza
        {
            #region | Sobrecarga com Form como owner
            public void Executar(Form owner, List<Dados> dados, int xCenter, int yCenter, string titulo, bool totalGeral, bool caixa, bool limpar) 
            {
                Executar(owner, null, dados, 100, xCenter, yCenter, titulo, totalGeral, caixa, 0, 0, limpar);
            }
            public void Executar(Form owner, List<Dados> dados, int xCenter, int yCenter, string titulo, bool totalGeral, bool caixa, long widthCaixa, bool limpar)
            {
                Executar(owner, null, dados, 100, xCenter, yCenter, titulo, totalGeral, caixa, widthCaixa, 0, limpar);
            }
            public void Executar(Form owner, List<Dados> dados, int xCenter, int yCenter, string titulo, bool totalGeral, bool caixa, int heightCaixa, bool limpar)
            {
                Executar(owner, null, dados, 100, xCenter, yCenter, titulo, totalGeral, caixa, 0, heightCaixa, limpar);
            }
            public void Executar(Form owner, List<Dados> dados, int xCenter, int yCenter, string titulo, bool totalGeral, bool caixa, long widthCaixa, int heightCaixa, bool limpar)
            {
                Executar(owner, null, dados, 100, xCenter, yCenter, titulo, totalGeral, caixa, widthCaixa, heightCaixa, limpar);
            }
            public void Executar(Form owner, List<Dados> dados, float radius, int xCenter, int yCenter, string titulo, bool totalGeral, bool caixa, bool limpar)
            {
                Executar(owner, null, dados, radius, xCenter, yCenter, titulo, totalGeral, caixa, 0, 0, limpar);
            }
            public void Executar(Form owner, List<Dados> dados, float radius, int xCenter, int yCenter, string titulo, bool totalGeral, bool caixa, long widthCaixa, bool limpar)
            {
                Executar(owner, null, dados, radius, xCenter, yCenter, titulo, totalGeral, caixa, widthCaixa, 0, limpar);
            }
            public void Executar(Form owner, List<Dados> dados, float radius, int xCenter, int yCenter, string titulo, bool totalGeral, bool caixa, int heightCaixa, bool limpar)
            {
                Executar(owner, null, dados, radius, xCenter, yCenter, titulo, totalGeral, caixa, 0, heightCaixa, limpar);
            }
            #endregion | Sobrecarga com Form como owner

            #region | Sobrecarga com TabPage como owner
            public void Executar(TabPage owner, List<Dados> dados, int xCenter, int yCenter, string titulo, bool totalGeral, bool caixa, bool limpar)
            {
                Executar(null, owner, dados, 100, xCenter, yCenter, titulo, totalGeral, caixa, 0, 0, limpar);
            }
            public void Executar(TabPage owner, List<Dados> dados, int xCenter, int yCenter, string titulo, bool totalGeral, bool caixa, long widthCaixa, bool limpar)
            {
                Executar(null, owner, dados, 100, xCenter, yCenter, titulo, totalGeral, caixa, widthCaixa, 0, limpar);
            }
            public void Executar(TabPage owner, List<Dados> dados, int xCenter, int yCenter, string titulo, bool totalGeral, bool caixa, int heightCaixa, bool limpar)
            {
                Executar(null, owner, dados, 100, xCenter, yCenter, titulo, totalGeral, caixa, 0, heightCaixa, limpar);
            }
            public void Executar(TabPage owner, List<Dados> dados, int xCenter, int yCenter, string titulo, bool totalGeral, bool caixa, long widthCaixa, int heightCaixa, bool limpar)
            {
                Executar(null, owner, dados, 100, xCenter, yCenter, titulo, totalGeral, caixa, widthCaixa, heightCaixa, limpar);
            }
            public void Executar(TabPage owner, List<Dados> dados, float radius, int xCenter, int yCenter, string titulo, bool totalGeral, bool caixa, bool limpar)
            {
                Executar(null, owner, dados, radius, xCenter, yCenter, titulo, totalGeral, caixa, 0, 0, limpar);
            }
            public void Executar(TabPage owner, List<Dados> dados, float radius, int xCenter, int yCenter, string titulo, bool totalGeral, bool caixa, long widthCaixa, bool limpar)
            {
                Executar(null, owner, dados, radius, xCenter, yCenter, titulo, totalGeral, caixa, widthCaixa, 0, limpar);
            }
            public void Executar(TabPage owner, List<Dados> dados, float radius, int xCenter, int yCenter, string titulo, bool totalGeral, bool caixa, int heightCaixa, bool limpar)
            {
                Executar(null, owner, dados, radius, xCenter, yCenter, titulo, totalGeral, caixa, 0, heightCaixa, limpar);
            }
            #endregion | Sobrecarga com TabPage como owner

            private void Executar(Form ownerForm, TabPage ownerTabPage, List<Dados> dados, float radius, int xCenter, int yCenter, string titulo, bool totalGeral, bool caixa, long widthCaixa, int heightCaixa, bool limpar)
            {
                Funcoes funcoes = new Funcoes();
                Graphics myGraphics = null;
                Font fontOwnerTitulo = null;
                Font fontOwner = null;
                if (ownerForm != null)
                {
                    myGraphics = ownerForm.CreateGraphics();
                    fontOwnerTitulo = new Font(ownerForm.Font.Name, 20, FontStyle.Bold | FontStyle.Underline | FontStyle.Italic);
                    fontOwner = new Font(ownerForm.Font.Name, 9, FontStyle.Bold);
                }
                else
                {
                    myGraphics = ownerTabPage.CreateGraphics();
                    fontOwnerTitulo = new Font(ownerTabPage.Font.Name, 20, FontStyle.Bold | FontStyle.Underline | FontStyle.Italic);
                    fontOwner = new Font(ownerTabPage.Font.Name, 9, FontStyle.Bold);
                }
                float percent1 = 0;
                float percent2 = 0;
                float x = xCenter - radius;
                float y = yCenter - radius;
                float width = radius * 2;
                float height = radius * 2;
                long quantidadeTotal = 0;

                if (limpar) 
                { 
                    if (ownerForm != null)
                    {
                        myGraphics.Clear(ownerForm.BackColor);
                    }
                    else
                    {
                        myGraphics.Clear(ownerTabPage.BackColor);
                    }
                }

                #region | Gráfico
                for (int i = 0; i < dados.Count; i++)
                {
                    if (dados[i].Totalizar)
                    {
                        if (i >= 1) { percent1 += dados[i - 1].Percentual; }
                        percent2 += dados[i].Percentual;
                        float angle1 = percent1 / 100 * 360;
                        float angle2 = percent2 / 100 * 360;
                        Brush b = new SolidBrush(Color.FromName(dados[i].Cor));
                        myGraphics.FillPie(b, x, y, width, height, angle1, angle2 - angle1);
                    }
                }
                myGraphics.DrawEllipse(new Pen(Color.Black), x, y, width, height);
                #endregion | Gráfico

                #region | Legendas
                float xpos = x + width + 20;
                float ypos = y + 10;
                for (int i = 0; i < dados.Count; i++)
                {
                    if (dados[i].Totalizar)
                    {
                        quantidadeTotal = quantidadeTotal + dados[i].Quantidade;
                    }
                    myGraphics.FillRectangle(new SolidBrush(Color.FromName(dados[i].Cor)), xpos, ypos - 10, 15, 15);
                    myGraphics.DrawRectangle(new Pen(Color.Black), xpos, ypos - 10, 15, 15);
                    if (dados[i].Totalizar)
                    {
                        myGraphics.DrawString(string.Concat(funcoes.Right(string.Concat("  ", dados[i].Percentual.ToString("##0")), 3), "%",
                                                            " - ",
                                                            funcoes.Right(string.Concat(funcoes.Espaco(9), dados[i].Quantidade.ToString("###,##0")), 9),
                                                            " - ",
                                                            dados[i].Descricao.Trim()), new Font("Courier New", 9, FontStyle.Bold),
                                                                                        new SolidBrush(Color.Black),
                                                                                        xpos + 25,
                                                                                        ypos - 10);
                    }
                    else
                    {
                        myGraphics.DrawString(string.Concat(funcoes.Espaco(7),
                                                            funcoes.Right(string.Concat(funcoes.Espaco(9), dados[i].Quantidade.ToString("###,##0")), 9),
                                                            " - ",
                                                            dados[i].Descricao.Trim()), new Font("Courier New", 9, FontStyle.Bold),
                                                                                        new SolidBrush(Color.Black),
                                                                                        xpos + 25,
                                                                                        ypos - 10);
                    }
                    ypos += 20;
                }
                #endregion | Legendas

                #region | Título
                if (!string.IsNullOrEmpty(titulo.Trim())) 
                {
                    myGraphics.DrawString(titulo.Trim(),
                                          fontOwnerTitulo, 
                                          new SolidBrush(Color.Black),
                                          xCenter,
                                          yCenter - radius - 50);
                }
                #endregion | Título

                #region | Total Geral
                if (totalGeral) 
                {
                    if (!caixa)
                    {
                        myGraphics.DrawString(string.Concat("Total de Documentos: ", quantidadeTotal.ToString("###,##0")),
                                              fontOwner,
                                              new SolidBrush(Color.Black),
                                              xCenter + 50,
                                              yCenter + radius + 10);
                    }
                    else
                    {
                        myGraphics.DrawString(string.Concat("Total de Documentos: ", quantidadeTotal.ToString("###,##0")),
                                              fontOwner,
                                              new SolidBrush(Color.Black),
                                              xCenter + 50,
                                              heightCaixa);
                    }
                }
                #endregion | Total Geral

                #region | Caixa
                if (caixa)
                {
                    if (widthCaixa == 0) { widthCaixa = 600; }
                    if (heightCaixa == 0) { heightCaixa = 300; }
                    myGraphics.DrawRectangle(new Pen(Color.Black), xCenter - radius - 10, yCenter - radius - 60, widthCaixa, heightCaixa);
                }
                #endregion | Caixa

                myGraphics.Dispose();
            }
           
        }
    }
}


