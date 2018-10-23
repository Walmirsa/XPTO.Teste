using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Base.Framework.WindowsForm;
using Base.Framework.Generico;

namespace Base.Util
{
    public class Funcoes : Base.Framework.WindowsForm.Funcoes
    {
        private Framework.Generico.Funcoes _funcoes = new Framework.Generico.Funcoes();
        private AppConfig _appConfig = new AppConfig();
        private Criptografia _cripto = new Criptografia();

        private const string _chaveCripto = "678168462987674183761532468910350";
        private Color _corFundo = Color.LightSteelBlue;

        public string ChaveCripto
        {
            get { return _chaveCripto; }
        }

        public Color CorFundo
        {
            get { return _corFundo; }
        }

        public void CriptografiaStringToArquivo(string texto, string arquivoDestino, bool encriptar) { CriptografiaStringToArquivo(texto, arquivoDestino, encriptar, false); }
        public void CriptografiaStringToArquivo(string texto, string arquivoDestino, bool encriptar, bool sobreescrever) 
        {
            if (!string.IsNullOrEmpty(texto.Trim()) && !string.IsNullOrEmpty(arquivoDestino.Trim()))
            {
                if (File.Exists(arquivoDestino)) 
                {
                    if (sobreescrever)
                    {
                        File.Delete(arquivoDestino);
                    }
                    else
                    {
                        throw new Erro(string.Concat("Arquivo '", arquivoDestino.Trim(), "' já existe."));
                    }
                }
                using (StreamWriter sw = new StreamWriter(arquivoDestino.Trim(), true, Encoding.Unicode))
                {
                    string textoNEW = _cripto.Executar(texto, _chaveCripto, Criptografia.TipoNivel.Médio, encriptar ? Criptografia.TipoAcao.Encriptar : Criptografia.TipoAcao.Decriptar, Criptografia.TipoCripto.Números);
                    sw.WriteLine(textoNEW);
                    sw.Close();
                }
            }
        }

        public string CriptografiaArquitoToString(string arquivoOrigem, bool encriptar) 
        {
            string retorno = string.Empty;
            if (!string.IsNullOrEmpty(arquivoOrigem.Trim())) 
            {
                if (!File.Exists(arquivoOrigem.Trim())) { throw new Erro(string.Concat("Arquivo '", arquivoOrigem.Trim(), "' não localizado.")); }
                using (StreamReader sr = new StreamReader(arquivoOrigem.Trim(), Encoding.UTF7)) 
                {
                    while (!sr.EndOfStream)
                    {
                        string linhaOrigem = sr.ReadLine();
                        string linhaDestino = _cripto.Executar(linhaOrigem, _chaveCripto, Criptografia.TipoNivel.Médio, encriptar ? Criptografia.TipoAcao.Encriptar : Criptografia.TipoAcao.Decriptar, Criptografia.TipoCripto.Números);
                        retorno = string.Concat(retorno, linhaDestino);
                    }
                }
            }
            return retorno;
        }


        public void CriptografiaArquivo(string arquivo, bool encriptar) { CriptografiaArquivo(arquivo, arquivo, encriptar); }
        public void CriptografiaArquivo(string arquivoOrigem, string arquivoDestino, bool encriptar)
        {
            if (string.IsNullOrEmpty(arquivoOrigem.Trim())) { throw new Erro("Obrigatório informar o arquivo."); }
            if (!File.Exists(arquivoOrigem.Trim())) { throw new Erro("Arquivo não localizado."); }

            string nomeD = arquivoOrigem.Trim() == arquivoDestino.Trim() ? string.Concat(arquivoDestino.Trim(), "_TEMP") : arquivoDestino.Trim();

            using (StreamReader sr = new StreamReader(arquivoOrigem.Trim(), Encoding.UTF7))
            {
                using (StreamWriter sw = new StreamWriter(nomeD.Trim(), true, Encoding.Unicode))
                {
                    while (!sr.EndOfStream)
                    {
                        string linhaOrigem = sr.ReadLine();
                        string linhaDestino = _cripto.Executar(linhaOrigem, _chaveCripto, Criptografia.TipoNivel.Médio, encriptar ? Criptografia.TipoAcao.Encriptar : Criptografia.TipoAcao.Decriptar, Criptografia.TipoCripto.Números);
                        sw.WriteLine(linhaDestino);
                    }
                    sr.Close();
                    sw.Close();
                }
            }

            if (arquivoOrigem.Trim() == arquivoDestino.Trim()) 
            {
                File.Delete(arquivoOrigem.Trim());
                File.Move(nomeD.Trim(), arquivoOrigem.Trim());
            }
        }

