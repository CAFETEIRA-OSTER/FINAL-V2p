using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINAL_V2
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
            Application.AddMessageFilter(new MyKeyHandler());
        }

        public class MyKeyHandler : IMessageFilter
        {
            public bool PreFilterMessage(ref Message m)
            {
                if (m.Msg == 0x0100) // WM_KEYDOWN
                {
                    Keys key = (Keys)m.WParam.ToInt32();

                    if (key == Keys.F1)
                    {
                        MessageBox.Show("Você pressionou a tecla F1 em qualquer lugar do aplicativo.");
                    }
                }
                return false; // Permitir que a mensagem seja processada normalmente
            }
        }
    }
}
