using System;
using System.Collections.Generic;
using Models;
using MongoDB;

namespace ClsLibDAL
{
    public class ClsContatoDAL
    {
        /// <summary>
        /// Este método adiciona um contato ao network(ao array de network) do usuário.
        /// </summary>
        /// <param name="idContato">Oid do contato a ser adicionado no array de network do usuário.</param>
        /// <param name="idUsu">Oid do usuário que irá adicionar o contato em seu network.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void InserirContatoNetwork(Oid idContato, Oid idUsu)
        {
            ClsUsuDAL usuDAL = new ClsUsuDAL();
            Usuario usu = usuDAL.BuscarUsuarioPorId(idUsu);
            Usuario contato = usuDAL.BuscarUsuarioPorId(idContato);

            usu.network.Add(new Contato()
            {
                idContato = idContato,
                DataInsercao = DateTime.Now.Date,
                NomeContato = contato.nome,
                EmailContato = contato.email
            });

            contato.network.Add(new Contato()
            {
                idContato = idUsu,
                DataInsercao = DateTime.Now.Date,
                NomeContato = usu.nome,
                EmailContato = usu.email
            });

            Repository rep = new Repository();
            rep.Save(usuDAL.MontarDocumento(usu), NomeCompBd.collecUsuarios);
            rep.Save(usuDAL.MontarDocumento(contato), NomeCompBd.collecUsuarios);

        }

        /// <summary>
        /// Este método exclui um contato do network(do array de network) do usuário.
        /// </summary>
        /// <param name="idContato">Oid do contato a ser excluido do array de network do usuário.</param>
        /// <param name="idUsu">Oid do usuário que irá excluir o contato de seu network.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void ExcluirContatoNetwork(Oid idContato, Oid idUsu)
        {
            ClsUsuDAL usuDAL = new ClsUsuDAL();
            Usuario usu = usuDAL.BuscarUsuarioPorId(idUsu);
            Usuario contato = usuDAL.BuscarUsuarioPorId(idContato);

            Predicate<Contato> predContato = new Predicate<Contato>(delegate(Contato c)
            {
                return idContato == c.idContato; //Se retornar true, o objeto mandado como parâmetro, que veio da lista network, será removido da lista.
            });
            
            Predicate<Contato> predUsu = new Predicate<Contato>(delegate(Contato c)
            {
                return idUsu == c.idContato; //Se retornar true, o objeto mandado como parâmetro, que veio da lista network, será removido da lista.
            });

            //Busca o index do registro na lista network, que fica no objeto usu, que tem o Oid do contato igual ao parâmetro idContato
            //Quem faz a verificação se um Oid é igual ao outro é o Predicate predContato criado acima.
            //E com o index, removo o registro da lista network que fica no objeto usu.
            usu.network.RemoveAt(usu.network.FindIndex(predContato));

            //A explicação do funcionamento desta linha é o mesmo da linha de cima, so que com os objetos trocados.
            contato.network.RemoveAt(contato.network.FindIndex(predUsu));

            Repository rep = new Repository();
            
            //Salva a alteração.
            rep.Save(usuDAL.MontarDocumento(usu), NomeCompBd.collecUsuarios);
            rep.Save(usuDAL.MontarDocumento(contato), NomeCompBd.collecUsuarios);
        }

        /// <summary>
        /// Este método exclui todos os contatos do network de um usuário.
        /// </summary>
        /// <param name="idUsu">Oid do usuário que excluirá todos os seus contatos.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void ExcluirTodosContatos(Oid idUsu)
        {
            //Exlcui todos os contatos de maneira conectada.
            ClsUsuDAL usuDAL = new ClsUsuDAL();
            Usuario usu = usuDAL.BuscarUsuarioPorId(idUsu);
            Predicate<Document> prdBuscarContato = new Predicate<Document>(delegate(Document x)
                {
                    return usu._id == (MongoDB.Oid)x[NomeCompBd.usuNetworkOidContato];
                });

            Repository rep = new Repository();

            //Nesta linha a conexão com o banco de dados é aberta.
            IMongoCollection coll = rep.DB.GetCollection(NomeCompBd.collecUsuarios);
            #region === Tira a referencia do contato em cada documento de seus contatos ===
            foreach (Contato item in usu.network)
            {
                Document docBusca = new Document();
                docBusca[NomeCompBd.usuario_id] = item.idContato;
                docBusca[NomeCompBd.usuarioStatus] = 0;
                Document docResposta = new Document();
                docResposta = coll.FindOne(docBusca);//Busco o documento de usuário do contato.

                //Guardo a lista de contatos de cada contato em lstContato, para mais abaixo retirar a
                //referencia do usuário q tem o Oid igual ao parâmetro recebido.
                List<Document> lstContatos = (List<Document>)docResposta[NomeCompBd.usuArrayNetwork];
                lstContatos.Remove(lstContatos.Find(prdBuscarContato)); //Removo o usuário da lista de contatos.
                docResposta[NomeCompBd.usuArrayNetwork] = lstContatos; 
                coll.Save(docResposta); //Salvo as alterações.
            }
            #endregion
            usu.network.Clear();
            coll.Save(usuDAL.MontarDocumento(usu));
            rep.Desconectar();
        }

        /// <summary>
        /// Busca todos os contatos de um determinado usuário.
        /// </summary>
        /// <param name="idUsu">Oid do usuário que deseja buscar os seus contatos.</param>
        /// <returns>Retorna uma lista do tipo Contato se tiver algum registro, se nao tiver, retorna null.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Contato> BuscarTodosContatos(Oid idUsu)
        {
            ClsUsuDAL usuDAL = new ClsUsuDAL();
            Usuario usu = usuDAL.BuscarUsuarioPorId(idUsu);
            return usu.network.Count > 0 ? usu.network : null;
        }

