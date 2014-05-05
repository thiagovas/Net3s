using System;
using System.Collections.Generic;
using System.IO;
using Models;
using MongoDB;

namespace ClsLibDAL
{
    public class ClsUsuDAL
    {
        /// <summary>
        /// Este método tem como função inserir um usuário no banco de dados.
        /// </summary>
        /// <param name="usu">Objeto do tipo Usuario que será usado para inserir no banco de dados.</param>
        public void InserirUsu(Usuario usu)
        {
            Document doc = new Document();
            doc = MontarDocumentoSemId(usu);

            Repository rep = new Repository();
            rep.Insert(doc, NomeCompBd.collecUsuarios);
        }

        /// <summary>
        /// Esse método é responsável por inserir uma imagem padrão para cada usuario cadastrado (user.png)
        /// </summary>
        /// <by>Marcio Mansur - marciorabelom@hotmail.com</by>
        private void InserirImagemPadrao()
        {
            string caminhoImagem = "Imagens/user.png";

            if (!Directory.Exists(caminhoImagem))
            {
                Directory.CreateDirectory(caminhoImagem);
            }

            //TODO: ERRO: Não se pode criar pastas e arquivos através do c#, ele sempre negará o acesso.
            //fonte: http://stackoverflow.com/questions/1450951/access-to-the-path-is-denied-net-c
            byte[] bin = File.ReadAllBytes(caminhoImagem);

            Document doc = new Document();
            doc["filename"] = "Usuario";
            doc["metadata"] = bin;
            doc["ContentType"] = Path.GetExtension(caminhoImagem);

            Repository rep = new Repository();
            rep.inserirArquivo(NomeCompBd.collecUsuarios, doc);

        }

        /// <summary>
        /// Este método tem como função editar um usuário.
        /// </summary>
        /// <param name="usu">Objeto do tipo usuário que já está editado</param>
        /// <param name="_id">Id do usuário que será editado</param>
        public void EditarUsu(Usuario usu)
        {
            Document newDoc = new Document();
            newDoc = MontarDocumento(usu);

            Repository rep = new Repository();
            rep.Save(newDoc, NomeCompBd.collecUsuarios);
        }

        #region === Buscas ===

        /// <summary>
        /// Este método busca um usuário pelo id informado.
        /// </summary>
        /// <param name="_id">Id do usuário que deseja buscar</param>
        /// <returns>Retorna um objeto do tipo usuário.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Usuario BuscarUsuarioPorId(Oid _id)
        {
            Repository rep = new Repository();
            IMongoDatabase bd = rep.DB; //Neste momento é aberto a conexão
            IMongoCollection usuarios = bd.GetCollection(NomeCompBd.collecUsuarios);
            Document resposta = usuarios.FindOne(new Document { { NomeCompBd.usuario_id, _id } }); //Busca um usuario que tem o id informado.
            rep.Desconectar();

            if (resposta != null)
            {
                return MontarObjeto(resposta);
            }
            else
            { return null; }
        }

        /// <summary>
        /// Este método busca um usuário pelo id informado.
        /// </summary>
        /// <param name="_id">Id do usuário que deseja buscar</param>
        /// <returns>Retorna um documento de usuário.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Document BuscarUsuarioPorIdDocument(Oid _id)
        {
            Repository rep = new Repository();
            IMongoDatabase bd = rep.DB; //Neste momento é aberto a conexão
            IMongoCollection usuarios = bd.GetCollection(NomeCompBd.collecUsuarios);
            Document resposta = usuarios.FindOne(new Document { { NomeCompBd.usuario_id, _id } }); //Busca um usuario que tem o id informado.
            rep.Desconectar();
            return resposta;
        }

        /// <summary>
        /// Este método busca usuários que tem o nome informado.
        /// </summary>
        /// <param name="nome">Nome do usuário que deseja buscar</param>
        /// <returns>Retorna uma lista do tipo Usuario</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Usuario> BuscarUsuarioPorNome(string nome)
        {
            List<Document> lstResposta = new List<Document>();
            Repository rep = new Repository();
            lstResposta = rep.ProcurarRegex(NomeCompBd.usuarioNome, nome, NomeCompBd.collecUsuarios);

            return MontarListaObjetos(lstResposta);
        }

