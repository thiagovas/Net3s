using System;
using System.Configuration;
using System.Text;
using Chrisimos.Net;
using ClsLibBLL;

namespace UI
{
    public class Global : System.Web.HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            ClsUsuLogado.LimparPropriedades();
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
            ClsUsuLogado.LimparPropriedades();
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
            Exception ex = Server.GetLastError();
            StringBuilder msg = new StringBuilder();
            msg.Append(string.Format("Message: {0}<br /><br />", ex.Message));
            msg.Append(string.Format("StackTrace: {0}<br /><br />", ex.StackTrace));
            if (ex.Source != null)
                msg.Append(string.Format("Source: {0}<br /><br />", ex.Source));
            if (ex.InnerException != null)
                msg.Append(string.Format("InnerException.Message: {0}<br /><br />", ex.InnerException.Message));

            Email objEmail = new Email();

            objEmail.enviarEmail(ConfigurationManager.AppSettings["EMAILNET3S"], ConfigurationManager.AppSettings["SENHAEMAILNET3S"], "smtp.gmail.com", 587,
                ConfigurationManager.AppSettings["EMAILERROSNET3S"], "Ocorreu um erro no sistema", msg.ToString(), true, true);
        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
            //Session["USUARIO"] = null;
            ClsUsuLogado.LimparPropriedades();
        }

    }
}
