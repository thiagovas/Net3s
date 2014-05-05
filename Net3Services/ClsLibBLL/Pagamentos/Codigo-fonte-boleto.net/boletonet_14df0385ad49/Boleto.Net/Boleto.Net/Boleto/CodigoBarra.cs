using System;
using System.Drawing;
using Microsoft.VisualBasic;

namespace BoletoNet
{
    public class CodigoBarra
    {
        private string _codigo = "";
        private string _linhaDigitavel = "";
        private Image _imagem = null;
        private string _chave = "";

        /// <summary>
        /// C�digo de Barra
        /// </summary>
        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public Image Imagem
        {
            get { return _imagem; }
        }

        /// <summary>
        /// Retorna a representa��o num�rica do c�digo de barra
        /// </summary>
        public string LinhaDigitavel
        {
            get{return _linhaDigitavel;}
            set{_linhaDigitavel = value;}
        }

        /// <summary>
        /// Chave para montar Codigo de Barra
        /// </summary>
        public string Chave
        {
            get { return _chave; }
            set { _chave = value; }
        }

        private string FormataLinhaDigitavel(string _codigo)
        {
            try
            {
                string cmplivre;
                string campo1;
                string campo2;
                string campo3;
                string campo4;
                string campo5;
                long icampo5;
                int digitoMod;

                cmplivre = Strings.Mid(_codigo, 20, 25);
                campo1 = Strings.Left(_codigo, 4) + Strings.Mid(cmplivre, 1, 5);
                digitoMod = AbstractBanco.Mod10(campo1);
                campo1 = campo1 + digitoMod.ToString();
                campo1 = Strings.Mid(campo1, 1, 5) + "." + Strings.Mid(campo1, 6, 5);

                campo2 = Strings.Mid(cmplivre, 6, 10);
                digitoMod = AbstractBanco.Mod10(campo2);
                campo2 = campo2 + digitoMod.ToString();
                campo2 = Strings.Mid(campo2, 1, 5) + "." + Strings.Mid(campo2, 6, 6);

                campo3 = Strings.Mid(cmplivre, 16, 10);
                digitoMod = AbstractBanco.Mod10(campo3);
                campo3 = campo3 + digitoMod;
                campo3 = Strings.Mid(campo3, 1, 5) + "." + Strings.Mid(campo3, 6, 6);

                campo4 = Strings.Mid(_codigo, 5, 1);

                icampo5 = Convert.ToInt64(Strings.Mid(_codigo, 6, 14));

                if (icampo5 == 0)
                    campo5 = "000";
                else
                    campo5 = icampo5.ToString();

                return campo1 + "  " + campo2 + "  " + campo3 + "  " + campo4 + "  " + campo5;
            }
            catch
            {
                throw new Exception("C�digo de barras inv�lido");
            }
        }
    }
}