        /// <summary>
        /// Busca todos os usuários que tem o login parecido com o informado. Os ativados e os desativados. Lembrando que so existe um login ativo.
        /// </summary>
        /// <param name="login">Login que deseja pesquisar</param>
        /// <returns>Retorna uma lista de usuários</returns>
        public List<Usuario> BuscarUsuarioPorLoginRegex(string login)
        {
            List<Document> lstResposta = new List<Document>();
            Repository rep = new Repository();
            lstResposta = rep.ProcurarRegex(NomeCompBd.usuarioLogin, login, NomeCompBd.collecUsuarios);

            return MontarListaObjetos(lstResposta);
        }

        /// <summary>
        /// Busca um usuário ativo que tem o login informado.
        /// </summary>
        /// <param name="login">Login do usuário usado como filtro de busca.</param>
        /// <returns>Retorna um objeto do tipo Usuario com os dados do retorno da busca feita no banco de dados.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Usuario BuscarUsuarioAtivoPorLogin(string login)
        {
            Document resultado = new Document();
            Document doc = new Document();
            doc[NomeCompBd.usuarioLogin] = login;
            doc[NomeCompBd.usuarioStatus] = (int)Status.Ativado;
            Repository rep = new Repository();
            resultado = rep.ProcurarUm(doc, NomeCompBd.collecUsuarios);

            return resultado != null ? MontarObjeto(resultado) : null;
        }

        /// <summary>
        /// Este método busca um usuário que tem o CPF ou o CNPJ informado.
        /// </summary>
        /// <param name="cpfCnpj">CPF(ou Cnpj) usado como filtro de busca.</param>
        /// <returns>Retorna um objeto do tipo Usuário.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Usuario BuscarUsuarioPorCpfCnpj(string cpfCnpj)
        {
            Usuario Usu = new Usuario();
            Repository rep = new Repository();
            IMongoDatabase bd = rep.DB;
            IMongoCollection usuarios = bd.GetCollection(NomeCompBd.collecUsuarios);
            Document resposta = usuarios.FindOne(new Document { { NomeCompBd.usuarioCpf_cnpj, cpfCnpj } });
            Usu = MontarObjeto(resposta);
            rep.Desconectar();
            return Usu;
        }

        /// <summary>
        /// Busca todos os usuários que tem aquele email. Os ativados e os desativados. Lembrando que so existe um email ativo.
        /// </summary>
        /// <param name="email">Email do usuário que deseja pesquisar</param>
        /// <returns>Retorna uma lista do tipo usuário</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Usuario> BuscarUsuarioPorEmailRegex(string email)
        {
            List<Document> lstResposta = new List<Document>();
            Repository rep = new Repository();
            lstResposta = rep.ProcurarRegex(NomeCompBd.usuarioEmail, email, NomeCompBd.collecUsuarios);

            return MontarListaObjetos(lstResposta);
        }

        /// <summary>
        /// Busca um usuário ativo que tem o email informado.
        /// </summary>
        /// <param name="email">E-mail usado como filtro de busca.</param>
        /// <returns>Retorna um objeto do tipo Usuario.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Usuario BuscarUsuarioAtivoPorEmail(string email)
        {
            Document resultado;
            Document doc = new Document();
            doc[NomeCompBd.usuarioEmail] = email;
            doc[NomeCompBd.usuarioStatus] = (int)Status.Ativado;

            Repository rep = new Repository();
            resultado = rep.ProcurarUm(doc, NomeCompBd.collecUsuarios);


            return resultado != null ? MontarObjeto(resultado) : null;
        }

        /// <summary>
        /// Este método tem a função de buscar o status de um usuário.
        /// </summary>
        /// <param name="_id">id do usuário que deseja buscar o seu status.</param>
        /// <returns>Retorna o status do usuário.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public string BuscarStatus(Oid _id)
        {
            Document doc = new Document();
            doc[NomeCompBd.usuario_id] = _id;

            Repository rep = new Repository();
            IMongoDatabase db = rep.DB;
            IMongoCollection usuarios = db.GetCollection(NomeCompBd.collecUsuarios);
            Document resposta = new Document();
            resposta = usuarios.FindOne(doc);
            rep.Desconectar();

            return resposta[NomeCompBd.usuarioStatus].ToString();
        }

