using System;
using Microsoft.Win32;

namespace Chrisimos
{
    public class CregistroWindows
    {
        /// <summary>
        /// Este método escreve uma chave no registro do windows.
        /// </summary>
        /// <param name="parentKey">Nó do registro do Windows. Exemplo: Microsoft.Win32.Registry.LocalMachine</param>
        /// <param name="subKey">Nome ou caminho da subkey onde irá ser gravada a chave.</param>
        /// <param name="valueName">Nome da chave</param>
        /// <param name="value">Valor da chave</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public static void EscreverChave(RegistryKey parentKey, string subKey, string valueName, object value)
        {
            RegistryKey key;
            try
            {
                key = parentKey.OpenSubKey(subKey.Trim(), true);
                if (key == null)
                    key = parentKey.CreateSubKey(subKey.Trim());

                key.SetValue(valueName.Trim(), value);
                key.Close();
            }
            catch (UnauthorizedAccessException)
            { throw new UnauthorizedAccessException("O registro não existe e você não tem permissão para criar um neste local."); }
            catch (Exception e)
            { throw e; }
        }

        /// <summary>
        /// Este método busca uma chave do registro do Windows.
        /// </summary>
        /// <param name="parentKey">Nó do registro do Windows. Exemplo: Microsoft.Win32.Registry.LocalMachine</param>
        /// <param name="subKey">Nome ou caminho da subKey onde irá ser buscada a chave.</param>
        /// <param name="valueName">Nome da chave.</param>
        /// <returns>Retorna um object que contém o valor da chave.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public static object BuscarChave(RegistryKey parentKey, string subKey, string valueName)
        {
            RegistryKey key;
            try
            {
                key = parentKey.OpenSubKey(subKey.Trim(), false);
                if (key == null)
                    throw new Exception("O registro não foi encontrado.");

                object retorno = new object();
                retorno = key.GetValue(valueName.Trim());
                key.Close();
                return retorno;
            }
            catch (UnauthorizedAccessException)
            { throw new UnauthorizedAccessException("Você não tem permissão para realizar esta busca."); }
            catch (Exception ex)
            { throw ex; }
        }

        /// <summary>
        /// Este método deleta uma chave do registro do Windows.
        /// </summary>
        /// <param name="parentKey">Nó do registro do Windows. Exemplo: Microsoft.Win32.Registry.LocalMachine</param>
        /// <param name="subKey">Nome ou caminho da subKey onde a chave se localiza.</param>
        /// <param name="valueName">Nome da chave.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public static void DeletarChave(RegistryKey parentKey, string subKey, string valueName)
        {
            RegistryKey key;
            try
            {
                key = parentKey.OpenSubKey(subKey.Trim(), true);
                if (key == null)
                    throw new Exception("O registro não foi encontrado.");

                key.DeleteValue(valueName.Trim());
                key.Close();
            }
            catch (UnauthorizedAccessException)
            { throw new UnauthorizedAccessException("Você não tem permissão para excluir esta chave."); }
            catch (Exception ex)
            { throw ex; }
        }

        /// <summary>
        /// Este método cria um registro no registro do Windows.
        /// </summary>
        /// <param name="parentKey">Nó do registro do Windows. Exemplo: Microsoft.Win32.Registry.LocalMachine</param>
        /// <param name="subKey">Nome ou caminho da subKey onde a chave se localiza.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public static void CriarRegistro(RegistryKey parentKey, string subKey)
        {
            RegistryKey key;
            try
            {
                key = parentKey.OpenSubKey(subKey.Trim());
                if (key != null)
                    throw new Exception("O registro já existe.");

                key.CreateSubKey(subKey.Trim());
                key.Close();
            }
            catch (UnauthorizedAccessException)
            { throw new UnauthorizedAccessException("Voçê não tem permissão para criar um registro neste local."); }
            catch(Exception ex)
            { throw ex; }
        }

        /// <summary>
        /// Este método deleta um registro do registro do Windows.
        /// </summary>
        /// <param name="parentKey">Nó do registro do Windows. Exemplo: Microsoft.Win32.Registry.LocalMachine</param>
        /// <param name="subKey">Nome ou caminho da subKey onde a chave se localiza.</param>
        /// <param name="valueName">Nome da chave.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public static void DeletarRegistro(RegistryKey parentKey, string subKey, string valueName)
        {
            RegistryKey key;
            try
            {
                key = parentKey.OpenSubKey(subKey.Trim(), true);
                if (key == null)
                    throw new Exception("A subkey informada não foi encontrada no registro do Windows.");
                
                key.DeleteSubKey(subKey.Trim());
                key.Close();
            }
            catch (UnauthorizedAccessException)
            { throw new UnauthorizedAccessException("O Windows não permitiu a exclusão do registro."); }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