        public string GetConnectionStringsSQL(string itemConexao) 
        {
            //return GetConnectionStringsSQL(itemConexao, Criptografia.TipoAcao.Decriptar);
            return GetConnectionStringsSQL(itemConexao, Criptografia.TipoAcao.Decriptar);
        }

        public string GetConnectionStringsSQL(string itemConexao, Criptografia.TipoAcao tipoAcao)
        {
            string conexaoTratada = string.Empty;
            string conexao = ConfigurationManager.ConnectionStrings[itemConexao.Trim()].ToString();
            return conexao;
        } 

        public string GetConnectionStringsAccess(string itemConexao, bool appPath)
        {
            return GetConnectionStringsAccess(itemConexao, Criptografia.TipoAcao.Decriptar, appPath);
        }

        public string GetConnectionStringsAccess(string itemConexao, Criptografia.TipoAcao tipoAcao, bool usarAppPath)
        {
            string conexaoTratada = string.Empty;
            string[] conexao = ConfigurationManager.ConnectionStrings[itemConexao.Trim()].ToString().Split(';');
            foreach (string item in conexao)
            {
                if (!string.IsNullOrEmpty(item.Trim()))
                {
                    string[] parametro = item.Trim().Split('=');
                    if (parametro[0].Trim().ToUpper() == "DATA SOURCE")
                    {
                        parametro[1] = _cripto.Executar(parametro[1].Trim(), _chaveCripto, Criptografia.TipoNivel.Baixo, tipoAcao, Criptografia.TipoCripto.Números);
                        if (usarAppPath) 
                        {
                            if (parametro[1].Substring(0, 1) == @"\") { parametro[1] = parametro[1].Substring(1); }
                            parametro[1] = Path.Combine(_funcoes.AppPath(), parametro[1]); 
                        }
                    }
                    else if (parametro[0].Trim().ToUpper() == "JET OLEDB:DATABASE PASSWORD")
                    {
                        parametro[1] = _cripto.Executar(parametro[1].Trim(), _chaveCripto, Criptografia.TipoNivel.Baixo, tipoAcao, Criptografia.TipoCripto.Números);
                    }
                    conexaoTratada = string.Concat(conexaoTratada.Trim(), parametro[0].Trim(), "=", parametro[1].Trim(), ";");
                }
            }
            return conexaoTratada.Trim();
        }

        public string LimparNumDocto(string numDocto) 
        {
            return numDocto.Replace(".", "").Replace("-", "").Replace("/", "");
        }

        public void SomarProgressBar(ProgressBar progressBar)
        {
            if ((progressBar.Value + 1) <= progressBar.Maximum)
            {
                progressBar.Value = progressBar.Value + 1;
            }
            else
            {
                progressBar.Value = progressBar.Maximum;
            }
        }

        public void mascaraCaixa(object sender)
        {
            string texto = ((TextBox)sender).Text.Replace(".", "");
            string textoFormatado = string.Empty;
            int i = 1;
            foreach (char c in texto.ToCharArray())
            {
                textoFormatado += c;
                if (i > 0 & i % 2 == 0 && i < 12)
                    textoFormatado += ".";
                i++;
            }
            ((TextBox)sender).Text = textoFormatado;
            ((TextBox)sender).SelectionStart = textoFormatado.Length;
            ((TextBox)sender).SelectionLength = 0;
        }

        //public void CentralizaHeaderDGV(DataGridView dataGridView) 
        //{
        //    for (int i = 0; i < dataGridView.Columns.Count; i++)
        //    {
        //        dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
        //        dataGridView.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    }
        //}
    }
}