        /// <summary>
        /// Método que busca o e-mail do usuário.
        /// </summary>
        /// <param name="_id">Oid do usuário.</param>
        /// <returns>Retorna o e-mail do usuário.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public string BuscarEmail(Oid _id)
        {
            Document doc = new Document();
            doc[NomeCompBd.usuario_id] = _id;

            Repository rep = new Repository();
            IMongoDatabase db = rep.DB;
            IMongoCollection usuarios = db.GetCollection(NomeCompBd.collecUsuarios);
            Document resposta = new Document();
            resposta = usuarios.FindOne(doc);
            rep.Desconectar();
            return resposta[NomeCompBd.usuarioEmail].ToString();
        }

        /// <summary>
        /// Este método tem a função de buscar o status de um usuário.
        /// </summary>
        /// <param name="_id">Id do usuário que deseja buscar o seu status.</param>
        /// <returns>Retorna o status do usuário.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public string BuscarStatus(string _id)
        {
            Oid id = new Oid(_id);
            string resposta = BuscarStatus(id);
            return resposta.Trim();
        }

        /// <summary>
        /// Este método tem como função buscar todos os usuários do banco de dados e retornar uma lista deles.
        /// </summary>
        /// <returns>Retorna uma lista do tipo Usuario.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Usuario> BuscarTodos()
        {
            List<Usuario> lstUsuarios = new List<Usuario>();
            Repository rep = new Repository();
            IMongoDatabase bd = rep.DB;
            IMongoCollection usuarios = bd.GetCollection(NomeCompBd.collecUsuarios);
            ICursor resposta = usuarios.FindAll();
            lstUsuarios = MontarListaObjetos(resposta.Documents);
            rep.Desconectar();
            return lstUsuarios;
        }

        /// <summary>
        /// Este método verifica se existe no banco de dados o codigo de verificação informado.
        /// </summary>
        /// <param name="codVerificacao">Código de verificação usado para fazer a busca no banco de dados.</param>
        /// <returns>Retorna um valor booleano sendo true se foi encontrado o codigo no banco de dados e false se não encontrou.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public bool BuscarCodigoVerificacao(string codVerificacao)
        {
            Repository rep = new Repository();
            Document docUsu = new Document();
            docUsu[NomeCompBd.usuarioCodConfirma] = codVerificacao;
            List<Document> lstResposta = rep.Procurar(docUsu, NomeCompBd.collecUsuarios);

            //Se lstResposta for nulo retorno nulo, se não for, vejo se existe o campo do codigo de verificacao no documento,
            //se existir retorno ele como string, senão, retorno null.
            return lstResposta.Count > 0 ? lstResposta[0][NomeCompBd.usuarioCodConfirma] != null ? true : false : false;
        }
        #endregion

        #region === Montar objetos e documentos ===

