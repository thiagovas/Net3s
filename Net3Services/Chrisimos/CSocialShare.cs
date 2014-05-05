using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chrisimos
{
    class CSocialShare
    {

       // <a class="twitter" href="javascript:openPopup('http://twitter.com/home/?status=Material+e+apostilas+para+concurso+do+MPU+-+Minist%C3%A9rio+P%C3%BAblico+da+Uni%C3%A3o+-+Analista+Contabilidade.+Curso+preparat%C3%B3rio. http://www.educacaocoletiva.com.br/oferta/2150/material-e-apostilas-para-concurso-do-mpu-ministerio-publico-da-uniao-analista-contabilidade-curso-preparatorio/');" title="Twitter"><img src="/themes/educacaocoletiva/assets/images/iconTwitter.png"></a>

    	public static string GooglePlusLink(string strLink)
		{
            string strGPlusLink = string.Format("https://plus.google.com/share?url={0}", strLink);
			return strGPlusLink;
		}

        public static string FacebookLink(string strLink)
		{
            string strFbLink = string.Format("http://www.facebook.com/share.php?u={0}", strLink);
			return strFbLink;
		}


    }
}
