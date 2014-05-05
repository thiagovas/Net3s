using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Chrisimos.Net
{
    public class Email
    {
        /// <summary>
        /// Este método tem a função de enviar e-mail.
        /// </summary>
        /// <param name="emailRemetente">O e-mail que será usado para enviar a mensagem.</param>
        /// <param name="senhaRemetente">Senha do e-mail que será usado para enviar a mensagem.</param>
        /// <param name="hostSmtp">Host smtp do e-mail que será usado para enviar a mensagem.</param>
        /// <param name="porta">Porta do host Smtp do e-mail que será usado para enviar a mensagem.</param>
        /// <param name="emailDestinatario">E-mail da pessoa que irá receber a mensagem.</param>
        /// <param name="assunto">Assunto do e-mail que será enviado.</param>
        /// <param name="mensagem">Mensagem que será mandada para o E-mail do destinatário.</param>
        /// <param name="isHtml">Variável booleana que guarda se o corpo da mensagem será escrita com tags em HTML.</param>
        /// <param name="enableSsl">Variável booleana que guarda se o host Smtp do e-mail que será usado para enviar a mensagem exije uma conexão segura, ou seja, se ele exije o uso do certificado SSL.</param>
        /// <param name="displayName">O nome que aparecerá na caixa de entrada do destinatário como quem enviou o E-mail.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void enviarEmail(string emailRemetente, string senhaRemetente, string hostSmtp, int porta, string emailDestinatario, string assunto, 
                                string mensagem, bool isHtml, bool enableSsl, string displayName)
        {
            if (!string.IsNullOrEmpty(emailRemetente.Trim()))
            {
                if (!string.IsNullOrEmpty(senhaRemetente.Trim()))
                {
                    if (!string.IsNullOrEmpty(hostSmtp.Trim()))
                    {
                        if (porta > 0 && porta < 65537)
                        {
                            if (!string.IsNullOrEmpty(emailDestinatario.Trim()))
                            {
                                if (!string.IsNullOrEmpty(assunto.Trim()))
                                {
                                    if (!string.IsNullOrEmpty(mensagem.Trim()))
                                    {
                                        if (!string.IsNullOrEmpty(displayName.Trim()))
                                        {
                                            #region === Enviar o e-mail ===
                                            MailMessage mail = new MailMessage();
                                            SmtpClient smtp = new SmtpClient(hostSmtp.Trim(), porta);
                                            smtp.EnableSsl = enableSsl;
                                            mail.From = new MailAddress(emailRemetente.Trim(), displayName.Trim());
                                            mail.To.Add(emailDestinatario.Trim());

                                            //Adicionei o Assunto, seguido pelo corpo do e-mail e afirmando que o email sera em html
                                            mail.Subject = assunto.Trim();
                                            mail.Body = mensagem.Trim();
                                            mail.IsBodyHtml = true;

                                            //Para autenticar, basta setar o usuário e a senha do servidor de SMTP
                                            smtp.Credentials = new NetworkCredential(emailRemetente.Trim(), senhaRemetente.Trim());

                                            //Envie o e-mail
                                            try
                                            {
                                                smtp.Send(mail);
                                            }
                                            catch (SmtpException)
                                            {
                                                string resposta = @"Ocorreu um erro ao mandar o e-mail\r\n\r\nPossíveis problemas:\r\n
                                            * Há problemas com a conexão com a internet;\r\n
                                            *O E-mail ou a senha usada para enviar a mensagem está inválida;
                                            *O e-mail do destinatário não existe.";
                                                throw new Exception(resposta);
                                            }
                                            #endregion
                                        }
                                        else
                                        { throw new ArgumentNullException("Informe o display name que será usado para te identificar no e-mail a ser enviado."); }
                                    }
                                    else
                                    { throw new ArgumentNullException("Informe a mensagem do e-mail."); }
                                }
                                else
                                { throw new ArgumentNullException("Informe o assunto do e-mail."); }
                            }
                            else
                            { throw new ArgumentNullException("Informe o email do destinatário."); }
                        }
                        else
                        { throw new ArgumentException("Porta informada inválida."); }
                    }
                    else
                    { throw new ArgumentNullException("Informe o host smtp que será usado para enviar a mensagem."); }
                }
                else
                { throw new ArgumentNullException("Informe a senha a ser usada para enviar a mensagem."); }
            }
            else
            { throw new ArgumentNullException("Informe o E-mail que será usado para enviar a mensagem."); }
        }

        /// <summary>
        /// Este método tem a função de enviar e-mail.
        /// </summary>
        /// <param name="emailRemetente">O e-mail que será usado para enviar a mensagem.</param>
        /// <param name="senhaRemetente">Senha do e-mail que será usado para enviar a mensagem.</param>
        /// <param name="hostSmtp">Host smtp do e-mail que será usado para enviar a mensagem.</param>
        /// <param name="porta">Porta do host Smtp do e-mail que será usado para enviar a mensagem.</param>
        /// <param name="emailDestinatario">E-mail da pessoa que irá receber a mensagem.</param>
        /// <param name="assunto">Assunto do e-mail que será enviado.</param>
        /// <param name="mensagem">Mensagem que será mandada para o E-mail do destinatário.</param>
        /// <param name="isHtml">Variável booleana que guarda se o corpo da mensagem será escrita com tags em HTML.</param>
        /// <param name="enableSsl">Variável booleana que guarda se o host Smtp do e-mail que será usado para enviar a mensagem exije uma conexão segura, ou seja, se ele exije o uso do certificado SSL.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void enviarEmail(string emailRemetente, string senhaRemetente, string hostSmtp, int porta, string emailDestinatario, string assunto,
                                string mensagem, bool isHtml, bool enableSsl)
        {
            if (!string.IsNullOrEmpty(emailRemetente.Trim()))
            {
                if (!string.IsNullOrEmpty(senhaRemetente.Trim()))
                {
                    if (!string.IsNullOrEmpty(hostSmtp.Trim()))
                    {
                        if (porta > 0 && porta < 65537)
                        {
                            if (!string.IsNullOrEmpty(emailDestinatario.Trim()))
                            {
                                if (!string.IsNullOrEmpty(assunto.Trim()))
                                {
                                    if (!string.IsNullOrEmpty(mensagem.Trim()))
                                    {
                                        #region === Enviar o e-mail ===
                                        MailMessage mail = new MailMessage();
                                        SmtpClient smtp = new SmtpClient(hostSmtp.Trim(), porta);
                                        smtp.EnableSsl = enableSsl;
                                        mail.From = new MailAddress(emailRemetente.Trim());
                                        mail.To.Add(emailDestinatario.Trim());

                                        //Adicionei o Assunto, seguido pelo corpo do e-mail e afirmando que o email sera em html
                                        mail.Subject = assunto.Trim();
                                        mail.Body = mensagem.Trim();
                                        mail.IsBodyHtml = true;

                                        //Para autenticar, basta setar o usuário e a senha do servidor de SMTP
                                        smtp.Credentials = new NetworkCredential(emailRemetente.Trim(), senhaRemetente.Trim());

                                        //Envie o e-mail
                                        try
                                        {
                                            smtp.Send(mail);
                                        }
                                        catch (SmtpException)
                                        {
                                            string resposta = @"Ocorreu um erro ao mandar o e-mail\r\n\r\nPossíveis problemas:\r\n
                                            * Há problemas com a conexão com a internet;\r\n
                                            *O E-mail ou a senha usada para enviar a mensagem está inválida;
                                            *O e-mail do destinatário não existe.";
                                            throw new Exception(resposta);
                                        }
                                        #endregion
                                    }
                                    else
                                    { throw new ArgumentNullException("Informe a mensagem do e-mail."); }
                                }
                                else
                                { throw new ArgumentNullException("Informe o assunto do e-mail."); }
                            }
                            else
                            { throw new ArgumentNullException("Informe o email do destinatário."); }
                        }
                        else
                        { throw new ArgumentException("Porta informada inválida."); }
                    }
                    else
                    { throw new ArgumentNullException("Informe o host smtp que será usado para enviar a mensagem."); }
                }
                else
                { throw new ArgumentNullException("Informe a senha a ser usada para enviar a mensagem."); }
            }
            else
            { throw new ArgumentNullException("Informe o E-mail que será usado para enviar a mensagem."); }
        }

        /// <summary>
        /// Este método tem a função de enviar e-mail.
        /// </summary>
        /// <param name="emailRemetente">O e-mail que será usado para enviar a mensagem.</param>
        /// <param name="senhaRemetente">Senha do e-mail que será usado para enviar a mensagem.</param>
        /// <param name="hostSmtp">Host smtp do e-mail que será usado para enviar a mensagem.</param>
        /// <param name="porta">Porta do host Smtp do e-mail que será usado para enviar a mensagem.</param>
        /// <param name="emailDestinatario">E-mail da pessoa que irá receber a mensagem.</param>
        /// <param name="assunto">Assunto do e-mail que será enviado.</param>
        /// <param name="mensagem">Mensagem que será mandada para o E-mail do destinatário.</param>
        /// <param name="isHtml">Variável booleana que guarda se o corpo da mensagem será escrita com tags em HTML.</param>
        /// <param name="enableSsl">Variável booleana que guarda se o host Smtp do e-mail que será usado para enviar a mensagem exije uma conexão segura, ou seja, se ele exije o uso do certificado SSL.</param>
        /// <param name="displayName">O nome que aparecerá na caixa de entrada do destinatário como quem enviou o E-mail.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void enviarEmail(string emailRemetente, string senhaRemetente, string hostSmtp, int porta, IEnumerable<string> emailDestinatario, string assunto,
                                string mensagem, bool isHtml, bool enableSsl, string displayName)
        {
            if (!string.IsNullOrEmpty(emailRemetente.Trim()))
            {
                if (!string.IsNullOrEmpty(senhaRemetente.Trim()))
                {
                    if (!string.IsNullOrEmpty(hostSmtp.Trim()))
                    {
                        if (porta > 0 && porta < 65537)
                        {
                            if (emailDestinatario.Count() > 0)
                            {
                                if (!string.IsNullOrEmpty(assunto.Trim()))
                                {
                                    if (!string.IsNullOrEmpty(mensagem.Trim()))
                                    {
                                        if (!string.IsNullOrEmpty(displayName.Trim()))
                                        {
                                            #region === Enviar o e-mail ===
                                            MailMessage mail = new MailMessage();
                                            SmtpClient smtp = new SmtpClient(hostSmtp.Trim(), porta);
                                            smtp.EnableSsl = enableSsl;
                                            mail.From = new MailAddress(emailRemetente.Trim(), displayName.Trim());
                                            foreach (string item in emailDestinatario)
                                                mail.To.Add(item.Trim());

                                            //Adicionei o Assunto, seguido pelo corpo do e-mail e afirmando que o email sera em html
                                            mail.Subject = assunto.Trim();
                                            mail.Body = mensagem.Trim();
                                            mail.IsBodyHtml = true;

                                            //Para autenticar, basta setar o usuário e a senha do servidor de SMTP
                                            smtp.Credentials = new NetworkCredential(emailRemetente.Trim(), senhaRemetente.Trim());

                                            //Envie o e-mail
                                            try
                                            {
                                                smtp.Send(mail);
                                            }
                                            catch (SmtpException)
                                            {
                                                string resposta = @"Ocorreu um erro ao mandar o e-mail\r\n\r\nPossíveis problemas:\r\n
                                            * Há problemas com a conexão com a internet;\r\n
                                            *O E-mail ou a senha usada para enviar a mensagem está inválida;
                                            *O e-mail do destinatário não existe.";
                                                throw new Exception(resposta);
                                            }
                                            #endregion
                                        }
                                        else
                                        { throw new ArgumentNullException("Informe o display name que será usado para te identificar no e-mail a ser enviado."); }
                                    }
                                    else
                                    { throw new ArgumentNullException("Informe a mensagem do e-mail."); }
                                }
                                else
                                { throw new ArgumentNullException("Informe o assunto do e-mail."); }
                            }
                            else
                            { throw new ArgumentNullException("Informe os E-mails dos destinatários."); }
                        }
                        else
                        { throw new ArgumentException("Porta informada inválida."); }
                    }
                    else
                    { throw new ArgumentNullException("Informe o host smtp que será usado para enviar a mensagem."); }
                }
                else
                { throw new ArgumentNullException("Informe a senha a ser usada para enviar a mensagem."); }
            }
            else
            { throw new ArgumentNullException("Informe o E-mail que será usado para enviar a mensagem."); }
        }

        /// <summary>
        /// Método usado para enviar um numero de confirmação de cadastro
        /// </summary>
        /// <param name="emailRemetente">Email de quem enviará a chave</param>
        /// <param name="emailDestinatario">Email de quem receberá a chave</param>
        /// <param name="senhaDestinatario">Senha do destinatario</param>
        /// <param name="hostSmtp">Servidor de emails com o qual deseja se conectar</param>
        /// <param name="porta">porta utilizada para enviar o email</param>
        /// <param name="chave">chave que deseja enviar</param>
        /// <param name="link">Link o qual o usuario clicar será redirecionado</param>
        /// <param name="nomeSistema">Nome do sistema desenvolvido</param>
        /// <by>Marcio Mansur - marciorabelom@gmail.com</by>
        public void enviarEmailConfirmacao(string emailRemetente, string emailDestinatario, string senhaDestinatario, string hostSmtp, int porta, string chave, string link, string nomeSistema)
        {

            MailMessage mail = new MailMessage(emailDestinatario, emailRemetente);
            mail.IsBodyHtml = true;
            mail.Body = messageEmail(chave, link, nomeSistema);
            mail.Subject = "Confirmação de cadastro - " + nomeSistema;

            SmtpClient smtp = new SmtpClient(hostSmtp.Trim(), porta);
            smtp.Credentials = new NetworkCredential(emailDestinatario, senhaDestinatario);
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }

        /// <summary>
        /// Método private que cria a mensagem de email de confirmação
        /// </summary>
        /// <param name="randomNumber">Numero aleatório para ativação</param>
        /// <param name="link">link para voltar a pagina</param>
        /// <returns>Mensagem de Email</returns>
        /// <by>Marcio Mansur - marciorabelom@hotmail.com</by>
        private string messageEmail(string randomNumber, string link, string nome)
        {
            StringBuilder text = new StringBuilder();

            text.AppendFormat("Obrigado por se cadastrar no {0}./r/n", nome);
            text.AppendLine("<br />");
            text.AppendFormat("Chave de ativação: {0}", randomNumber);
            text.AppendLine("<br />");
            text.AppendLine("Copie o código acima e cole no espaço do site abaixo.");
            text.AppendLine("<br />");
            text.AppendFormat("{0}", link);
            text.AppendLine("<br />");
            text.AppendLine("Agradecemos a compreensão.");
            text.Append(link);

            return text.ToString();
        }
    }
}