        /// <summary>
        /// Monta um objeto do tipo Usuario a partir de um Document.
        /// </summary>
        /// <param name="doc">Documento usado para montar o objeto.</param>
        /// <returns>Retorna um objeto do tipo Usuario.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Usuario MontarObjeto(Document doc)
        {
            Usuario usu = new Usuario();
            if (doc[NomeCompBd.usuario_id] != null)
            {
                Oid id = new Oid(doc[NomeCompBd.usuario_id].ToString());
                usu._id = id;
            }
            usu.celular1 = doc[NomeCompBd.usuarioCel1] != null ? doc[NomeCompBd.usuarioCel1].ToString() : null;
            usu.celular2 = doc[NomeCompBd.usuarioCel2] != null ? doc[NomeCompBd.usuarioCel2].ToString() : null;
            usu.codigoConfirma = doc[NomeCompBd.usuarioCodConfirma] != null ? doc[NomeCompBd.usuarioCodConfirma].ToString() : null;
            usu.cpf_cnpj = doc[NomeCompBd.usuarioCpf_cnpj] != null ? doc[NomeCompBd.usuarioCpf_cnpj].ToString() : null;
            usu.email = doc[NomeCompBd.usuarioEmail] != null ? doc[NomeCompBd.usuarioEmail].ToString() : null;
            usu.nomeFantasia = doc[NomeCompBd.nomeFantasia] != null ? doc[NomeCompBd.nomeFantasia].ToString() : null;
            
            try
            {
                usu.dataCadastro = DateTime.Parse(doc[NomeCompBd.usuarioDataCadastro].ToString());
            }
            catch (NullReferenceException)
            { usu.dataCadastro = DateTime.MinValue; }

            try
            {
                usu.dataNasc = DateTime.Parse(doc[NomeCompBd.usuarioDataNasc].ToString());
            }
            catch (NullReferenceException)
            { usu.dataNasc = DateTime.MinValue; }

            if (doc[NomeCompBd.usuarioNatureza] != null)
            {
                switch (Convert.ToInt32(doc[NomeCompBd.usuarioNatureza]))
                { 
                    case 0:
                        usu.natureza = Natureza.fisica;
                        break;
                    case 1:
                        usu.natureza = Natureza.juridica;
                        break;
                }
            }
            usu.login = doc[NomeCompBd.usuarioLogin] != null ? doc[NomeCompBd.usuarioLogin].ToString() : null;
            usu.nome = doc[NomeCompBd.usuarioNome] != null ? doc[NomeCompBd.usuarioNome].ToString() : null;
            usu.rg = doc[NomeCompBd.usuarioRg] != null ? doc[NomeCompBd.usuarioRg].ToString() : null;
            usu.senha = doc[NomeCompBd.usuarioSenha] != null ? doc[NomeCompBd.usuarioSenha].ToString() : null;
            usu.site = doc[NomeCompBd.usuarioSite] != null ? doc[NomeCompBd.usuarioSite].ToString() : null;

            try
            {
                string statusUsu = doc[NomeCompBd.usuarioStatus].ToString();
                statusUsu = statusUsu.Trim();
                if (string.IsNullOrEmpty(statusUsu))
                {
                    usu.status = null;
                }
                else
                {
                    usu.status = short.Parse(statusUsu);
                }
            }
            catch (NullReferenceException)
            {
                usu.status = null;
            }
            usu.telefone1 = doc[NomeCompBd.usuarioTel1] != null ? doc[NomeCompBd.usuarioTel1].ToString() : null;
            usu.telefone2 = doc[NomeCompBd.usuarioTel2] != null ? doc[NomeCompBd.usuarioTel2].ToString() : null;
            
            usu.usuarioNotaMediaContratacoes = doc[NomeCompBd.usuarioNotaMediaContratacoes] != null ? Convert.ToDouble(doc[NomeCompBd.usuarioNotaMediaContratacoes]) : 0;
            usu.usuarioNotaMediaPrestacoes = doc[NomeCompBd.usuarioNotaMediaPrestacoes] != null ? Convert.ToDouble(doc[NomeCompBd.usuarioNotaMediaPrestacoes]) : 0;

            #region === Arrays ===
            #region === Notificacao ===
            if (doc[NomeCompBd.usuArrayNotificacao] != null)
            {
                if (doc[NomeCompBd.usuArrayNotificacao].GetType() == typeof(List<Document>))
                {
                    ClsNotificacaoDAL notifDAL = new ClsNotificacaoDAL();
                    usu.notificacoesUsuario = notifDAL.MontarListaObjeto((List<Document>)doc[NomeCompBd.usuArrayNotificacao]);
                }
            }
            #endregion
            #region === Network ===
            if (doc[NomeCompBd.usuArrayNetwork] != null)
            {
                if (doc[NomeCompBd.usuArrayNetwork].GetType() == typeof(List<Document>))
                {
                    ClsContatoDAL contatoDAL = new ClsContatoDAL();
                    usu.network = contatoDAL.MontarListaObjeto((List<Document>)doc[NomeCompBd.usuArrayNetwork]);
                }
            }
            #endregion
            #region === Registro ===
            if (doc[NomeCompBd.usuArrayRegistro] != null)
            {
                if (doc[NomeCompBd.usuArrayRegistro].GetType() == typeof(List<Document>))
                {
                    ClsRegistroDAL registroDAL = new ClsRegistroDAL();
                    usu.registrosUsuario = registroDAL.MontarListaObjeto((List<Document>)doc[NomeCompBd.usuArrayRegistro]);
                }
            }
            #endregion
            #region === Curriculum ===
            if (doc[NomeCompBd.usuCurriculum] != null)
            {
                if (!doc[NomeCompBd.usuCurriculum].GetType().Equals(DBNull.Value.GetType()))
                {
                    ClsCurriculumDAL curriculumDAL = new ClsCurriculumDAL();
                    usu.curriculumUsuario = curriculumDAL.MontarObjeto((Document)doc[NomeCompBd.usuCurriculum]);
                }
            }
            #endregion
            #region === Enderecos ===
            if (doc[NomeCompBd.usuArrayEnderecos] != null)
            {
                if (doc[NomeCompBd.usuArrayEnderecos].GetType() == typeof(List<Document>))
                {
                    ClsEnderecoDAL enderecoDAL = new ClsEnderecoDAL();
                    usu.enderecosUsuario = enderecoDAL.montarListaObjetos((List<Document>)doc[NomeCompBd.usuArrayEnderecos]);
                }
            }
            #endregion
            #region === Registro ===
            if (doc[NomeCompBd.usuArrayRegistro] != null)
            {
                if (doc[NomeCompBd.usuArrayRegistro].GetType() == typeof(List<Document>))
                {
                    ClsRegistroDAL registroDAL = new ClsRegistroDAL();
                    usu.registrosUsuario = registroDAL.MontarListaObjeto((List<Document>)doc[NomeCompBd.usuArrayRegistro]);
                }
            }
            #endregion
            #region === Historico de serviços ===
            if (doc[NomeCompBd.usuArrayHistoricoServicos] != null)
            {
                if (doc[NomeCompBd.usuArrayHistoricoServicos].GetType() == typeof(List<Document>))
                {
                    ClsHistoricoServicoDAL historicoServicoDAL = new ClsHistoricoServicoDAL();
                    usu.historicoServicoUsuario = historicoServicoDAL.MontarListaObjeto((List<Document>)doc[NomeCompBd.usuArrayHistoricoServicos]);
                }
            }
            #endregion
            #region === Orcamento ===
            if (doc[NomeCompBd.usuArrayOrcamento] != null)
            {
                if (doc[NomeCompBd.usuArrayOrcamento].GetType() == typeof(List<Document>))
                {
                    ClsOrcamentoDAL orcamentoDAL = new ClsOrcamentoDAL();
                    usu.orcamentoUsuario = orcamentoDAL.MontarListaObjetos((List<Document>)doc[NomeCompBd.usuArrayOrcamento]);
                }
            }
            #endregion
            #region === Contas Bancárias ===

            if (doc[NomeCompBd.usuArrayContasBancarias] != null)
            { 
                if(doc[NomeCompBd.usuArrayContasBancarias].GetType() == typeof(List<Document>))
                {
                    ClsContaBancariaDAL contaBancariaDAL = new ClsContaBancariaDAL();
                    usu.contaBanc = contaBancariaDAL.MontarListaObjetos((List<Document>)doc[NomeCompBd.usuArrayContasBancarias]);
                }
            }
            #endregion
            #endregion

            return usu;
        }

