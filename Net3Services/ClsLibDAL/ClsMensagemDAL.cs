using System;
using System.Collections.Generic;
using Models;   
using MongoDB;

namespace ClsLibDAL
{
    class ClsMensagemDAL
    {
        string collec = NomeCompBd.collecMensagens;

        #region Crud

        public void inserir(Conversas men)
        {
            Repository rep = new Repository();
                
        }

        #endregion


        #region montarObjeto

        //Monta o objeto com o id para ser retornado
        protected Oid _id(Document doc)
        { 
            //converte para object id
            Oid id = new Oid(doc["_id"].ToString());
            return id;
        }



        #endregion
    }
}
