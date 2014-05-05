using System;
using System.Collections.Generic;
using ClsLibDAL;
using Models;
using MongoDB;

namespace ClsLibBLL
{
    public class ClsContatoBLL
    {
        /// <summary>
        /// Busca todos os contatos de um determinado usuário.
        /// </summary>
        /// <param name="idUsu">Oid do usuário que deseja buscar os seus contatos.</param>
        /// <returns>Retorna uma lista do tipo Contato se tiver algum registro, se nao tiver, retorna null.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Contato> BuscarTodosContatos(Oid idUsu)
        {
            if (clsUtilidades.ValidarOid(idUsu))
            {
                ClsContatoDAL contatoDAL = new ClsContatoDAL();
                return contatoDAL.BuscarTodosContatos(idUsu);
            }
            else
            {
                throw new Exception("Ocorreu um erro ao buscar contato, por favor, recarregue a página e tente novamente.");
            }
        }

        /// <summary>
        /// Este método exclui todos os contatos do network de um usuário.
        /// </summary>
        /// <param name="idUsu">Oid do usuário que excluirá todos os seus contatos.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void ExcluirTodosContatos(Oid idUsu)
        {
            if (clsUtilidades.ValidarOid(idUsu))
            {
                ClsContatoDAL contatoDAL = new ClsContatoDAL();

                //Exclui todos os contatos do usuário de maneira conectada.
                contatoDAL.ExcluirTodosContatos(idUsu);
            }
            else
            {
                throw new Exception("Ocorreu um erro ao excluir os contatos, por favor, recarregue a página e tente novamente.");
            }
        }

        /// <summary>
        /// Este método exclui um contato do network(do array de network) do usuário.
        /// </summary>
        /// <param name="idContato">Oid do contato a ser excluido do array de network do usuário.</param>
        /// <param name="idUsu">Oid do usuário que irá excluir o contato de seu network.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void ExcluirContatoNetwork(Oid idContato, Oid idUsu)
        {
            if (clsUtilidades.ValidarOid(idContato) && clsUtilidades.ValidarOid(idUsu))
            {
                ClsContatoDAL contatoDAL = new ClsContatoDAL();
                contatoDAL.ExcluirContatoNetwork(idContato, idUsu);
            }
            else
            {
                throw new Exception("Ocorreu um erro ao excluir um contato, por favor, recarregue a página e tente novamente.");
            }
        }

        /// <summary>
        /// Este método adiciona um contato ao network(ao array de network) do usuário.
        /// </summary>
        /// <param name="idContato">Oid do contato a ser adicionado no array de network do usuário.</param>
        /// <param name="idUsu">Oid do usuário que irá adicionar o contato em seu network.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void InserirContatoNetwork(Oid idContato, Oid idUsu, string nomeUsuario)
        {
            if (idContato != idUsu)
            {
                if (clsUtilidades.ValidarOid(idContato) && clsUtilidades.ValidarOid(idUsu))
                {
                    ClsContatoDAL contatoDAL = new ClsContatoDAL();
                    if (!contatoDAL.VerificarExistenciaContato(idUsu, idContato))
                    {
                        contatoDAL.InserirContatoNetwork(idContato, idUsu);
                        //depois de inserir o contato, inserir tambem as atualizacoes referentes
                        InserirAtualizacao(idContato, idUsu, nomeUsuario);
                        //alem de inserir as atualizações, inserir tambem nas notificações
                        InserirNotificacao(idContato, idUsu, nomeUsuario);
                    }
                    else
                    {
                        throw new Exception("Você já é um contato deste usuário.");
                    }
                }
                else
                { throw new OidException("Ocorreu um erro ao inserir um novo contato, por favor, recarregue a página e tente novamente."); }
            }
            else
            {
                throw new Exception("Não é possível adicionar você mesmo como contato.");
            }
        }