        /// <summary>
        /// Monta uma lista do tipo Usuario a partir de um IEnumerable.
        /// </summary>
        /// <param name="cur">Objeto IEnumerable usado para montar a lista do tipo Usuario.</param>
        /// <returns>Retorna uma lista do tipo usuário</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Usuario> MontarListaObjetos(IEnumerable<Document> cur)
        {
            List<Usuario> lstUsuario = new List<Usuario>();
            foreach (var item in cur)
            {
                lstUsuario.Add(MontarObjeto(item));
            }
            return lstUsuario;
        }

        /// <summary>
        /// Monta uma lista do tipo Usuario a partir de uma lista.
        /// </summary>
        /// <param name="lstDoc">Lista do tipo Documento usada para montar uma lista do tipo Usuario.</param>
        /// <returns>Retorna uma lista do tipo Usuario.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Usuario> MontarListaObjetos(List<Document> lstDoc)
        {
            List<Usuario> lstUsuario = new List<Usuario>();
            foreach (var item in lstDoc)
            {
                lstUsuario.Add(MontarObjeto(item));
            }
            return lstUsuario;
        }

        /// <summary>
        /// Este método monta uma variável do tipo Documento e o retorna.
        /// </summary>
        /// <param name="usu">Objeto do tipo usuario que será usado para montar o documento.</param>
        /// <returns>Retorna o documento montado a partir do objeto informado.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Document MontarDocumento(Usuario usu)
        {
            Document doc = new Document();
            doc = MontarDocumentoSemId(usu);
            doc[NomeCompBd.usuario_id] = usu._id;
            return doc;
        }

