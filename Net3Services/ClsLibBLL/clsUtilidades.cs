using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.UI.WebControls;
using MongoDB;

namespace ClsLibBLL
{
    public static class clsUtilidades
    {
        /// <summary>
        /// Formata a data de publicação para apresentar uma texto mais amigavel ao usuário
        /// </summary>
        /// <param name="date">Data que se deseja obter o nome do dia da semana</param>
        /// <returns>Data de publicação formatada</returns>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        public static string FormatarDataPublicacao(DateTime date)
        {
            string retorno = "";

            if (date.Date == DateTime.Now.Date)
                retorno = date.ToString("HH:mm");
            else if (date.Year == DateTime.Now.Year)
                retorno = string.Format("{0} de {1} de às {2}", date.Day, clsUtilidades.GetNomeMes(date), date.ToString("HH:mm"));
            else if (date.AddDays(7 - (int)date.DayOfWeek).Date == DateTime.Now.AddDays(7 - (int)DateTime.Now.DayOfWeek).Date)
                retorno = string.Format("{0} às {1}", clsUtilidades.GetNomeDiaDaSemana(date), date.ToString("HH:mm"));
            else
                retorno = string.Format("{0} às {1}", date.ToString("dd/MM/yyyy"), date.ToString("HH:mm"));

            return retorno;
        }

        /// <summary>
        /// Formata mensagem, dando um 'Truncate' no texto de acordo com o tamanho informado
        /// </summary>
        /// <param name="msg">Mensagem que deve ser formatada</param>
        /// <param name="tamanho">Número de caracteres que devem ser exibidos</param>
        /// <param name="mostrarPontos">Caso verdadeiro adiciona três pontos no final do texto, do contrário não adiciona nada</param>
        /// <returns>Data de publicação formatada</returns>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        public static string FormatarMensagem(string msg, Int16 tamanho, bool mostrarPontos = true)
        {
            string retorno = "";
            string pontos = mostrarPontos == true ? "..." : ""; 

            if (msg.Trim().Length >= tamanho)
                retorno = msg.Trim().Substring(0, tamanho) + pontos;
            else
                retorno = msg.Trim();

            return retorno;
        }

        /// <summary>
        /// Informa o nome do dia da semana contido na data informada
        /// </summary>
        /// <param name="myData">Data que se deseja obter o nome do dia da semana</param>
        /// <returns>Nome do dia da semana da data informada</returns>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        public static string GetNomeDiaDaSemana(this DateTime myData)
        {
            string diaDaSemana = "";

            switch(myData.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    diaDaSemana = "Segunda-Feira";
                    break;

                case DayOfWeek.Tuesday:
                    diaDaSemana = "Terça-Feira";
                    break;

                case DayOfWeek.Wednesday:
                    diaDaSemana = "Quarta-Feira";
                    break;

                case DayOfWeek.Thursday:
                    diaDaSemana = "Quinta-Feira";
                    break;

                case DayOfWeek.Friday:
                    diaDaSemana = "Sexta-Feira";
                    break;

                case DayOfWeek.Saturday:
                    diaDaSemana = "Sábado";
                    break;

                case DayOfWeek.Sunday:
                    diaDaSemana = "Domingo";
                    break;
            }

            return diaDaSemana;
        }

        /// <summary>
        /// Informa o nome do mês contido na data informada
        /// </summary>
        /// <param name="myData">Data que se deseja obter o nome do mês</param>
        /// <returns>Nome do mês da data informada</returns>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        public static string GetNomeMes(this DateTime myData)
        {
            string mes = string.Empty;

            switch (myData.Month)
            {
                case 1:
                    mes = "Janeiro";
                    break;

                case 2:
                    mes = "Fevereiro";
                    break;

                case 3:
                    mes = "Março";
                    break;

                case 4:
                    mes = "Abril";
                    break;

                case 5:
                    mes = "Maio";
                    break;

                case 6:
                    mes = "Junho";
                    break;

                case 7:
                    mes = "Julho";
                    break;

                case 8:
                    mes = "Agosto";
                    break;

                case 9:
                    mes = "Setembro";
                    break;

                case 10:
                    mes = "Outubro";
                    break;

                case 11:
                    mes = "Novembro";
                    break;

                case 12:
                    mes = "Dezembro";
                    break;
            }

            return mes;
        }

