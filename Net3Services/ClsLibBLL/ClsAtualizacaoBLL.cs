using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClsLibDAL;
using Models;
using MongoDB;

namespace ClsLibBLL
{
    public class ClsAtualizacaoBLL
    {
        /// <summary>
        /// Este método adiciona à collection de atualizações uma atualização referente ao usuário que tem o Oid igual ao primeiro parâmetro informado.
        /// </summary>
        /// <param name="oidUsuario">Oid do usuário que fez a atualização.</param>
        /// <param name="mensagem">Mensagem que será guardada na collection de atualizações. Essa mensagem é mostrada a todos os contatos do usuário que fez a atualização.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void InserirAtualizacoes(MongoDB.Oid oidUsuario, string mensagem, TipoAtualizacao tipo)
        {
            if (clsUtilidades.ValidarOid(oidUsuario))
            {
                ClsAtualizacaoDAL atualizacaoDAL = new ClsAtualizacaoDAL();
                ClsUsuarioBLL usuarioBLL = new ClsUsuarioBLL();
                Atualizacao atualizac = new Atualizacao();

                Usuario usu = new Usuario();
                usu = usuarioBLL.BuscarUsuarioPorID(oidUsuario);
                if (usu == null)
                    throw new Exception("Não existe um usuário com o id informado.");

                atualizac.CreatedTime = DateTime.Now;
                atualizac.Mensagem = mensagem.Trim();
                atualizac.NomeUsuario = usu.nome;
                atualizac.OidUsuario = oidUsuario;
                //tipo da atualização - MARCIO ALFREDO
                atualizac.tipoAtualizacao = tipo;
                atualizacaoDAL.InserirAtualizacao(atualizac, oidUsuario, true);

                #region === Atualiza a lista de atualizacoes de cada contato do usuário que fez a atualização ===
                ClsContatoBLL contatoBLL = new ClsContatoBLL();
                Action<Contato> InserirAtualizacaoContatos = new Action<Contato>(delegate(Contato cont)
                    {
                        atualizacaoDAL.InserirAtualizacao(atualizac, cont.idContato, false);
                    });
                List<Contato> lstContatos = contatoBLL.BuscarTodosContatos(oidUsuario);
                if (lstContatos != null)
                    lstContatos.AsParallel().ForAll<Contato>(InserirAtualizacaoContatos);
                #endregion
            }
            else
            {
                throw new Exception("Id do usuário inválido.");
            }
        }



        /// <summary>
        /// Busca atualizações do usuário que tem o oid igual ao informado no parâmetro.
        /// </summary>
        /// <param name="oidUsuario">Oid do usuário usado como filtro de busca.</param>
        /// <param name="atualizacaoTipo">True para buscar atualizações do usuário, e false para buscar atualizações de seus contatos.</param>
        /// <returns>Retorna um html que será usado no componente Atualizacoes.ascx</returns>
        public List<Atualizacao> BuscarAtualizacoes(Oid oidUsuario, bool atualizacaoTipo)
        {
            //o metodo da dal ira me retornar o conteudo do arquivo de feeds, irei montar o html aqui e retornar para a user interface
            //a user interface ira fazer a mesma coisa que ela ja esta fazendo, pegar o codigo html e montar a pagina para mostrar para o usuário;

            ClsAtualizacaoDAL atualizacaoDAL = new ClsAtualizacaoDAL();
            StringBuilder strBuilderHtml = new StringBuilder();
            List<HtmlAtualizacao> lstRetorno = new List<HtmlAtualizacao>();
            
            List<Atualizacao> lstResultado = atualizacaoDAL.BuscarAtualizacoes(oidUsuario, atualizacaoTipo);
            return lstResultado;
        }
    }
}
