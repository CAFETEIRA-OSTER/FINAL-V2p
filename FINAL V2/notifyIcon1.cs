using System;
using System.Drawing; // Importe este namespace para usar a classe Icon
using System.Windows.Forms;

namespace FINAL_V2
{
    internal class MeuNotifyIcon
    {

        private NotifyIcon notifyIcon1;

        public MeuNotifyIcon()
        {
            notifyIcon1 = new NotifyIcon();
            notifyIcon1.Icon = new Icon("C:\\ico\\ico.ico");
            notifyIcon1.Visible = true;
            notifyIcon1.DoubleClick += new EventHandler(notifyIcon1_DoubleClick);
        }

        private void notifyIcon1_DoubleClick(object Sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            form.Show();
        }

    }
}
