namespace Chrisimos
{
    public class Ccontrol
    {
        public static void LimparTextBoxes(System.Windows.Forms.Control.ControlCollection ctrl)
        {
            if (ctrl.Equals(null))
                return;

            foreach (System.Windows.Forms.Control item in ctrl)
            {
                if (item is System.Windows.Forms.TextBox)
                    ((System.Windows.Forms.TextBox)item).Clear();
                LimparTextBoxes(item.Controls);
            }
        }

        public static void LimparTextBoxes(System.Windows.Forms.Control ctrl)
        {
            if (ctrl.Equals(null))
                return;

            foreach (System.Windows.Forms.Control item in ctrl.Controls)
            {
                if (item is System.Windows.Forms.TextBox)
                    ((System.Windows.Forms.TextBox)item).Clear();
                LimparTextBoxes(item.Controls);
            }
        }
    }
}
