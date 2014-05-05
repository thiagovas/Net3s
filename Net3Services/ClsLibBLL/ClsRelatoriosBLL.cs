using ClsLibDAL;
using Models;

namespace ClsLibBLL
{
    public delegate void RelatorioBLL(Relatorio relat);

    public class ClsRelatoriosBLL
    {
        //ClsRelatorioDAL dalRelat;

        #region === Crud ===

        /// <summary>
        /// Método utilizado para inserir relatórios no banco de dados
        /// </summary>
        /// <param name="relatorio">Instância da classe relatório</param>
        public void InserirRelatorio(Relatorio relatorio)
        { 
            //todo: Implementar método para adicionar relatório
        }

        /// <summary>
        /// Método que edita relatórios no banco de dados
        /// </summary>
        /// <param name="relatorio">Instância da classe relatório</param>
        public void EditarRelatorio(Relatorio relatorio)
        {
            //todo: Implementar método para adicionar relatório
        }

        /// <summary>
        /// Método utilizado para excluír relatórios
        /// </summary>
        /// <param name="relatorio">Instância da classe relatório</param>
        public void ExcluirRelatorio(Relatorio relatorio)
        { 
            //todo: Implementar método para excluir algum relatório
        }

        #endregion
    }
}