        /// <summary>
        /// Busca contato de um usuário que tenha o nome informado.
        /// </summary>
        /// <param name="idUsu">Oid do usuário.</param>
        /// <param name="nome">Nome do contato usado como filtro da busca.</param>
        /// <returns>Retorna uma lista do tipo Contato.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Contato> BuscarContatoPorNome(Oid idUsu, string nome)
        {
            /*
             * {
             *  _id : ObjectId("idUsu")
             *  Network: [{NomeContato: nome}]
             * }
             */

            Document docUsu = new Document();
            List<Document> lstContato = new List<Document>();
            Document docContato = new Document();

            docUsu.Add(NomeCompBd.usuario_id, idUsu);
            docContato.Add(NomeCompBd.usuNetworkNomeContato, nome);
            lstContato.Add(docContato);
            docUsu.Add(NomeCompBd.usuArrayNetwork, lstContato);
            List<Document> lstResposta;

            Repository rep = new Repository();
                lstResposta = rep.Procurar(docUsu, NomeCompBd.collecUsuarios);
            

            return MontarListaObjeto(lstResposta);
        }

        /// <summary>
        /// Busca contatos que tem nomes parecidos com o informado, uso o operador Regex para fazer a busca.
        /// </summary>
        /// <param name="idUsu">Oid do usuário.</param>
        /// <param name="nome">Nome do contato, usado como filtro da busca.</param>
        /// <returns>Retorna um lista do tipo Contato.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Contato> BuscarContatoPorNomeRegex(Oid idUsu, string nome)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Este método verifica no banco de dados se o usuário aqui determinado como contato pertence ao network do outro usuario.
        /// </summary>
        /// <param name="idUsuario">Oid do usuário onde ira verificar se tem o contato informado no segundo parametro.</param>
        /// <param name="idContato">Oid do contato que será verificado se esta presente no array de contatos do usuário informado no primeiro parametro.</param>
        /// <returns>Retorna um valor booleano onde será true se o usuário aqui determinado como contato pertencer ao array de contatos do usuário que tem o seu Oid informado no primeiro parâmetro.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public bool VerificarExistenciaContato(Oid idUsuario, Oid idContato)
        {
            Document docUsuario = new Document();
            Document doc = new Document();
            Document docContato = new Document();
            docContato[NomeCompBd.usuNetworkOidContato] = idContato;
            docUsuario["$elemMatch"] = docContato;
            doc[NomeCompBd.usuArrayNetwork] = docUsuario;
            doc[NomeCompBd.usuario_id] = idUsuario;
            int quantDoc;
            Repository rep = new Repository();
                quantDoc = rep.Procurar(doc, NomeCompBd.collecUsuarios).Count;
            
            return quantDoc > 0;
        }

        #region === Montar objeto e documento ===
        /// <summary>
        /// Este método monta um objeto do tipo Contato a partir de um documento informado.
        /// </summary>
        /// <param name="doc">Documento a ser usado para montar o objeto do tipo Contato.</param>
        /// <returns>Retorna um objeto do tipo Contato montado a partir de um documento informado.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Contato MontarObjeto(Document doc)
        {
            Contato cont = new Contato();
            cont.idContato = doc[NomeCompBd.usuNetworkOidContato] != null ? new Oid(doc[NomeCompBd.usuNetworkOidContato].ToString()) : null;
            cont.DataInsercao = doc[NomeCompBd.usuNetworkDatainsercao] != null ? Convert.ToDateTime(doc[NomeCompBd.usuNetworkDatainsercao]) : DateTime.MinValue;
            cont.NomeContato = doc[NomeCompBd.usuNetworkNomeContato] != null ? doc[NomeCompBd.usuNetworkNomeContato].ToString() : null;
            return cont;
        }

        /// <summary>
        /// Método que monta um documento de contato a partir de um objeto do tipo Contato.
        /// </summary>
        /// <param name="cont">Objeto do tipo Contato usado para montar o documento.</param>
        /// <returns>Retorna um documento de Contato.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Document MontarDocumento(Contato cont)
        {
            Document doc = new Document();
            doc[NomeCompBd.usuNetworkOidContato] = cont.idContato;
            doc[NomeCompBd.usuNetworkNomeContato] = cont.NomeContato;
            doc[NomeCompBd.usuNetworkDatainsercao] = cont.DataInsercao;
            return doc;
        }

        /// <summary>
        /// Método que monta uma lista do tipo Document com os documentos de contato.
        /// </summary>
        /// <param name="lstContato">Lista do tipo contato usada para montar a lista de documentos.</param>
        /// <returns>Retorna uma lista do tipo Document com o resultado da conversão.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Document> MontarListaDocumento(List<Contato> lstContato)
        {
            List<Document> lstResposta = new List<Document>();
            foreach (Contato item in lstContato)
            {
                lstResposta.Add(MontarDocumento(item));
            }
            return lstResposta;
        }

        /// <summary>
        /// Este método monta uma lista do tipo Contato a partir de uma lista de documentos.
        /// </summary>
        /// <param name="lstDoc">Lista de documentos a ser usada para montar a lista do tipo Contato.</param>
        /// <returns>Retorna uma lista do tipo Contato montada a partir da lista de documentos informada.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Contato> MontarListaObjeto(List<Document> lstDoc)
        {
            List<Contato> lstCont = new List<Contato>();
            foreach (var item in lstDoc)
            {
                lstCont.Add(MontarObjeto(item));
            }
            return lstCont;
        }
        #endregion
    }
}