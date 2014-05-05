using System.Runtime.InteropServices;
using System;
using System.Text;

namespace Chrisimos
{
    public class AcoesPc
    {
        [DllImport("winmm.dll")]
        static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

        public void AbrirCd()
        {
            StringBuilder returnstring = new StringBuilder();

            // Guardei a resposta do metodo so pra saber o que ele retorna
            // Não tem função nenhuma
            int resposta = mciSendString("set CDAudio door open", returnstring, 127, IntPtr.Zero);
        }

        public void FecharCd()
        {
            StringBuilder strb = new StringBuilder();
            
            // Guardei a resposta do metodo so pra saber o que ele retorna
            // Não tem função nenhuma
            int resposta = mciSendString("set CDAudio door closed", strb, 127, IntPtr.Zero);
        }

        public void BloquearPortaUsb()
        {
            //Implementar método
            //Thiago Vieira
            throw new NotImplementedException();
        }

        public void TirarPrintScreen()
        {
            //Implementar método
            //Thiago Vieira
            throw new NotImplementedException(); 
        }
    }
}
