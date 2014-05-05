using System;
using System.Collections.Generic;
using Models;
using MongoDB;

namespace ClsLibDAL
{
    public class ClsAdministradorDAL
    {
        #region Crud
        
        public void inserir(Administrador adm)
        {
            Repository rep = new Repository();
            rep.Insert(MontaDocumento(adm), NomeCompBd.collecAdministrador);
        }

        /// <summary>
        /// Atualiza determinado administrador
        /// </summary>
        /// <param name="adm">Objeto com os valores para atualizar determinado administrador</param>
        /// <by>Marcio Junior</by>
        public void atualizar(Administrador adm)
        {
            Document doc = new Document();
            doc = MontaDocumento(adm);

            Repository rep = new Repository(); 
            rep.Save(doc, NomeCompBd.collecAdministrador);
        }

        public void inativar(Administrador adm)
        {
            //pegar id para inativar
            Document docVelho = new Document();
            docVelho["_id"] = adm._id;

            Document doc = new Document();
            //Zero no caso seria inativo, ou seja, deletado, banido
            doc["situacao"] = 0;


            Repository rep = new Repository();
            //enviar os dados para o repository
            rep.Update(docVelho, doc, NomeCompBd.collecAdministrador);
        }

        public List<Administrador> logar(string login, string senha)
        {
            Document doc = new Document();
            doc["login"] = login;
            doc["senha"] = senha;

            Repository rep = new Repository();
                List<Document> resposta = rep.Procurar(doc, NomeCompBd.collecAdministrador);
                return MontaObjAdm(resposta);
        }

        /// <summary>
        /// Existem coisas que não podem repetir no administrador
        /// como login e email, então, este metodo tem como objetivo pesquisar se aquele
        /// login ou email, ja existe
        /// </summary>
        /// <param name="adm">Recebe o objeto de administrador, pois assim ele serve para o email e o login</param>
        /// <returns>se achar, retorna false(não pode usar), se não achar nada, pode usar retorna true</returns>
        public List<Document> verificaDisponibilidade(string email)
        {
            Document doc = new Document();
            doc["login"] = email;

            Repository rep = new Repository();
            //Quando se ele achar, ou seja se exixtir, ele nao pode utilizar esse login
                return rep.Procurar(doc, NomeCompBd.collecAdministrador);
        }

        public List<Administrador> buscaPorEmail(string email)
        {
            Document doc = new Document();
            doc["email"] = email;

            Repository rep = new Repository();
                return MontaObjAdm(rep.Procurar(doc, NomeCompBd.collecAdministrador));
        }

        public Administrador buscaAdminisUnico(Administrador adm)
        {
            List<Administrador> resp = new List<Administrador>();
            Document doc = new Document();
            doc["_id"] = adm._id;

            Repository rep = new Repository();
                resp = MontaObjAdm(rep.Procurar(doc, NomeCompBd.collecAdministrador));
            

            return resp[0];
        }

        /// <summary>
        /// Esse metodo verifica qual administrador possui menos denuncia para que uma nova denuncia possa ser 
        /// veiculada a ele
        /// </summary>
        /// <returns>Oid do administrador com menos denuncias</returns>
        public Oid verificaMenorQuantDenuncia()
        {
            List<Document> resp = new List<Document>();
             List<Administrador> LstAdm = new List<Administrador>();
            //Como não preciso de nada no documeto ele retornará para mim todos
            Document doc = new Document();

            //id de quem irá ter menos denuncias.
            int menor = 0;
            Oid idMenor = null;

            Repository rep = new Repository();
                resp = rep.Procurar(doc, NomeCompBd.collecAdministrador);
            

            LstAdm = MontaObjAdm(resp);

            LstAdm.ForEach((delegate(Administrador essa)
            {
                //evitando BUGS com um POG kkk
                essa.quantDenum = essa.quantDenum != null ? essa.quantDenum : 0;
                menor = (int)essa.quantDenum <= menor ? (int)essa.quantDenum : menor;
                if ((int)essa.quantDenum < menor || (int)essa.quantDenum == menor)
                {
                    menor = (int)essa.quantDenum;
                    idMenor = essa._id;
                }
            }));

            return idMenor;
        }

        #endregion

        #region MontarObjetos

        /// <summary>
        /// Retorna um documento para CRUD
        /// </summary>
        /// <param name="obj">Manda o Objeto do Administrador</param>
        /// <returns>Retorna o documento para ser alterado</returns>
        protected Document MontaDocumento(Administrador obj)
        {
            Document doc = new Document();
            doc["_id"] = obj._id != null ? obj._id : null;
            doc["nome"] = obj.nome != null ? obj.nome : null;
            doc["pais"] = obj.pais != null ? obj.pais : null;
            doc["uf"] = obj.UF != null ? obj.UF : null;
            doc["cidade"] = obj.cidade != null ? obj.cidade : null;
            doc["situacao"] = obj.situacao != null ? obj.situacao : null;
            doc["login"] = obj.login != null ? obj.login : null;
            doc["senha"] = obj.senha != null ? obj.senha : null;
            doc["dataCadastro"] = obj.dataCadastro != null ? obj.dataCadastro : null;
            doc["quantDenum"] = obj.quantDenum != null ? obj.quantDenum : 0;

            return doc;
        }

        /// <summary>
        /// Retorna os objetos do administrador, que foram achados na query
        /// </summary>
        /// <param name="ListDoc">Resultado da pesquisa</param>
        /// <returns>Objeto para ficar mais facil de manipular os dados</returns>
        protected List<Administrador> MontaObjAdm(List<Document> ListDoc)
        {
            Administrador adm = new Administrador();
            List<Administrador> LtAdm = new List<Administrador>();

            foreach (Document doc in ListDoc)
            {
                Oid _id = new Oid(doc["_id"].ToString());
                adm._id = _id;

                adm.nome = doc["nome"] != null ? doc["nome"].ToString() : null;
                adm.pais = doc["pais"] != null ? doc["pais"].ToString() : null;
                adm.UF = doc["uf"] != null ? doc["uf"].ToString() : null;
                adm.cidade = doc["cidade"] != null ? doc["cidade"].ToString() : null;
                adm.situacao = doc["situacao"] != null ? adm.situacao = int.Parse(doc["situacao"].ToString()) : null;
                adm.login = doc["login"] != null ? doc["login"].ToString() : null;
                adm.senha = doc["senha"] != null ? doc["senha"].ToString() : null;
                adm.dataCadastro = doc["dataCadastro"] != null ? Convert.ToDateTime(doc["dataCadastro"].ToString()) : DateTime.MinValue;
                adm.quantDenum = doc["quantDenum"] != null ? adm.quantDenum : 0;

                LtAdm.Add(adm);
            }

            return LtAdm;
        }

        #endregion
    }
}
