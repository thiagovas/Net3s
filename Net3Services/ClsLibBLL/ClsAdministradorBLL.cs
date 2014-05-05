using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using ClsLibDAL;
using Models;
using MongoDB;

namespace ClsLibBLL
{
    public delegate void Crud(Administrador adm);

    public class ClsAdministradorBLL
    {
	// Editando esta merda para ver se funciona
	// Mais uma edição sem sentido algum
        //TESTE

        ClsAdministradorDAL dalAdmin = new ClsAdministradorDAL();
        Administrador objAdmin;

        #region === CRUD(VEIA) ===

        /// <summary>
        /// Método para inserir algum adiministrador
        /// </summary>
        /// <param name="adm"></param>
        public string[] InserirAdministrador(Administrador adm)
        {
            string[] retorno = new string[4];
            bool ok = true;

            if (!Regex.IsMatch(adm.nome, @"[a-zA-Z]{3,200}$"))
            {
                retorno[0] = "o nome esta incorreto, por favor corrija!";
                ok = false;
            }

            if (!Regex.IsMatch(adm.login,  @"^([0-9a-zA-Z]+([_.-]?[0-9a-zA-Z]+)*@[0-9a-zA-Z]+[0-9,a-z,A-Z,.,-]*(.){1}[a-zA-Z]{2,4})+$"))
            {
                retorno[1] = "Este não é um email valido, por favor corrija!";
                ok = false;
            }

            if (!Regex.IsMatch(adm.senha, @"[a-zA-Z0-9]{8,100}$"))
            {
                retorno[2] = "Por favor Digite uma senha valida!";
                ok = false;
            }

            if (adm.senha != adm.cSenha)
            {
                retorno[3] = "As duas senhas tem que ser iguais!";
                ok = false;
            }

            if (ok)
            {
                //seter o retorno para servir de comparação
                retorno = null;

                dalAdmin = new ClsAdministradorDAL();
                dalAdmin.inserir(adm);
            }

            return retorno;
        }

        /// <summary>
        /// Método para edição de dados do administrador
        /// </summary>
        /// <param name="adm">Objeto da classe administrador, uso dos modelos</param>
        public void EditarAdministrador(Administrador adm)
        {
            if (clsUtilidades.ValidarOid(adm._id))
            {
                dalAdmin.atualizar(adm);
            }
            else
            { throw new OidException(); }

        }

        /// <summary>
        /// Método utilizado para editar apenas a situação de algum administrador
        /// </summary>
        /// <param name="adm">Objeto da classe administrador, passar o ID para editar a situação</param>
        public void EditarSituacao(Administrador adm)
        {
            if (clsUtilidades.ValidarOid(adm._id))
            {
                if (Regex.IsMatch(adm.situacao.ToString(), @"^[:c:d:Po]{20,250}$"))
                {
                    if (objAdmin == null)
                    {
                        objAdmin = new Administrador();
                        //todo: Implementar método para edição de situação
                    }
                }
                else
                { throw new Exception("Situação inválida."); }
            }
            else
            { throw new OidException(); }
        }

        /// <summary>
        /// Método utilizado para exclusão de um administrador
        /// </summary>
        /// <param name="adm">Objeto da classe administrador, passar o ID para editar a situação</param>
        public void ExcluirAdministrador(Administrador adm)
        {
            if (clsUtilidades.ValidarOid(adm._id))
            {
                if (objAdmin == null)
                {
                    objAdmin = new Administrador();
                    //todo: Implementar método para edição de situação
                }
            }
            else
            { throw new OidException(); }
        }

        #endregion

        List<Administrador> ltAdmin;
        #region === Search ===

        /// <summary>
        /// Método usado para buscar administrador por ID 
        /// </summary>
        /// <param name="idAdmin">ID de um administrador</param>
        /// <returns>Administrador por ID passado no parâmetro</returns>
        public Administrador BuscarAdministradorPorID(Oid idAdmin)
        {
            if (Regex.IsMatch(idAdmin.ToString(), @"[:c:d]{1,24}"))
            {
                if (objAdmin == null)
                {
                    objAdmin = new Administrador();
                    objAdmin._id = idAdmin;
                }
                Administrador objRetorno = new Administrador();
                objRetorno = dalAdmin.buscaAdminisUnico(objAdmin);
                return objRetorno;
            }
            else
            { throw new Exception("ID do administrador não encontrado."); }
        }

        /// <summary>
        /// Método para busca de Administrador por nome
        /// </summary>
        /// <param name="nome">Nome do administrador</param>
        /// <returns>Lista com os administrador com o determinado nome</returns>
        public List<Administrador> BuscarAdministradorPorNome(string nome)
        {
            if (Regex.IsMatch(nome, @"^[:c:d:Po]{10,250}$"))
            {
                if (ltAdmin == null)
                {
                    ltAdmin = new List<Administrador>();
                    //todo: implementar método de busca de administrador por nome
                }
                return ltAdmin;
            }
            else
            { throw new Exception("Nome inválido."); }
        }

        /// <summary>
        /// Método para busca de todos os administradores
        /// </summary>
        /// <returns>Retorna uma lista com todos os administradores</returns>
        public List<Administrador> BuscarTodosAdmnistradores()
        {
            if (ltAdmin == null)
            {
                ltAdmin = new List<Administrador>();
                //todo: implementar método para buscar todos os administradores
            }
            return ltAdmin;
        }

        /// <summary>
        /// Verifica a disponibilidade daquele email, ja que não podem existir dois iguais
        /// </summary>
        /// <param name="email">Email(login) da pessoa</param>
        /// <returns>Se não achar true se achar false</returns>
        public List<Document> VerificaDisponibilidade(string email)
        {
            return dalAdmin.verificaDisponibilidade(email);
        }

        /// <summary>
        /// Busca aquele adiministrador que tem aquele email
        /// </summary>
        /// <param name="email">email do administrador</param>
        /// <returns>Resultado da query</returns>
        public List<Administrador> BuscaAdministradorPorEmail(string email)
        {
            return dalAdmin.buscaPorEmail(email);
        }

        #endregion

        /// <summary>
        /// Método usado para login do adminastrador
        /// </summary>
        /// <param name="senha">senha digitada no cadastro</param>
        /// <param name="login">login digitado no cadastro</param>
        /// <returns>Valor booleano, se for true, ele será logado, se for falso, não será.</returns>
        public List<Administrador> LogarViaLogin(string senha, string login)
        {
            List<Administrador> resposta = dalAdmin.logar(login, senha);
            return resposta;
        }

        /// <summary>
        /// Método usado para inativar algum usuário ausente
        /// </summary>
        /// <param name="adm">Instancia da classe Administrador</param>
        public void InativaAdmin(Administrador adm)
        {
            if (objAdmin == null)
            {
                objAdmin = new Administrador();
                dalAdmin = new ClsAdministradorDAL();

                dalAdmin.inativar(objAdmin);
            }
        }

        public dynamic carregaEstados()
        {
            XElement EC = XElement.Load("estadosCidades.xml");
            var E = from Estados in EC.Descendants("Estado") select EC.Attributes("NomeEstado");

            return E;
        }

        /// <summary>
        /// Esse metodo verifica qual administrador possui menos denuncia para que uma nova denuncia possa ser 
        /// veiculada a ele
        /// </summary>
        /// <returns>Oid do administrador com menos denuncias</returns>
        public Oid verificaMenorQuantDenuncia()
        {
            return dalAdmin.verificaMenorQuantDenuncia();
        }
    }
}
