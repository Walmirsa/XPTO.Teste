using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Base.Framework.WindowsForm;
using Base.Framework.Generico;
using XPTO.Entidades;


namespace XPTO.Negocios
{
    public class NegocioBase : IDisposable
    {
        #region | Variáveis

        public Base.Util.Funcoes _funcoes = new Base.Util.Funcoes();
        public Criptografia _cripto = new Criptografia();
        public AppConfig _appConfig = new AppConfig();
        public string _conexaoSQL = string.Empty;

       
        #endregion | Variáveis

        #region | Construtores

        public NegocioBase() 
        {
            _conexaoSQL = _appConfig.Ler("ConexaoSQL").Trim();
        }

        #endregion | Construtores

        #region | Auditoria
       
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

        #region | IDisposable Members

        private bool _isDisposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~NegocioBase()
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
