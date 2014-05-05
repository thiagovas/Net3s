using System;
using System.Collections.Generic;

namespace BoletoNet
{
    public class Boletos : List<Boleto>
    {

        # region Vari�veis

        private Banco _banco;
        private ContaBancaria _contaBancaria;
        private Cedente _cedente;

        # endregion

        # region Propriedades

        public Banco Banco
        { 
            get { return _banco; }
            set { this._banco = value; }
        }

        public ContaBancaria contaBancaria
        {
            get { return _contaBancaria; }
            set { this._contaBancaria = value; }
        }

        public Cedente Cedente
        {
            get { return _cedente; }
            set { this._cedente = value; }
        }

        # endregion

        # region M�todos

        /// <summary>
        /// Verifica se j� existe o arquivo relativo a remessa, caso n�o exista � criado um arquivo ".rem".
        /// 
        /// O padr�o dos arquivos de Remessa e Retorno, obedece as regras estabelecidas pelo C.N.A.B. (Centro Nacional
        /// de Automa��o Banc�ria) e dever� ser gravado contendo:
        /// Registro Header : Primeiro registro do Arquivo contendo a identifica��o da empresa
        /// Registro Detalhe : Registro contendo as informa��es de Pagamentos :
        /// - Inclus�o de compromissos
        /// - Altera��o de Compromissos
        /// - Pagamentos Efetuados
        /// - Bloqueios / Desbloqueios
        /// Registro Trailer : �ltimo registro indicando finaliza��o do Arquivo
        /// Caracteres obrigat�rios = 0D 0A (Final de Registro) 0D 0A 1A (Final de Arquivo)
        /// </summary>

        private new void Add(Boleto item)
        {
            if (item.Banco == null)
                throw new Exception("Boleto n�o possui Banco.");

            if (item.ContaBancaria == null)
                throw new Exception("Boleto n�o possui conta banc�ria.");

            if (item.Cedente == null)
                throw new Exception("Boleto n�o possui cedente.");

            item.Valida();
            this.Add(item);
        }

        # endregion

    }
}
