using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Chrisimos.Net;
using Chrisimos.Seguranca.Criptografia.CriptografiaAssimetrica;
using Chrisimos.Validacoes;
using ClsLibDAL;
using Models;
using MongoDB;
using criptSimetrico = Chrisimos.Seguranca.Criptografia.CriptografiaSimetrica.CriptografiaSimetrica;

namespace ClsLibBLL
{
    public class ClsUsuarioBLL
    {
        ClsEnderecoBLL endereco;
        List<Usuario> ltUsuario;

        #region === CRUD ===
        /// <summary>
        /// Inserir um novo usuário no banco de dados
        /// </summary>
        /// <param name="usuario">Objeto contendo as informações do usuário</param>
        public void InserirUsuario(Usuario usuario)
        {
            //TODO: Alterar para SHA
            MD5 criptografia = new MD5();
            try
            {
                usuario.login = usuario.login.ToLower();
                usuario.senha = criptografia.criptografar(usuario.senha);
                usuario.email = usuario.email.ToLower();
                validaCadastroLogin(usuario);
                ClsUsuDAL usuarioDAL = new ClsUsuDAL();
                usuario.status = 3; // Status: Cadastro não confirmado
                usuario.dataCadastro = DateTime.Now;

                usuarioDAL.InserirUsu(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EditarUsuario(Usuario usuario)
        {
            // Retirei o método de validação daqui pois como o editar será feito em várias telas não
            // da para saber qual validação chamar.
            usuario.login = usuario.login.ToLower();
            usuario.email = usuario.email.ToLower();
            ClsUsuDAL usuarioDAL = new ClsUsuDAL();
            usuarioDAL.EditarUsu(usuario);
        }

        public void AlterarSenha(Oid id, string senha)
        {
            ClsUsuDAL usuarioDAL = new ClsUsuDAL();
            AlterarSenha(usuarioDAL.BuscarUsuarioPorId(id), senha);
        }

        public void AlterarSenha(Usuario usu, string senha)
        {
            if (usu == null) throw new Exception("Usuário inválido.");
            
            senha = senha.Trim();
            if (!Regex.IsMatch(senha, ClsConstantesBLL.Ler("regex", "usuarioSenha"))) throw new Exception("Senha inválida. Uma senha tem que conter entre 2 e 20 caracteres alfanuméricos.");
            
            ClsUsuDAL usuarioDAL = new ClsUsuDAL();

            //TODO: Alterar para SHA
            MD5 criptografia = new MD5();

            usu.senha = criptografia.criptografar(senha);
            usuarioDAL.EditarUsu(usu);
        }

        #region === Editar ===

        /// <summary>
        /// Editar as informações de login usuário no banco de dados
        /// </summary>
        /// <param name="usuario">Objeto contento as informações do usuário que deve ser editado</param>
        public void EditarLoginUsuario(Usuario usuario, string id)
        {
            if (Regex.IsMatch(usuario.login, @"^[a-zA-Z0-9-_.#@]{2,28}$"))
            {
                if (Regex.IsMatch(usuario.nome, @"^[a-zA-Z0-9 :Wh áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ]{2,20}$"))
                {
                    if (Regex.IsMatch(usuario.senha, @"^[a-zA-Z0-9 :Wh áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ]{2,20}$"))
                    {
                        if (Regex.IsMatch(usuario.email, @"^([0-9a-zA-Z]+([_.-]?[0-9a-zA-Z]+)*@[0-9a-zA-Z]+[0-9,a-z,A-Z,.,-]*(.){1}[a-zA-Z]{2,4})+$"))
                        {
                            ClsUsuDAL usuarioDAL = new ClsUsuDAL();
                            Oid idUsu = new Oid(id);
                            usuario._id = idUsu;
                            usuarioDAL.EditarUsu(usuario);
                        }
                        else
                        { throw new Exception("E-mail Inválido! Digite seu e-mail de acordo com os padrões."); }
                    }
                    else
                    { throw new Exception("Senha Inválida!"); }
                }
                else
                { throw new Exception("Nome inválido! Não pode ter caracteres especiais nem ser menos que 8 caractéres."); }
            }
            else
            { throw new Exception("Login inválido! Não pode ser nulo e maio que 28 caracteres."); }
        }

        /// <summary>
        /// Editar as informações pessoais do usuário no banco de dados
        /// </summary>
        /// <param name="usuario">Objeto da classe model Usuario</param>
        /// <param name="id">Id passado do usuario por url</param>
        /// <by>Marcio Mansur - marciorabelom@hotmail.com</by>
        public void EditarPessoalUsuario(Usuario usuario, string id)
        {
            //if (Regex.IsMatch(usuario.rg, @"(^(\d{2}.\d{3}.\d{3})|(\d{8})$)"))
            //TODO: Refazer a regex de rg.
            if (Regex.IsMatch(usuario.rg, @"^[a-zA-Z0-9 \.-]{8,15}$"))
            {
                if (ValidaDocumentos.ValidarCpf(usuario.cpf_cnpj))
                {
                    if (string.IsNullOrEmpty(usuario.celular1) || Regex.IsMatch(usuario.celular1, @"^\(?\d{2}\)?[\s-]?\d{4}-?\d{4}$") && (string.IsNullOrEmpty(usuario.celular2) || Regex.IsMatch(usuario.celular2, @"^\(?\d{2}\)?[\s-]?\d{4}-?\d{4}$")))
                    {
                        if (((string.IsNullOrEmpty(usuario.telefone1) || Regex.IsMatch(usuario.celular1, @"^\(?\d{2}\)?[\s-]?\d{4}-?\d{4}$")) && (string.IsNullOrEmpty(usuario.telefone2) || Regex.IsMatch(usuario.celular2, @"^\(?\d{2}\)?[\s-]?\d{4}-?\d{4}$"))))
                        {
                            if (usuario.dataNasc <= DateTime.Now.Date.AddYears(-14))
                            {
                                ClsUsuDAL usuarioDAL = new ClsUsuDAL();
                                Oid idUsu = new Oid(id);
                                usuario._id = idUsu;
                                usuarioDAL.EditarUsu(usuario);
                            }
                            else
                            { throw new Exception("Data de nascimento está fora dos padrões!"); }
                        }
                        else
                        { throw new Exception("Algum dos telefones não foi digitado corretamente."); }
                    }
                    else
                    { throw new Exception("Algum dos celulares não foi digitado corretamente."); }
                }
                else
                { throw new Exception("CPF inválido!"); }
            }
            else
            { throw new Exception("RG inválido! Verifique os numeros em sua carteira de identidade."); }
        }

        /// <summary>
        /// Método que edita o endereço informado por um usuário
        /// </summary>
        /// <param name="usuario">Objeto da classe model usuario</param>
        /// <param name="id">Id do usuario passado na URL</param>
        /// <by>Marcio Mansur - marciorabelom@hotmail.com</by>
        public void EditarPessoaEndereco(Usuario usuario, string id)
        {
            endereco = new ClsEnderecoBLL();

            if (usuario.enderecosUsuario.Count > 0)
            {
                if (endereco.ValidarEndereco(usuario.enderecosUsuario[0]))
                {
                    ClsUsuDAL usuarioDAL = new ClsUsuDAL();
                    Oid idUsu = new Oid(id);
                    usuario._id = idUsu;
                    usuarioDAL.EditarUsu(usuario);
                }
                else
                {
                    throw new Exception();
                }
            }
            else
            {
                throw new Exception();
            }
        }

        #endregion

        /// <summary>
        /// Desativa o usuário e exclui as suas atualizações.
        /// </summary>
        /// <param name="idUsuario">Oid do usuário q deseja desativar.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void DesativarUsuario(Oid idUsuario)
        {
            if (clsUtilidades.ValidarOid(idUsuario))
            {
                ClsAtualizacaoDAL atualizacaoDAL = new ClsAtualizacaoDAL();
                atualizacaoDAL.ExcluirAtualizacoes(idUsuario);

                ClsContatoBLL contatoBLL = new ClsContatoBLL();
                contatoBLL.ExcluirTodosContatos(idUsuario);

                ClsServicosDAL servicoDAL = new ClsServicosDAL();
                servicoDAL.DesativarTodosServicos(idUsuario);
            }
            else
            {
                throw new Exception("Oid inválido, por favor, recarregue a página e tente novamente.");
            }
        }
        #endregion
        #region === Login ===
        /// <summary>
        /// Logar usuário atravéz do login(ou email) e senha.
        /// </summary>
        /// <param name="usu">Objeto de usuário contendo os campos email, login e senha, preenchidos.</param>
        /// <returns>Retorna um valor bool indicando se o login é válido ou não.</returns>
        public bool Logar(ref Usuario usu)
        {
            if (Regex.IsMatch(usu.login, @"^[a-zA-Z0-9 @._-]{2,28}$"))
            {
                if (!string.IsNullOrEmpty(usu.senha.Trim()))
                {
                    // chama o método de logar
                    ClsUsuDAL usuarioDAL = new ClsUsuDAL();
                    return usuarioDAL.VerificarLogin(ref usu);
                }
                else { throw new Exception("Digite a sua senha para entrar!"); }
            }
            else { throw new Exception("Campo de login não pode ser nulo!"); }
        }

        #endregion
        #region === Buscas ===
        public Usuario BuscarUsuarioPorID(Oid idUsuario)
        {
            ClsUsuDAL usuarioDAL = new ClsUsuDAL();
            return usuarioDAL.BuscarUsuarioPorId(idUsuario);
        }

        public List<Usuario> BuscarUsuarioPorNome(string nome)
        {
            //if (Regex.IsMatch(nome, @"^[a-zA-Z :Wh âàãáâéêõôóíúù]{2,25}$"))
            if (!string.IsNullOrEmpty(nome.Trim()))
            {
                ClsUsuDAL usuarioDAL = new ClsUsuDAL();
                ltUsuario = new List<Usuario>();
                ltUsuario = usuarioDAL.BuscarUsuarioPorNome(nome);
                return ltUsuario;
            }
            else { throw new Exception("Informe o filtro da busca."); }
        }

        public List<Usuario> BuscarUsuarioPorEmail(string email)
        {
            //if (Regex.IsMatch(email, "^[a-zA-Z0-9._%+-]{1,30}+@[a-zA-Z0-9.-]{1,10}+\\.[a-zA-Z]{2,4}$"))
            if (!string.IsNullOrEmpty(email.Trim()))
            {
                ClsUsuDAL usuarioDAL = new ClsUsuDAL();
                ltUsuario = new List<Usuario>();
                ltUsuario = usuarioDAL.BuscarUsuarioPorEmailRegex(email);
                return ltUsuario;
            }
            else { throw new Exception("E-mail inválido"); }
        }

        public List<Usuario> BuscarUsuarioPorLogin(string login)
        {
            //if (Regex.IsMatch(login, @"^[a-zA-Z0-9 :Po]{2,28}$"))
            if (!string.IsNullOrEmpty(login.Trim()))
            {
                ClsUsuDAL usuarioDAL = new ClsUsuDAL();
                ltUsuario = new List<Usuario>();
                ltUsuario = usuarioDAL.BuscarUsuarioPorLoginRegex(login);
                return ltUsuario;
            }
            else { throw new Exception("Login inválido"); }
        }

        public Usuario BuscarUsuarioAtivoPorLogin(string login)
        {
            if (Regex.IsMatch(login, ClsConstantesBLL.Ler("regex", "usuarioLogin")))
            {
                ClsUsuDAL usuarioDAL = new ClsUsuDAL();
                return usuarioDAL.BuscarUsuarioAtivoPorLogin(login);
            }
            else
            { throw new Exception("Login inválido"); }
        }

        public Usuario BuscarUsuarioAtivoPorEmail(string email)
        {
            if (Regex.IsMatch(email, ClsConstantesBLL.Ler("regex", "usuarioEmail")))
            {
                ClsUsuDAL usuarioDAL = new ClsUsuDAL();
                return usuarioDAL.BuscarUsuarioAtivoPorEmail(email);
            }
            else
            { throw new Exception("E-mail inválido"); }
        }

        /// <summary>
        /// Busca 9 contatos aleatóriamente no network do usuário logado
        /// </summary>
        /// <returns>Retorna uma lista com os 9 contatos do usuário logado</returns>
        public List<Usuario> BuscarAleatorio()
        {
            ClsUsuDAL usuarioDAL = new ClsUsuDAL();
            ltUsuario = new List<Usuario>();
            // chamar método de busca.
            return ltUsuario;
        }

        /// <summary>
        /// Busca todos os contatos do usuário logado
        /// </summary>
        /// <returns>Retorna uma lista com todos os contatos do usuário logado.</returns>
        public List<Usuario> BuscarTodosContatos()
        {
            ClsUsuDAL usuarioDAL = new ClsUsuDAL();
            ltUsuario = new List<Usuario>();
            // chamar método de busca.
            return ltUsuario;
        }

        /// <summary>
        /// Busca a quantidade de contatos do usuário
        /// </summary>
        /// <returns>Retorna a quantidade de contatos que o usuário logado possui</returns>
        public long BuscarQtdContatos()
        {
            var dados = BuscarTodosContatos();
            return dados.Count;
        }

        /// <summary>
        /// Método para buscar o status do usuário a partir de seu Oid.
        /// </summary>
        /// <param name="_id">Oid do usuário a ser usado como filtro da busca.</param>
        /// <returns>Retorna o status do usuário.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Status BuscarStatus(Oid _id)
        {
            ClsUsuDAL usuarioDAL = new ClsUsuDAL();
            switch (usuarioDAL.BuscarStatus(_id))
            {
                case "0":
                    return Status.Ativado;
                case "1":
                    return Status.Desativado;
                case "2":
                    return Status.Banido;
                default:
                    throw new Exception("Ocorreu um erro inesperado ao buscar o status do usuário.");
            }
        }

        /// <summary>
        /// Método para buscar o status do usuário a partir de seu Oid.
        /// </summary>
        /// <param name="_id">Oid do usuário a ser usado como filtro da busca.</param>
        /// <returns>Retorna o status do usuário.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Status BuscarStatus(string _id)
        {
            ClsUsuDAL usuarioDAL = new ClsUsuDAL();
            switch (usuarioDAL.BuscarStatus(_id))
            {
                case "0":
                    return Status.Ativado;
                case "1":
                    return Status.Desativado;
                case "2":
                    return Status.Banido;
                default:
                    throw new Exception("Ocorreu um erro inesperado ao buscar o status do usuário.");
            }
        }

        /// <summary>
        /// Método que busca o e-mail de um usuário.
        /// </summary>
        /// <param name="_id">Oid do usuário que é usado para buscar o e-mail dele.</param>
        /// <returns>Retorna o e-mail do usuário.</returns>
        /// <exception cref="OidException">Manda esta exception quando o Oid informado for inválido.</exception>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public string BuscarEmail(Oid _id)
        {
            if (clsUtilidades.ValidarOid(_id))
            {
                ClsUsuDAL usuarioDAL = new ClsUsuDAL();
                return usuarioDAL.BuscarEmail(_id);
            }
            else 
            {
                throw new OidException("Oid inválido.");
            }
        }

        /// <summary>
        /// Método que busca o e-mail de um usuário.
        /// </summary>
        /// <param name="_id">Oid do usuário que é usado para buscar o e-mail dele.</param>
        /// <returns>Retorna o e-mail do usuário.</returns>
        /// <exception cref="OidException">Manda esta exception quando o Oid informado for inválido.</exception>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public string BuscarEmail(string _id)
        {
            Oid id = new Oid(_id);
            return BuscarEmail(id);
        }

        /// <summary>
        /// Verifica se existe um usuário ativo com o email informado.
        /// </summary>
        /// <param name="email">Email do usuário, usado para buscar se tem algum usuário com esse e-mail.</param>
        /// <returns>Retorna um valor booleano, sendo true se existir um usuário com este e-mail.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public bool ExisteUsuarioAtivoPorEmail(string email)
        {
            if (!Regex.IsMatch(email.Trim(), ClsConstantesBLL.Ler("regex", "usuarioEmail")))
                throw new Exception("E-mail inválido.");
            ClsUsuDAL usuarioDAL = new ClsUsuDAL();
            return usuarioDAL.Count(NomeCompBd.usuarioEmail, email, Status.Ativado) > 0;
        }

        /// <summary>
        /// Verifica se existe um usuário ativo com o login informado.
        /// </summary>
        /// <param name="login">Login do usuário, usado para buscar se tem algum usuário com esse login.</param>
        /// <returns>Retorna um valor booleano, sendo true se existir um usuário com este login.</returns>
        /// <by>Thiago Vieira - t.vas@Hotmail.com</by>
        public bool ExisteUsuarioAtivoPorLogin(string login)
        {
            if (!Regex.IsMatch(login.Trim(), ClsConstantesBLL.Ler("regex", "usuarioLogin")))
                throw new Exception("Login inválido.");
            ClsUsuDAL usuarioDAL = new ClsUsuDAL();
            return usuarioDAL.Count(NomeCompBd.usuarioLogin, login.Trim(), Status.Ativado) > 0;
        }

        #endregion
        #region === Recuperação de senha ===
        /// <summary>
        /// Manda um email para o usuario que perdeu a sua senha com um link para redefini-la.
        /// </summary>
        /// <param name="userName">Login ou E-mail do usuário.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void EnviarEmailRecuperarSenha(string userName)
        {
            #region === Gera o valor da chave para a recuperação da senha ===
            criptSimetrico cs = new criptSimetrico();
            cs.Key = ClsConstantesBLL.Ler("chave", "recuperarSenha");
            string valorCriptografado = cs.Encrypt(string.Format("{0};{1}", DateTime.Now, userName.Trim()));
            #endregion

            ClsUsuDAL usuarioDAL = new ClsUsuDAL();

            //Alterar esta linha abaixo: usar o caminho da página no servidor ao invés do site.
            string link = "www.net3s.com.br/ReescreverSenha.aspx?x='" + valorCriptografado + "'";
            if (Regex.IsMatch(userName, @"^([0-9a-zA-Z]+([_.-]?[0-9a-zA-Z]+)*@[0-9a-zA-Z]+[0-9,a-z,A-Z,.,-]*(.){1}[a-zA-Z]{2,4})+$"))
            {
                if (usuarioDAL.Count(NomeCompBd.usuarioEmail, userName, Status.Ativado) > 0 || usuarioDAL.Count(NomeCompBd.usuarioEmail, userName, Status.CadNaoConfirmado) > 0)
                {
                    Usuario usu = usuarioDAL.BuscarUsuarioAtivoPorEmail(userName);
                    EnviarEmailRecuperarSenha(usu, userName, link);
                }
                else
                {
                    throw new Exception("Email não encontrado.");
                }
            }
            else
            {
                if (usuarioDAL.Count(NomeCompBd.usuarioLogin, userName, Status.Ativado) > 0 || usuarioDAL.Count(NomeCompBd.usuarioLogin, userName, Status.CadNaoConfirmado) > 0)
                {
                    Usuario usu = usuarioDAL.BuscarUsuarioAtivoPorLogin(userName);
                    EnviarEmailRecuperarSenha(usu, userName, link);
                }
                else
                {
                    throw new Exception("Login não encontrado.");
                }
            }
        }

        /// <summary>
        /// Manda um email para o usuario que perdeu a sua senha com um link para redefini-la.
        /// </summary>
        /// <param name="usu">Objeto do tipo usuário com os dados do usuário que perdeu a senha.</param>
        /// <param name="userName">Login ou E-mail do usuário.</param>
        /// <param name="link">Link enviado junto com o e-mail</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        private void EnviarEmailRecuperarSenha(Usuario usu, string userName, string link)
        {
            Chrisimos.Net.Email objEmail = new Chrisimos.Net.Email();
            string msgEmail = "Ol&aacute; " + usu.nome + "<br />Para redefinir a sua senha basta clicar no link abaixo<br />";
            msgEmail += string.Format("<a href='{0}'>{0}</a>", link);
            msgEmail += "<br /><br />Obrigado,<br />Equipe Net3Services";

            objEmail.enviarEmail("net3services@gmail.com", "n3shdi.6w-a", "smtp.gmail.com",
                                587, userName, "Recuperação de senha - Net3Services", msgEmail,
                                true, true, "Net3Services");
        }

        /// <summary>
        /// Valida a chave recebida pela URL na pagina RecuperarSenha.aspx
        /// </summary>
        /// <param name="valorChave">Valor da chave recebida na URL.</param>
        /// <returns>Retorna uma valor booleano indicando se a chave é valida ou não.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        private bool ValidarChaveRecuperacaoSenha(string valorChave)
        {
            criptSimetrico cs = new criptSimetrico();
            cs.Key = ClsConstantesBLL.Ler("chave", "recuperarSenha");
            valorChave = cs.Decrypt(valorChave);

            //Se a chave nao tiver dois valores separados por um ponto-e-vírgula, ela nao é válida.
            if (valorChave.Split(';').GetLength(0) != 2)
                return false;

            try
            {
                if (Convert.ToDateTime(valorChave.Split(';')[0]) < DateTime.Now.AddDays(-3))
                    return false;
            }
            catch
            { return false; }
            
            return true;
        }

        /// <summary>
        /// Retorna o username que está guardado em uma chave encriptada.
        /// </summary>
        /// <param name="valorChave">Chave criptografada.</param>
        /// <returns>Retorna o username que está guardado em uma chave encriptada.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public string RetornarUsernameRecuperacaoSenha(string valorChave)
        {
            criptSimetrico cs = new criptSimetrico();
            cs.Key = ClsConstantesBLL.Ler("chave", "recuperarSenha");
            valorChave = cs.Decrypt(valorChave);

            if (!ValidarChaveRecuperacaoSenha(valorChave))
                throw new Exception("Chave inválida.");

            return valorChave.Split(';')[1];
        }
        #endregion
        #region === Validação Cadastro ===
        /// <summary>
        /// Verifica se o cadastro do usuário informado está completo, ou seja, possui as informações básicas que possibilitem
        /// ele a cadastrar/contratar um serviço. As informações mínimas são: CPF/CNPJ cadastrado.
        /// </summary>
        /// <param name="usu">Usuário que deve ser verificado</param>
        /// <returns>Retorna verdadeiro caso o usuário possui o cadastro completo</returns>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        public bool VerificarCompCadastro(Usuario usu)
        {
            if (string.IsNullOrEmpty(usu.cpf_cnpj))
                return false;
            else
                return true;
        }

        /// <summary>
        /// Função que valida o step de cadastros de login
        /// </summary>
        /// <param name="usuario">Objeto do modelo usuario</param>
        /// <returns>True se estiver tudo de acordo</returns>
        public void validaCadastroLogin(Usuario usuario)
        {
            if (Regex.IsMatch(usuario.login, @"^[a-zA-Z0-9-_.]{2,28}$"))
            {
                if (Regex.IsMatch(usuario.nome, @"^[a-zA-Z0-9 :Wh áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ]{2,60}$"))
                {
                    if (Regex.IsMatch(usuario.senha, @"^[a-zA-Z0-9 :Wh :Po áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ]{6,34}$"))
                    {
                        if (Regex.IsMatch(usuario.email, @"^([0-9a-zA-Z]+([_.-]?[0-9a-zA-Z]+)*@[0-9a-zA-Z]+[0-9,a-z,A-Z,.,-]*(.){1}[a-zA-Z]{2,4})+$"))
                        {
                            ClsUsuDAL usuarioDAL = new ClsUsuDAL();
                            if (usuarioDAL.Count(NomeCompBd.usuarioLogin, usuario.login, null) <= 0)
                            {
                                if (usuarioDAL.Count(NomeCompBd.usuarioEmail, usuario.email, null) > 0)
                                {
                                    throw new Exception("Já existe um usuário com este e-mail, por favor, use outro e-mail.");
                                }
                            }
                            else
                            {
                                throw new Exception("Já existe um usuário com este login, por favor, escolha outro login.");
                            }
                        }
                        else
                        { throw new Exception("E-mail Inválido! Digite seu e-mail de acordo com os padrões."); }
                    }
                    else
                    { throw new Exception("Senha Inválida!"); }
                }
                else
                { throw new Exception("Nome inválido! Não pode ter caracteres especiais nem ser menos que 8 caractéres."); }
            }
            else
            { throw new Exception("Login inválido! Não pode ser nulo e maio que 28 caracteres."); }
        }

        public string[] ValidarConfiguracoesGerais(Usuario usuario)
        {
            string[] retorno = new string[5];
            ClsUsuDAL usuarioDAL = new ClsUsuDAL();

            if (Regex.IsMatch(usuario.nome, @"^[a-zA-Z0-9 :Wh áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ]{2,60}$"))
                retorno[0] = "ok";
            else
                retorno[0] = "Nome inválido.O nome não pode conter caracteres especiais nem possuir menos que 8 caracteres.";


            if (Regex.IsMatch(usuario.login, @"^[a-zA-Z0-9 :Po]{2,28}$"))
                retorno[1] = "ok";
            else
                retorno[1] = "Login inválido. O login deve possuir entre 2 e 28 caracteres.";

            if (retorno[1] == "ok")
            {
                if (usuarioDAL.Count(NomeCompBd.usuarioLogin, usuario.login, Status.Ativado) <= 0 && usuarioDAL.Count(NomeCompBd.usuarioLogin, usuario.login, Status.CadNaoConfirmado) <= 0)
                    retorno[1] = "ok";
                else
                    retorno[1] = "Este login já está sendo utilizado por outro usuário.";
            }

            if (Regex.IsMatch(usuario.email, @"^([0-9a-zA-Z]+([_.-]?[0-9a-zA-Z]+)*@[0-9a-zA-Z]+[0-9,a-z,A-Z,.,-]*(.){1}[a-zA-Z]{2,4})+$"))
                retorno[2] = "ok";
            else
                retorno[2] = "Informe um e-mail válido.";

            if (retorno[2] == "ok")
            {
                if (usuarioDAL.Count(NomeCompBd.usuarioEmail, usuario.email, Status.Ativado) <= 0 && usuarioDAL.Count(NomeCompBd.usuarioEmail, usuario.email, Status.CadNaoConfirmado) <= 0)
                    retorno[2] = "ok";
                else
                    retorno[2] = "Este e-mail já está sendo utilizado por outro usuário.";
            }

            if (usuario.dataNasc >= DateTime.Now)
                retorno[3] = "A data de nascimento não pode ser superior a data atual.";
            else
                retorno[3] = "ok";

            if (usuario.sexo == "0" || usuario.sexo == "1")
                retorno[4] = "ok";
            else
                retorno[4] = "Selecione seu sexo.";

            return retorno;
        }

        public string[] ValidarConfiguracoesInfoPessoais(Usuario usuario)
        {
            string[] resposta = new string[7];
            ClsUsuDAL usuarioDAL = new ClsUsuDAL();

            if ((usuarioDAL.Count(NomeCompBd.usuarioRg, usuario.rg, Status.Ativado) <= 0 && usuarioDAL.Count(NomeCompBd.usuarioRg, usuario.rg, Status.CadNaoConfirmado) <= 0) || string.IsNullOrEmpty(usuario.rg))
                resposta[0] = "ok";
            else
                resposta[0] = "Outro usuário está cadastrado com este rg";


            if ((usuarioDAL.Count(NomeCompBd.usuarioCpf_cnpj, usuario.cpf_cnpj, Status.Ativado) <= 0 && usuarioDAL.Count(NomeCompBd.usuarioCpf_cnpj, usuario.cpf_cnpj, Status.CadNaoConfirmado) <= 0) || string.IsNullOrEmpty(usuario.cpf_cnpj))
            {
                if (string.IsNullOrEmpty(usuario.cpf_cnpj) || ValidaDocumentos.ValidarCpf(usuario.cpf_cnpj))
                    resposta[1] = "ok";
                else
                    resposta[1] = "CPF inválido";
            }
            else
            {
                resposta[1] = "Outro usuário está cadastrado com este cpf";
            }


            if (Regex.IsMatch(usuario.telefone1, @"^\(\d{2}\)\d{4}-\d{4}$") || string.IsNullOrEmpty(usuario.telefone1))
                resposta[2] = "ok";
            else
                resposta[2] = "Telefone inválido";

            if (Regex.IsMatch(usuario.telefone2, @"^\(\d{2}\)\d{4}-\d{4}$") || string.IsNullOrEmpty(usuario.telefone2))
                resposta[3] = "ok";
            else
                resposta[3] = "Telefone 2 inválido";

            if (Regex.IsMatch(usuario.celular1, @"^\(\d{2}\)\d{4}-\d{4}$") || string.IsNullOrEmpty(usuario.celular1))
                resposta[4] = "ok";
            else
                resposta[4] = "Celular inválido";

            if (Regex.IsMatch(usuario.celular2, @"^\(\d{2}\)\d{4}-\d{4}$") || string.IsNullOrEmpty(usuario.celular2))
                resposta[5] = "ok";
            else
                resposta[5] = "Celular inválido";

            if (Regex.IsMatch(usuario.site, @"([\w\d:#@%/;$()~_?\+-=\\\.&]*)"))
                resposta[6] = "ok";
            else
                resposta[6] = "Site inválido";

            return resposta;
        }

        public string[] ValidarConfigEnrereco(Usuario usuario)
        {
            var endereco = usuario.enderecosUsuario[0];
            string[] resposta = new string[8];

            if (Regex.IsMatch(endereco.pais, @"^[a-zA-Z0-9 :Wh áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ]{2,60}$"))
                resposta[0] = "ok";
            else
                resposta[0] = "Selecione um país";

            if (Regex.IsMatch(endereco.uf, @"^[a-zA-Z0-9 :Wh áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ -]{2,60}$"))
                resposta[1] = "ok";
            else
                resposta[1] = "Selecione um estado";

            if (Regex.IsMatch(endereco.cidade, @"^[a-zA-Z0-9 :Wh áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ]{2,60}$"))
                resposta[2] = "ok";
            else
                resposta[2] = "Selecione uma cidade";

            if (Regex.IsMatch(endereco.cep, @"^\d{5}\-\d{3}$"))
                resposta[3] = "ok";
            else
                resposta[3] = "Informe um CEP válido";

            if (Regex.IsMatch(endereco.bairro, @"^[a-zA-Z0-9 :Wh áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ]{2,60}$"))
                resposta[4] = "ok";
            else
                resposta[4] = "O bairro deve possuir entre 2 e 60 caracteres";

            if (Regex.IsMatch(endereco.logradouro, @"^[a-zA-Z0-9 :Wh áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ]{2,60}$"))
                resposta[5] = "ok";
            else
                resposta[5] = "O bairro deve possuir entre 2 e 60 caracteres";

            if (endereco.numero > 0)
                resposta[6] = "ok";
            else
                resposta[6] = "O número do imóvel deve ser superior a zero";

            if (string.IsNullOrEmpty(endereco.complemento) || Regex.IsMatch(endereco.logradouro, @"^[a-zA-Z0-9 :Wh]{1,20}$"))
                resposta[7] = "ok";
            else
                resposta[7] = "O complemento deve possuir entre 1 e 20 caractéres alfanuméricos, sem acentos";

            return resposta;
        }

        #endregion
        #region === Codigo de verificacao ===
        /// <summary>
        /// Executa a confirmação do cadastro do usuário informado
        /// </summary>
        /// <param name="codVerificacao">Código de verificação do cadastro do usuário de que se deve confirmar o cadastro</param>
        /// <returns>Objeto do usuário que possui o código de verificação informado</returns>
        /// <by>Breno Silva e Pires - breno_spires@hotmail.com</by>
        public Usuario ConfirmarCadastro(string codVerificacao)
        {
            ClsUsuDAL usuarioDAL = new ClsUsuDAL();

            try
            {
                Usuario usu = usuarioDAL.ConfirmarCadastro(codVerificacao);
                return usu;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }

        /// <summary>
        /// Envia o e-mail de confirmação de cadastro ao usuário.
        /// </summary>
        /// <param name="mUsu">Objeto do usuário ao qual deve ser enviado o e-mail de confirmação de cadastro.</param>
        /// <param name="senha">Senha do usuário. Obs: não está sendo utilizada a senha do objeto pois ela está criptografada.</param>
        /// <by>Breno Silva e Pires - breno_spires@hotmail.com</by>
        public void EnviarEmailConfirmacao(Usuario mUsu, string senha)
        {
            Email email = new Email();
            MD5 hash = new MD5();
            string criptografia = hash.criptografar(mUsu.dataCadastro.ToString());
            String msgEmail = string.Format("<p><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>Olá {0}.<br /> Abaixo seguem seus dados e seu link de confirmação do Net 3 Services.</p>", mUsu.nome);
            msgEmail += string.Format("<br /><p><b>Dados:</b></p><p>Nome: {0}</p><p>Login: {1}</p><p>Senha: {2}</p>", mUsu.nome, mUsu.login, senha);
            msgEmail += string.Format("<p>Click <a href='net3s.com.br/ConfirmarCadastro.aspx?c={0}'>aqui</a></strong> para confirmar seu cadastro.</p>", mUsu.codigoConfirma);
            msgEmail += "<p>Entre no endereço acima para ativar o seu cadastro.</p><p>Atenciosamente, Equipe Net 3 Services.</p></font></p>";
            email.enviarEmailConfirmacao(mUsu.email, "net3services@gmail.com", "n3shdi.6w-a", "smtp.gmail.com", 587, criptografia, msgEmail, "Net 3 Services");
        }

        #endregion
        #region === Imagem ===
        public bool VerificarImagem(string name)
        {
            try
            {
                if (!string.IsNullOrEmpty(name))
                {
                    ClsUsuDAL usuarioDAL = new ClsUsuDAL();
                    if (usuarioDAL.VerificarImagem(name))
                        return true;
                    return false;
                }
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AdicionarImagem(Stream myStream, string id)
        {
            if (myStream != null)
            {
                if (!string.IsNullOrEmpty(id))
                {
                    ClsUsuDAL usuarioDAL = new ClsUsuDAL();
                    usuarioDAL.InserirImgUsuario(myStream, id);
                }
                else { throw new Exception("Selecione o usuário que a foto deve ser adicionada."); }
            }
            else { throw new Exception("Selecione o arquivo da imagem que deve ser adicionada como sua foto de perfil."); }
        }

        public void EditarImagem(Stream myStream, string id)
        {
            if (myStream != null)
            {
                if (!string.IsNullOrEmpty(id))
                {
                    ClsUsuDAL usuarioDAL = new ClsUsuDAL();
                    usuarioDAL.AlterarImgUsuario(myStream, id);
                }
                else { throw new Exception("Selecione o usuário que a foto deve ser editada."); }
            }
            else { throw new Exception("Selecione o arquivo da imagem que deve ser adicionada como sua foto de perfil."); }
        }

        public void ExcluirImagem(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                ClsUsuDAL usuarioDAL = new ClsUsuDAL();
                usuarioDAL.DeletarImgUsuario(id);
            }
            else { throw new Exception("Selecione o usuário que a foto deve ser excluida."); }
        }
        #endregion
    }
}