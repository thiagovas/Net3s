using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ClsLibBLL;
using MongoDB;
using Models;

namespace UI.User
{
    public partial class ConfigFoto : System.Web.UI.Page
    {
        protected string nomeFoto { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}