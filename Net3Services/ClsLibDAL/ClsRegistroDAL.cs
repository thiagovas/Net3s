using System;
using System.Collections.Generic;
using Models;
using MongoDB;

namespace ClsLibDAL
{
    public class ClsRegistroDAL
    {
        /// <summary>
        /// Insere uma chave no registro do usuário que tem o Oid informado.
        /// </summary>
        /// <param name="oidUsuario">Oid do usuário.</param>
        /// <param name="reg">Objeto do tipo Registro que tem os dados a serem inseridos no banco de dados.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void InserirChave(Oid oidUsuario, Registro reg)
        {
            ClsUsuDAL usuarioDAL = new ClsUsuDAL();

            //Busca o usuário que tem o Oid igual ao primeiro parâmetro deste método para editá-lo.
            Usuario usu = usuarioDAL.BuscarUsuarioPorId(oidUsuario);

            //Adiciona o objeto Registro(que é o segundo parâmetro deste método) à lista registrosUsuario do objeto usu.
            usu.registrosUsuario.Add(reg);

            Repository rep = new Repository();
                rep.Save(usuarioDAL.MontarDocumento(usu), NomeCompBd.collecUsuarios);
            
        }

        /// <summary>
        /// Edita uma chave no registro do usuário que tem o Oid informado.
        /// </summary>
        /// <param name="oidUsuario"></param>
        /// <param name="nomeChave"></param>
        /// <param name="valorChave"></param>
        public void EditarChave(Oid oidUsuario, Registro reg)
        {
            ClsUsuDAL usuarioDAL = new ClsUsuDAL();
            Usuario usu = usuarioDAL.BuscarUsuarioPorId(oidUsuario);

            Predicate<Registro> prdRemoveChave = new Predicate<Registro>(delegate(Registro objReg)
                {
                    return objReg.nomeChave.Equals(reg.nomeChave);
                }
            );
            usu.registrosUsuario.RemoveAll(prdRemoveChave);
            usu.registrosUsuario.Add(reg);
            usuarioDAL.EditarUsu(usu);
        }

        /// <summary>
        /// Exclui uma chave do array registro de um usuário.
        /// </summary>
        /// <param name="oidUsuario">Oid do usuário.</param>
        /// <param name="nomeChave">Nome da chave a ser excluída.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void ExcluirChave(Oid oidUsuario, string nomeChave)
        {
            ClsUsuDAL usuarioDAL = new ClsUsuDAL();
            Usuario usu = usuarioDAL.BuscarUsuarioPorId(oidUsuario);

            Predicate<Registro> prdRemoveChave = new Predicate<Registro>(delegate(Registro objReg)
                {
                    return objReg.nomeChave.Equals(nomeChave);
                }
            );

            usu.registrosUsuario.RemoveAll(prdRemoveChave);
            usuarioDAL.EditarUsu(usu);            
        }

        /// <summary>
        /// Monta uma lista de objetos do tipo Registro a partir de uma lista de objetos do tipo Document.
        /// </summary>
        /// <param name="lstDoc">Lista de objetos do tipo Document.</param>
        /// <returns>Retorna uma lista de objetos do tipo Registro.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Registro> MontarListaObjeto(List<Document> lstDoc)
        {
            List<Registro> lstRetorno = new List<Registro>();
            Action<Document> actMontarObjeto = new Action<Document>(delegate(Document doc)
                {
                    lstRetorno.Add(MontarObjeto(doc));
                }
            );
            lstDoc.ForEach(actMontarObjeto);
            return lstRetorno;
        }

        /// <summary>
        /// Monta um objeto do tipo Registro a partir de um objeto do tipo Document.
        /// </summary>
        /// <param name="doc">Objeto do tipo Document com os dados para montar o objeto do tipo Registro.</param>
        /// <returns>Retorna um objeto do tipo Registro.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Registro MontarObjeto(Document doc)
        {
            Registro reg = new Registro();
            reg.nomeChave = doc[NomeCompBd.usuRegistroNomeChave] != null ? doc[NomeCompBd.usuRegistroNomeChave].ToString() : null;
            reg.valorChave = doc[NomeCompBd.usuRegistroValorChave] != null ? doc[NomeCompBd.usuRegistroValorChave].ToString() : null;
            return reg;
        }

        /// <summary>
        /// Monta um documento a partir de um objeto do tipo Registro.
        /// </summary>
        /// <param name="objReg">Objeto do tipo Registro que tem os dados para montar o documento.</param>
        /// <returns>Retorna um objeto do tipo Document.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Document MontarDocumento(Registro objReg)
        {
            Document doc = new Document();
            doc[NomeCompBd.usuRegistroNomeChave] = objReg.nomeChave;
            doc[NomeCompBd.usuRegistroValorChave] = objReg.valorChave;
            return doc;
        }

        /// <summary>
        /// Monta uma lista de objetos do tipo Document.
        /// </summary>
        /// <param name="lstReg">Lista de objetos do tipo Registro que contém os dados que serão usados para montar a lista do tipo Document.</param>
        /// <returns>Retorna uma lista de objetos do tipo Document.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Document> MontarListaDocumento(List<Registro> lstReg)
        {
            List<Document> lstRetorno = new List<Document>();
            Action<Registro> actMontarDocumento = new Action<Registro>(delegate(Registro reg)
                { 
                    lstRetorno.Add(MontarDocumento(reg));
                }
            );

            //Para cada item na lista lstReg irei montar o seu respectivo documento e inserí-lo na lista lstRetorno.
            lstReg.ForEach(actMontarDocumento);
            return lstRetorno;
        }
    }
}