        /// <summary>
        /// Este método monta um documento a partir de um objeto do tipo Usuario, mas sem o Oid dele.
        /// </summary>
        /// <param name="usu">Objeto do tipo usuario que será usado para montar o documento.</param>
        /// <returns>Retorna o documento montado, sem o Oid, a partir do objeto informado.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Document MontarDocumentoSemId(Usuario usu)
        {
            Document doc = new Document();
            doc[NomeCompBd.usuarioCel1] = usu.celular1;
            doc[NomeCompBd.usuarioCel2] = usu.celular2;
            doc[NomeCompBd.usuarioCodConfirma] = usu.codigoConfirma;
            doc[NomeCompBd.usuarioCpf_cnpj] = usu.cpf_cnpj;
            doc[NomeCompBd.usuarioDataCadastro] = usu.dataCadastro;
            doc[NomeCompBd.usuarioDataNasc] = usu.dataNasc;
            doc[NomeCompBd.usuarioEmail] = usu.email;
            doc[NomeCompBd.usuarioLogin] = usu.login;
            doc[NomeCompBd.usuarioNatureza] = Convert.ToInt32(usu.natureza);
            doc[NomeCompBd.usuarioNome] = usu.nome;
            doc[NomeCompBd.nomeFantasia] = usu.nomeFantasia;
            doc[NomeCompBd.usuarioRg] = usu.rg;
            doc[NomeCompBd.usuarioSenha] = usu.senha;
            doc[NomeCompBd.usuarioSite] = usu.site;
            doc[NomeCompBd.usuarioStatus] = usu.status;
            doc[NomeCompBd.usuarioTel1] = usu.telefone1;
            doc[NomeCompBd.usuarioTel2] = usu.telefone2;
            doc[NomeCompBd.usuarioNotaMediaContratacoes] = usu.usuarioNotaMediaContratacoes;
            doc[NomeCompBd.usuarioNotaMediaPrestacoes] = usu.usuarioNotaMediaPrestacoes;

            #region === Curriculum ===
            ClsCurriculumDAL curriculumDAL = new ClsCurriculumDAL();
            doc[NomeCompBd.usuCurriculum] = curriculumDAL.MontarDocumento(usu.curriculumUsuario);
            #endregion
            #region === Array de enderecos ===
            ClsEnderecoDAL enderecoDAL = new ClsEnderecoDAL();
            doc[NomeCompBd.usuArrayEnderecos] = enderecoDAL.montarListaDocumentos(usu.enderecosUsuario);
            #endregion
            #region === Array de historico de servicos ===
            List<Document> lstHistServ = new List<Document>();
            ClsHistoricoServicoDAL historicoServicoDAL = new ClsHistoricoServicoDAL();
            lstHistServ = historicoServicoDAL.MontarListaDocumento(usu.historicoServicoUsuario);
            doc[NomeCompBd.usuArrayHistoricoServicos] = lstHistServ != null ? lstHistServ : new List<Document>();
            #endregion
            #region === Array de ocorrencias ===
            List<Document> lstOcorrencias = new List<Document>();
            foreach (var item in usu.ocorrenciasUsuario)
            {
                Document docOcorrencia = new Document();
                docOcorrencia[NomeCompBd.usuOcorrencia_id] = item.idOcorrencia;
                docOcorrencia[NomeCompBd.usuOcorrenciaAtendente] = item.atendente;
                docOcorrencia[NomeCompBd.usuOcorrenciaDataDenuncia] = item.dataDenuncia;
                docOcorrencia[NomeCompBd.usuOcorrenciaDataResposta] = item.dataResposta;
                docOcorrencia[NomeCompBd.usuOcorrenciaDenunciante] = item.denunciante;
                docOcorrencia[NomeCompBd.usuOcorrenciaDescricao] = item.descricao;
                docOcorrencia[NomeCompBd.usuOcorrenciaResposta] = item.resposta;
                docOcorrencia[NomeCompBd.usuOcorrenciaStatus] = item.status;
                docOcorrencia[NomeCompBd.usuOcorrenciaTempoBanido] = item.tempoBanido;
                lstOcorrencias.Add(docOcorrencia);
            }
            doc[NomeCompBd.usuArrayOcorrencias] = lstOcorrencias;
            #endregion
            #region === Array de registros ===
            List<Document> lstRegistros = new List<Document>();
            foreach (var item in usu.registrosUsuario)
            {
                Document docRegistro = new Document();
                docRegistro[NomeCompBd.usuRegistroNomeChave] = item.nomeChave;
                docRegistro[NomeCompBd.usuRegistroValorChave] = item.valorChave;
                lstRegistros.Add(docRegistro);
            }
            doc[NomeCompBd.usuArrayRegistro] = lstRegistros;
            #endregion
            #region === Array de notificações ===
            ClsNotificacaoDAL notifDAL = new ClsNotificacaoDAL();
            doc[NomeCompBd.usuArrayNotificacao] = notifDAL.MontarListaDocumento(usu.notificacoesUsuario);
            #endregion
            #region === Array de network ===
            ClsContatoDAL contatoDAL = new ClsContatoDAL();
            doc[NomeCompBd.usuArrayNetwork] = contatoDAL.MontarListaDocumento(usu.network);
            #endregion
            #region === Array de orcamento ===
            ClsOrcamentoDAL orcamentoDAL = new ClsOrcamentoDAL();
            List<Document> lstOrcamento = new List<Document>();
            lstOrcamento = orcamentoDAL.MontarListaDocumento(usu.orcamentoUsuario);
            doc[NomeCompBd.usuArrayOrcamento] = lstOrcamento != null ? lstOrcamento : new List<Document>();
            #endregion
            #region === Array de contas bancárias ===
            ClsContaBancariaDAL contaBancariaDAL = new ClsContaBancariaDAL();
            List<Document> lstContasBancarias = new List<Document>();
            lstContasBancarias = contaBancariaDAL.MontarListaDocumentos(usu.contaBanc);
            doc[NomeCompBd.usuArrayContasBancarias] = lstContasBancarias != null ? lstContasBancarias : new List<Document>();
            #endregion
            return doc;
        }