        /// <summary>
        /// Transforma o Object ID em string, para passar na URL
        /// </summary>
        /// <param name="oid">OID do usuário</param>
        /// <returns>Oid em string</returns>
        public static string OidToString(byte[] oid)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < oid.Length; i++)
            {
                if (i == 0)
                {
                    int b = oid[0] % 40;
                    int a = (oid[0] - b) / 40;
                    builder.AppendFormat("{0}.{1}", a, b);
                }
                else
                {
                    if (oid[i] < 128)
                        builder.AppendFormat(".{0}", oid[i]);
                    else
                    {
                        builder.AppendFormat(".{0}", ((oid[i] - 128) * 128) + oid[i + 1]);
                        i++;
                    }
                }
            }

            return builder.ToString();
        }

        /// <summary>
        /// Buscar arquivos aleatoriamente na pasta de propagandas
        /// </summary>
        /// <param name="caminhoPasta">Pasta em que se deve colocar os arquivos</param>
        /// <returns>Caminho da imagem que deve ser selecionada.</returns>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        public static string GetArquivosAleatorios(string caminhoPasta)
        {
            ArrayList arArquivos = new ArrayList();
            DirectoryInfo diretorio = new DirectoryInfo(caminhoPasta);
            FileInfo[] arquivos = diretorio.GetFiles("*.*");

            foreach (FileInfo fi in arquivos)
            {
                arArquivos.Add(fi.FullName);
            }

            Random r = new Random();
            int x = r.Next(0, arArquivos.Count);

            return arArquivos[x].ToString();
        }

        public static void CampoErrado(TextBox txt, string menssagem)
        {
            txt.ToolTip = menssagem;
            txt.BorderColor = Color.IndianRed;
        }

        public static void CampoCorreto(TextBox txt, Color cor)
        {
            txt.ToolTip = string.Empty;
            txt.BorderColor = cor;
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
        public static void enviarEmailConfirmacao(string emailRemetente, string emailDestinatario, string senhaDestinatario, string hostSmtp, int porta, string chave, string link, string nomeSistema)
        {
            MailMessage mail = new MailMessage(emailDestinatario, emailRemetente);
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
        /// <by>Marcio Mansur - marciroabelom@hotmail.com</by>
        private static string messageEmail(string randomNumber, string link, string nome)
        {
            StringBuilder text = new StringBuilder();

            text.AppendFormat("Obrigado por se cadastrar no {0}./r/n", nome);
            text.AppendLine("/r/n");
            text.AppendFormat("Chave de ativação: {0}", randomNumber);
            text.AppendLine("/r/n");
            text.Append("Entre no Link abaixo para completar seu cadastro./r/n");
            text.AppendLine("/r/n");
            text.Append(link);

            return text.ToString();

        }

        /// <summary>
        /// Este método tem a função de validar Oids do MongoDB.
        /// </summary>
        /// <param name="id">Oid a ser validado.</param>
        /// <returns>Retorna um valor booleano, sendo true se o Oid for válido e false se inválido.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public static bool ValidarOid(Oid id)
        {
            return ValidarOid(id.ToString());
        }

        /// <summary>
        /// Este método tem a função de validar Oids do MongoDB.
        /// </summary>
        /// <param name="id">Oid a ser validado.</param>
        /// <returns>Retorna um valor booleano, sendo true se o Oid for válido e false se inválido.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public static bool ValidarOid(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                if (id.Replace(@"\", "").Replace("/", "").Replace("\"", "").Length == 24)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            { return false; }
        }
    }
}