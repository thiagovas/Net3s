using System;
using System.Collections.Generic;
using Models;
using MongoDB;

namespace ClsLibDAL
{
    public class ClsDenunciaDAL
    {
        string collec = NomeCompBd.collecDenuncias;
        
        #region Crud

        public void inserir(Denuncia den)
        {
            Repository rep = new Repository();
                rep.Insert(MontarObjDenunciaSemOid(den), collec);
        }

        public void update(Denuncia den)
        {
            Document docDenun = new Document();
            docDenun = MontaObjDenuncia(den);
            Repository rep = new Repository();
                rep.Save(docDenun, NomeCompBd.collecDenuncias);
            
        }

        #endregion

        #region Buscas

        //Busca todas a denuncias que foram feitas por um certo denunciante..
        public List<Denuncia> buscaTodosIdAtend(Denuncia den)
        {
            Document doc = new Document();
            doc["atendente"] = den.atendente;
            doc["status"] = den.status;

            Repository rep = new Repository();
                return RetornaListaDenuncias(rep.Procurar(doc, NomeCompBd.collecDenuncias));            
        }

        public List<Denuncia> buscaDenunciasGeneric(Denuncia den)
        {
            List<Document> retorno = new List<Document>();
            Document doc = new Document();
            doc["_id"] = den._id;

            Repository rep = new Repository();
                retorno = rep.Procurar(doc, NomeCompBd.collecDenuncias);

            return RetornaListaDenuncias(retorno);
        }

        #endregion

        #region montarObjetos

        //Monta o objeto com o id para ser retornado
        protected Oid _id(Document doc)
        {
            //converte para ObjectId
            Oid id = new Oid(doc["_id"].ToString());
            return id;
        }

        protected Denuncia MontaObjDoc(Document doc)
        {
            Denuncia den = new Denuncia();

            Oid idDen = new Oid(doc["_id"].ToString());
            den._id = idDen;
            den.descricao = doc["descricao"].ToString();
            den.status = bool.Parse(doc["status"].ToString());

            //denunciante
            Oid idDn = new Oid(doc["idDn"].ToString());
            den.denunciante = idDn;

            //acusado
            Oid idAcu = new Oid(doc["idAcu"].ToString());
            den.acusado = idAcu;

            //atendente(administrador)
            Oid idAtend = new Oid(doc["idAtend"].ToString());
            den.atendente = idAtend;
            den.resposta = doc["resposta"].ToString();
            den.punicao = doc["punicao"].ToString();

            //data que a denuncia foi feita
            den.dataDenuncia = DateTime.Parse(doc["dataDenum"].ToString());

            //data em que a denuncia foi atendida
            den.dataAtendimento = DateTime.Parse(doc["dataAtend"].ToString());

            return den;
        }

        protected Document MontarObjDenunciaSemOid(Denuncia den)
        {
            Document doc = new Document();
            doc["descricao"] = den.descricao != string.Empty ? den.descricao : null;
            doc["status"] = den.status != null ? den.status : null;
            doc["denunciante"] = den.denunciante != null ? den.denunciante : null;
            doc["acusado"] = den.acusado != null ? den.acusado : null;
            doc["atendente"] = den.atendente != null ? den.atendente : null;
            doc["resposta"] = den.resposta != null ? den.resposta : null;
            doc["punicao"] = den.punicao != null ? den.punicao : null;
            doc["dataDenun"] = den.dataDenuncia != null ? den.dataDenuncia.ToString("dd-MM-yyyy") : null;
            doc["dataAtend"] = den.dataAtendimento != null ? den.dataAtendimento.ToString("dd-MM-yyyy") : null;
            return doc;
        }

        /// <summary>
        /// Monta um documento passando um objeto para aqueles valores.
        /// </summary>
        /// <param name="den">Objeto onde contem as informaçoes da denuncia</param>
        /// <returns>o documento para ser utilizado</returns>
        protected Document MontaObjDenuncia(Denuncia den)
        {
            //monta um documento e retorna, de forma que o cara nao precise ficar repetindo coisas
            Document doc = new Document();
            doc = MontarObjDenunciaSemOid(den);
            doc["_id"] = den._id != null ? den._id : null;
            return doc;
        }

        /// <summary>
        /// Converte de documento para objeto pra ficara mais facil de manipular.
        /// </summary>
        /// <param name="LstDoc">Lista com os documetos</param>
        /// <returns>Lista com os objetos</returns>
        protected List<Denuncia> RetornaListaDenuncias(List<Document> LstDoc)
        {
            List<Denuncia> Lstden = new List<Denuncia>();
            Denuncia den = new Denuncia();

            foreach (Document doc in LstDoc)
            {
                if (doc["_id"] != null)
                {
                    Oid idDen = new Oid(doc["_id"].ToString());
                    den._id = idDen;
                }
               
                den.descricao = doc["descricao"] != null ? doc["descricao"].ToString() : null;
                den.status = bool.Parse(doc["status"].ToString());

                if (doc["denunciante"] != null)
                {
                    //denunciante
                    Oid idDn = new Oid(doc["denunciante"].ToString());
                    den.denunciante = idDn;
                }

                if (doc["acusado"] != null)
                {
                    //acusado
                    Oid idAcu = new Oid(doc["acusado"].ToString());
                    den.acusado = idAcu;
                }

                if (doc["atendente"] != null)
                {
                    //atendente(administrador)
                    Oid idAtend = new Oid(doc["atendente"].ToString());
                    den.atendente = idAtend;
                }

                den.resposta = doc["resposta"] != null ? doc["resposta"].ToString() : null;
                den.punicao = doc["punicao"] != null ? doc["punicao"].ToString() : null;

                //data que a denuncia foi feita
                den.dataDenuncia = doc["dataDenun"] != null ? DateTime.Parse(doc["dataDenun"].ToString()) : DateTime.MinValue;

                //data em que a denuncia foi atendida
                den.dataAtendimento = doc["dataAtend"] != null ? DateTime.Parse(doc["dataAtend"].ToString()) : DateTime.MinValue;

                Lstden.Add(den);
            }

            return Lstden;
        }

        #endregion

    }
}
