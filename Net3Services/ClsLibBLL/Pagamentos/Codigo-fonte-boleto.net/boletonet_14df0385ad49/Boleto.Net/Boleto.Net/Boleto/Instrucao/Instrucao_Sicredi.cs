using System;
using System.Collections;
using System.Text;

namespace BoletoNet
{
    #region Enumerado

    public enum EnumInstrucoes_Sicredi
    {
        CadastroDeTitulo = 1,                      
        PedidoBaixa = 2,                  
        ConcessaoAbatimento = 4,
        CancelamentoAbatimentoConcedido = 5,
        AlteracaoVencimento = 6,
        PedidoProtesto = 9,
        SustarProtestoBaixarTitulo = 18,
        SustarProtestoManterCarteira = 19,
        AlteracaoOutrosDados = 31,
    }

    #endregion 

    public class Instrucao_Sicredi: AbstractInstrucao, IInstrucao
    {

        #region Construtores 

		public Instrucao_Sicredi()
		{
			try
			{
                this.Banco = new Banco(748);
			}
			catch (Exception ex)
			{
                throw new Exception("Erro ao carregar objeto", ex);
			}
		}

        public Instrucao_Sicredi(int codigo)
        {
            this.carregar(codigo, 0);
        }

        public Instrucao_Sicredi(int codigo, int nrDias)
        {
            this.carregar(codigo, nrDias);
        }

		#endregion 

        #region Metodos Privados

        private void carregar(int idInstrucao, int nrDias)
        {
            try
            {
                this.Banco = new Banco_Sicredi();
                this.Valida();
                this.Codigo = idInstrucao;

          

                this.QuantidadeDias = nrDias;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar objeto", ex);
            }
        }

        public override void Valida()
        {
            //base.Valida();
        }

        #endregion

    }
}
