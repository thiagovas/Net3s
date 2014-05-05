using System;
using System.Collections.Generic;
using System.Text;

namespace BoletoNet
{
    //public class EspecieDocumento_Sicredi : AbstractEspecieDocumento, IEspecieDocumento
    //{
    //    #region Enumerado

    //    public enum EnumEspecieDocumento_Sicredi
    //    {

    //    }

    //    #endregion 

    //    #region Construtores

    //    public EspecieDocumento_Sicredi()
    //    {
    //        try
    //        {
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception("Erro ao carregar objeto", ex);
    //        }
    //    }

    //    public EspecieDocumento_Sicredi(int codigo)
    //    {
    //        try
    //        {
    //            this.carregar(codigo);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception("Erro ao carregar objeto", ex);
    //        }
    //    }

    //    #endregion

    //    #region Metodos Privados

    //    private void carregar(int idCodigo)
    //    {
    //        try
    //        {
    //            this.Banco = new Banco_Sicredi();

    //            switch ((EnumEspecieDocumento_Sicredi)idCodigo)
    //            {
    //                //case EnumEspecieDocumento_Sicredi.DuplicataMercantil:
    //                //    this.Codigo = (int)EnumEspecieDocumento_Sudameris.DuplicataMercantil;
    //                //    this.Especie = "Duplicata mercantil";
    //                //    this.Sigla = "DM";
    //                //    break;
    //                default:
    //                    this.Codigo = 0;
    //                    this.Especie = "( Selecione )";
    //                    break;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception("Erro ao carregar objeto", ex);
    //        }
    //    }

    //    public static EspeciesDocumento CarregaTodas()
    //    {
    //        EspeciesDocumento especiesDocumento = new EspeciesDocumento();

    //        foreach (EnumEspecieDocumento_Sicredi item in Enum.GetValues(typeof(EnumEspecieDocumento_Sicredi)))
    //            especiesDocumento.Add(new EspecieDocumento_Sicredi((int)item));

    //        return especiesDocumento;
    //    }

    //    #endregion
    //}
}
