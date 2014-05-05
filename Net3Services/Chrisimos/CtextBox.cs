using System.Windows.Forms;
using System.Web.UI;

namespace Chrisimos
{
    public class CtextBox : Ccontrol
    {
        /// <summary>
        /// Limpa todos os textboxes de um ControlCollection.
        /// </summary>
        /// <param name="textBoxes">Objeto do tipo ControlCollection com os textBoxes a serem limpados.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void LimparTextBoxes(System.Windows.Forms.Control.ControlCollection textBoxes)
        {
            foreach (System.Windows.Forms.Control ctrl in textBoxes)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Clear();
                LimparTextBoxes(ctrl.Controls);
            }
        }

        /// <summary>
        /// Limpa todos os textboxes de um ControlCollection.
        /// </summary>
        /// <param name="textBoxes">Objeto do tipo ControlCollection com os textBoxes a serem limpados.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void LimparTextBoxes(System.Web.UI.ControlCollection textBoxes)
        {
            foreach (System.Web.UI.Control ctrl in textBoxes)
            {
                if (ctrl is System.Web.UI.WebControls.TextBox)
                    ((System.Web.UI.WebControls.TextBox)ctrl).Text = string.Empty;
                LimparTextBoxes(ctrl.Controls);
            }
        }
    }
}
