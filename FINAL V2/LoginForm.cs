using FINAL_V2.UsuaryControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINAL_V2
{
    public partial class LoginForm : Form
    {   
        public LoginForm()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyUp += new KeyEventHandler(LoginForm_KeyUp);
           


        }

        private void LoginForm_KeyUp(object sender, KeyEventArgs e)
        {
            // Verifica se a tecla F1 foi pressionada
            if (e.KeyCode == Keys.F2)
            {
                // Exibe a mensagem desejada
                MessageBox.Show("Você pressionou a tecla F1!");
            }// Lógica a ser executada quando uma tecla é liberada no formulário
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Criar uma instância do controle de usuário "Login"
            Login loginControl = new Login();

            // Definir o controle de usuário para preencher o formulário
            loginControl.Dock = DockStyle.Fill;

            // Adicionar o controle de usuário ao formulário
            this.Controls.Add(loginControl);
        }

    }
}