        /// <summary>
        /// Inserir uma atualizacao quando adicionar um usuario nos contatos
        /// </summary>
        /// <param name="idContato">Id do contato para quem a notificação ira</param>
        /// <param name="idUsu">quem gerou a notificação</param>
        /// <returns>se ocorreu tudo bem true, se não false</returns>
        public void InserirAtualizacao(Oid idContato, Oid idUsu, string nome)
        {
            ClsAtualizacaoDAL atualizacao = new ClsAtualizacaoDAL();
            Atualizacao atu = new Atualizacao();
            
            atu.CreatedTime = DateTime.Now;
            atu.Mensagem = nome + " adicionou você em seu networking.";
            atu.NomeUsuario = nome;
            atu.OidUsuario = idContato;
            atu.tipoAtualizacao = TipoAtualizacao.contato;

            atualizacao.InserirAtualizacao(atu, idContato, true);
        }

        /// <summary>
        /// Inserindo uma notificação para avisar o usuario quando alguem o adicionar
        /// </summary>
        /// <param name="idContato">id do remetente</param>
        /// <param name="idUsu">quem gerou a notificação</param>
        /// <param name="nome">nome da pessoa que gerou</param>
        public void InserirNotificacao(Oid idContato, Oid idUsu, string nome)
        {
            ClsNotificacaoDAL notificacao = new ClsNotificacaoDAL();
            Notificacao notifi = new Notificacao();

            notifi.assunto = "Networking";
            notifi.dataNotificacao = DateTime.Now;
            notifi.descricao = string.Format("{0} adicionou você em seu networking.", nome);
            notifi.idDestinatario = idContato;
            notifi.idRemetente = idUsu;
            notifi.tipo = (TipoNotificacao)0;
            notifi.status = StatusNotif.Aceito;
            notifi.prioridade = Prioridade.Alta;

            notificacao.InserirSolicitacao(notifi);
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
            if (clsUtilidades.ValidarOid(idUsu))
            {
                if (!string.IsNullOrEmpty(nome.Trim()))
                {
                    ClsContatoDAL contatoDAL = new ClsContatoDAL();
                    return contatoDAL.BuscarContatoPorNome(idUsu, nome.Trim());
                }
                else
                {
                    throw new Exception("Por favor, informe o filtro da busca.");
                }
            }
            else
            { throw new Exception("Oid inválido, por favor, recarregue a página e tente novamente."); }
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
            if (clsUtilidades.ValidarOid(idUsuario))
            {
                if (clsUtilidades.ValidarOid(idContato))
                {
                    ClsContatoDAL contatoDAL = new ClsContatoDAL();
                    return contatoDAL.VerificarExistenciaContato(idUsuario, idContato);
                }
                else
                {
                    throw new Exception("Contato inválido.");
                }
            }
            else
            {
                throw new Exception("Usuário inválido");
            }
        }

        /// <summary>
        /// Este método busca quantos contatos um usuário(determinado pelo seu Oid) tem.
        /// </summary>
        /// <param name="oidUsuario">Oid do usuário que deseja contar o seu número de contatos.</param>
        /// <returns>Retorna quantos contatos o usuário tem.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public long BuscarQuantidadeContatos(Oid oidUsuario)
        {
            //O MongoDB não tem nenhum operador para contar quantos objetos tem um array - 06-11-2011
            if (clsUtilidades.ValidarOid(oidUsuario))
            {
                ClsUsuDAL usuarioDAL = new ClsUsuDAL();
                Document resposta = usuarioDAL.BuscarUsuarioPorIdDocument(oidUsuario);
                
                if (resposta != null)
                {
                    if (resposta[NomeCompBd.usuArrayNetwork] != null)
                    {
                        if (resposta[NomeCompBd.usuArrayNetwork].GetType() == typeof(List<Document>))
                        {
                            List<Document> contatos = (List<Document>)resposta[NomeCompBd.usuArrayNetwork];
                            return contatos.Count;
                        }
                        else
                        { return 0; }
                    }
                    else
                    { return 0; }
                }
                else
                { return 0; }
            }
            else
            {
                throw new Exception("Oid inválido. Por favor recarregue a página e tente novamente.");
            }
        }
    }
}
