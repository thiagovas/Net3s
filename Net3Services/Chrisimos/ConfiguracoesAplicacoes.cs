using System;
using Microsoft.Win32;

namespace Chrisimos
{
    public class ConfiguracoesAplicacoes
    {
        //WriteRegistry(Registry.CurrentUser, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "Nome do seu software", "c:\Caminho\seu_soft.exe");
        private void SetStartup(string NomeAplicacao, bool habilitar, string caminhoAplicacao)
        {
            string runKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

            RegistryKey startupKey = Registry.LocalMachine.OpenSubKey(runKey, true);

            if (habilitar)
            {
                try
                {
                    if (startupKey == null)
                        startupKey = Registry.LocalMachine.CreateSubKey(runKey);

                    if (startupKey.GetValue(NomeAplicacao) == null)
                    {
                        startupKey.Close();
                        startupKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(runKey, true);
                        startupKey.SetValue(NomeAplicacao.Trim(), caminhoAplicacao.Trim());
                        startupKey.Close();
                    }
                }
                catch (UnauthorizedAccessException)
                { throw new UnauthorizedAccessException("Você não tem autorização para gravar uma chave no registro do Windows."); }
                catch(Exception ex)
                { throw ex; }
            }
            else
            {
                startupKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(runKey, true);
                startupKey.DeleteValue(NomeAplicacao, false);
                startupKey.Close();
            }
        }
    }
}
