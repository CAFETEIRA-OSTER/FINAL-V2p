using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINAL_V2.UsuaryControl
{
    public partial class Cadastro : UserControl
    {
        public Cadastro()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)// Cadastro de usuário
        {

            string Username = textBox1.Text;
            string Password = textBox2.Text;
            string Acesso = textBox3.Text;
            string pin = textBox4.Text;

            if (pin == "0000")
            {

                string connectionString = "Data Source = 26.170.34.113; Initial Catalog = SistemaYiG; User ID = sa; Password = 123";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string query = "INSERT INTO cadastro (Username, Password, Acesso) " +
                                       "VALUES (@Username, @Password, @Acesso)";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@Acesso", Acesso);


                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Valores adicionados com sucesso!");

                        }
                        else
                        {
                            MessageBox.Show("Falha ao adicionar valores.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao conectar-se ao banco de dados: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Insira um código de adiministrador válido");
            }
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Torna o controle de usuário "Login" invisível
            this.Visible = false;

            // Cria uma instância do controle de usuário "Cadastro"
            Login loginControl = new Login();

            // Definir o controle de usuário "Cadastro" para preencher o espaço disponível
            loginControl.Dock = DockStyle.Fill;

            // Adicionar o controle de usuário "Cadastro" ao mesmo contêiner que o controle de usuário "Login"
            this.Parent.Controls.Add(loginControl);

            // Colocar o controle de usuário "Cadastro" na frente (acima) do controle de usuário "Login"
            loginControl.BringToFront();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Certifique-se de que você tem uma referência válida para o formulário "LoginForm"
            LoginForm loginForm = this.ParentForm as LoginForm;

            if (loginForm != null)
            {
                // Fecha o formulário "LoginForm"
                loginForm.Close();
            }
        }

        
    }
}