        public byte[] ToByteArray(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public Document MontarDocumentoImg(Stream input, string name)
        {
            byte[] bite = ToByteArray(input);
            Binary bin = new Binary(bite);

            Document doc = new Document();

            doc["filename"] = name;
            doc["metadata"] = bin;
            doc["ContentType"] = Path.GetExtension(input.ToString());

            return doc;
        }

        #endregion

        /// <summary>
        /// Executa a confirmação do cadastro do usuário informado
        /// </summary>
        /// <param name="codVerificacao">Código de verificação do cadastro do usuário de que se deve confirmar o cadastro</param>
        /// <returns>Objeto do usuário que possui o código de verificação informado</returns>
        /// <by>Breno Silva e Pires - breno_spires@hotmail.com</by>
        public Usuario ConfirmarCadastro(string codConfirmacao)
        {
            Repository rep = new Repository();
            IMongoDatabase bd = rep.DB;
            IMongoCollection usuarios = bd.GetCollection(NomeCompBd.collecUsuarios);
            Document respostaBusca = usuarios.FindOne(new Document { { NomeCompBd.usuarioCodConfirma, codConfirmacao }, { NomeCompBd.servicoStatusServico, 3 } });

            bd = null;
            rep.Desconectar();

            if (respostaBusca != null)
            {
                var usu = MontarObjeto(respostaBusca);
                usu.status = 0; // Altera o status do usuário para ativo
                EditarUsu(usu);
                return usu;
            }
            else
            {
                throw new Exception("O código de verificação informado não existe");
            }
        }

        public bool VerificarImagem(string name)
        {
            Document docImg = new Document();
            docImg["filename"] = name;
            Repository rep = new Repository();
            if (rep.procurarArquivo(NomeCompBd.collecUsuarios, docImg).Count > 0)
                return true;
            return false;

        }

        /// <summary>
        /// Método que adiciona imagem padrão de usuario sem foto
        /// </summary>
        /// <param name="path">endereço da imagem</param>
        /// <param name="name">Nome da imagem</param>
        public void InserirImgPadrao(Stream b, string name)
        {
            name = "1";
            Document Documentado = new Document();
            Documentado = MontarDocumentoImg(b, name);

            Repository rep = new Repository();
            rep.inserirArquivo(NomeCompBd.collecUsuarios, Documentado);

        }

        /// <summary>
        /// Adicio
        /// </summary>
        /// <param name="myStream">Stream contendo a imagem, de até 4mb, que deve ser adicionada no banco</param>
        /// <param name="id">Oid do usuário que a imagem pertence</param>
        public void InserirImgUsuario(Stream myStream, string id)
        {
            Document Documentado = new Document();
            Documentado = MontarDocumentoImg(myStream, id);

            Repository rep = new Repository();
            rep.inserirArquivo(NomeCompBd.collecUsuarios, Documentado);

        }

        /// <summary>
        /// Atualiza a imagem do usuário que já possuim uma imagem adicionada ao banco de dados.
        /// </summary>
        /// <param name="myStream">Stream contendo a imagem, de até 4mb, que deve ser adicionada no banco</param>
        /// <param name="id">Oid do usuário que a imagem pertence</param>
        public void AlterarImgUsuario(Stream myStream, string id)
        {
            Document Documentado = new Document();
            Documentado = MontarDocumentoImg(myStream, id);

            Repository rep = new Repository();
            Document docImgAntiga = new Document();
            docImgAntiga["filename"] = id;
            var oldDoc = rep.procurarArquivo(NomeCompBd.collecUsuarios, docImgAntiga);
            foreach (var doc in oldDoc)
            {
                rep.atualizaArquivo(Documentado, doc, NomeCompBd.collecUsuarios);
            }

        }

        public void DeletarImgUsuario(string id)
        {
            Repository rep = new Repository();
            Document docImgAntiga = new Document();
            docImgAntiga["filename"] = id;
            var oldDoc = rep.procurarArquivo(NomeCompBd.collecUsuarios, docImgAntiga);
            foreach (var doc in oldDoc)
            {
                rep.deletaArquivo(NomeCompBd.collecUsuarios, doc);
            }
        }

        /// <summary>
        /// Conta quantos usuário tem um campo(primeiro parâmetro) igual a um valor(segundo parâmetro).
        /// </summary>
        /// <example>Um usuário que tem o campo email igual a t.vas@hotmail.com, onde email é o primeiro parâmetro a ser passado para este método,
        /// e t.vas@hotmail.com é o segundo parâmetro.</example>
        /// <param name="nomeCampo">Nome do campo do banco de dados.</param>
        /// <param name="valorCampo">Valor do campo.</param>
        /// <param name="usuarioAtivo">Status do usuário que deseja procurar, informe null se quiser procurar por todos usuários.</param>
        /// <returns>Retorna quantos usuários tem [nomeCampo] = [valorCampo]</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public long Count(string nomeCampo, string valorCampo, Status? usuarioAtivo)
        {
            Document doc = new Document();
            if (usuarioAtivo != null)
                doc[NomeCompBd.usuarioStatus] = (int)usuarioAtivo;
            doc[nomeCampo] = valorCampo;
            long retorno;
            Repository rep = new Repository();
            retorno = rep.Count(doc, NomeCompBd.collecUsuarios);

            return retorno;
        }

        /// <summary>
        /// Este método verifica se o login e a senha existem em nosso banco de dados. Usado para fazer login.
        /// </summary>
        /// <param name="login">Login do usuário.</param>
        /// <param name="senha">Senha do usuário.</param>
        /// <returns>Retorna true se existir um login com a respectiva senha informada, retorna false se o login e a senha não existirem no banco de dados.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public bool VerificarLogin(ref Usuario usu)
        {
            Repository rep = new Repository();

            IMongoDatabase bd = rep.DB;
            IMongoCollection usuarios = bd.GetCollection(NomeCompBd.collecUsuarios);

            Document respostaLogin = usuarios.FindOne(new Document { { NomeCompBd.usuarioLogin, usu.login }, { NomeCompBd.usuarioSenha, usu.senha } });
            Document respostaEmail = usuarios.FindOne(new Document { { NomeCompBd.usuarioEmail, usu.email }, { NomeCompBd.usuarioSenha, usu.senha } });
            bd = null;
            rep.Desconectar();

            if (respostaLogin != null)
            {
                usu = MontarObjeto(respostaLogin);
                return true;
            }
            else if (respostaEmail != null)
            {
                usu = MontarObjeto(respostaEmail);
                return true;
            }
            else
                throw new Exception("Usuário não encontrado. Verifique o login e a senha e tente novamente.");
        }
    }
}