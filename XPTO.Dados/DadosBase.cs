using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Base.Framework.Generico;
using Base.Framework.WindowsForm;
using XPTO.Entidades;

namespace XPTO.Dados
{
    public class DadosBase : IDisposable
    {
        #region | Variáveis

        public AppConfig _appConfig = new AppConfig();
        public Criptografia _cripto = new Criptografia();
        public Base.Util.Funcoes _funcoes = new Base.Util.Funcoes();

        #endregion | Variáveis

        #region | Métodos Auxiliares

        protected void GravarLogErro(string mensagem)
        {
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame(1);

            throw new Erro(mensagem,
                           _appConfig.Ler("NomeProjeto").Trim(),
                           stackFrame.GetMethod().Module.FullyQualifiedName.Trim(),
                           stackFrame.GetMethod().ReflectedType.FullName.Trim(),
                           stackFrame.GetMethod().ToString(),
                           _appConfig.Ler("NomeArqLog").Trim());
        }

        #endregion | Métodos Auxiliares

        #region | Retornar Valor

        public string RetornoSimNao(bool? valor)
        {
            return valor == null ? string.Empty : (bool)valor ? "S" : "N";
        }

        public string RetornoSimNao(bool valor)
        {
            return valor ? "S" : "N";
        }

        public string RetornarCampo(object valor, string campo)
        {
            string retorno = campo;

            try
            {
                if (valor != null)
                {
                    if (valor != DBNull.Value)
                    {
                        retorno = valor.ToString();
                    }
                }
            }
            catch
            {
                retorno = campo;
            }

            return retorno;
        }

        public bool RetornarCampo(object valor, bool campo)
        {
            bool retorno = campo;

            try
            {
                if (valor != null && !DBNull.Value.Equals(valor))
                {
                    if (valor.ToString().Trim().ToUpper() == "S" || valor.ToString().Trim().ToUpper() == "N")
                    {
                        retorno = (valor.ToString().Trim().ToUpper() == "S");
                    }
                    else
                    {
                        if (!bool.TryParse(valor.ToString(), out retorno))
                            retorno = false;
                    }
                }
            }
            catch
            {
                retorno = campo;
            }

            return retorno;
        }

        public DateTime RetornarCampo(object valor, DateTime campo)
        {
            DateTime retorno = campo;

            try
            {
                if (valor != null)
                {
                    if (valor != DBNull.Value)
                    {
                        if (!DateTime.TryParse(valor.ToString(), out retorno))
                        {
                            retorno = campo;
                        }
                    }
                }
            }
            catch
            {
                retorno = campo;
            }

            return retorno;
        }

        public decimal RetornarCampo(object valor, decimal campo)
        {
            decimal retorno = campo;

            try
            {
                if (valor != null)
                {
                    if (valor != DBNull.Value)
                    {
                        if (!decimal.TryParse(valor.ToString(), out retorno))
                        {
                            retorno = campo;
                        }
                    }
                }
            }
            catch
            {
                retorno = campo;
            }

            return retorno;
        }

        public double RetornarCampo(object valor, double campo)
        {
            double retorno = campo;

            try
            {
                if (valor != null)
                {
                    if (valor != DBNull.Value)
                    {
                        if (!double.TryParse(valor.ToString(), out retorno))
                        {
                            retorno = campo;
                        }
                    }
                }
            }
            catch
            {
                retorno = campo;
            }

            return retorno;
        }

        public float RetornarCampo(object valor, float campo)
        {
            float retorno = campo;

            try
            {
                if (valor != null)
                {
                    if (valor != DBNull.Value)
                    {
                        if (!float.TryParse(valor.ToString(), out retorno))
                        {
                            retorno = campo;
                        }
                    }
                }
            }
            catch
            {
                retorno = campo;
            }

            return retorno;
        }

        public int RetornarCampo(object valor, int campo)
        {
            int retorno = campo;

            try
            {
                if (valor != null)
                {
                    if (valor != DBNull.Value)
                    {
                        if (!int.TryParse(valor.ToString(), out retorno))
                        {
                            retorno = campo;
                        }
                    }
                }
            }
            catch
            {
                retorno = campo;
            }

            return retorno;
        }

        public short RetornarCampo(object valor, short campo)
        {
            short retorno = campo;

            try
            {
                if (valor != null)
                {
                    if (valor != DBNull.Value)
                    {
                        if (!short.TryParse(valor.ToString(), out retorno))
                        {
                            retorno = campo;
                        }
                    }
                }
            }
            catch
            {
                retorno = campo;
            }

            return retorno;
        }

        public long RetornarCampo(object valor, long campo)
        {
            long retorno = campo;

            try
            {
                if (valor != null)
                {
                    if (valor != DBNull.Value)
                    {
                        if (!long.TryParse(valor.ToString(), out retorno))
                        {
                            retorno = campo;
                        }
                    }
                }
            }
            catch
            {
                retorno = campo;
            }

            return retorno;
        }

        #endregion | Retornar Valor

        #region | IDisposable Members

        private bool _isDisposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DadosBase()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
                if (disposing)
                {
                    this.Dispose();
                }
            }
        }

        #endregion | IDisposable Members
    }
}
