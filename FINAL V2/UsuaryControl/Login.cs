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
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }




        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            // Substitua "YourConnectionString" pela sua string de conexão
            string connectionString = "Data Source=26.170.34.113;Initial Catalog=SistemaYiG;User ID=sa;Password=123";

            int acesso = 0; // Variável para armazenar o nível de acesso

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string username = textBox1.Text;
                    string password = textBox2.Text;

                    // Consulta SQL para verificar se existe um registro com o mesmo username e password
                    string query = "SELECT COUNT(*) FROM cadastro WHERE Username = @Username AND Password = @Password";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        // Consulta SQL para obter o nível de acesso do usuário
                        string acessoQuery = "SELECT Acesso FROM cadastro WHERE Username = @Username";
                        SqlCommand acessoCommand = new SqlCommand(acessoQuery, connection);
                        acessoCommand.Parameters.AddWithValue("@Username", username);

                        // Obter o valor do nível de acesso
                        object acessoResult = acessoCommand.ExecuteScalar();


                        if (acessoResult != null && acessoResult != DBNull.Value)
                        {
                            if (int.TryParse(acessoResult.ToString(), out acesso))
                            {


                                // Ocultar o Form1
                                this.Hide();

                                // Abrir o Form2
                                if (acesso == 1)
                                {
                                    Form parentForm = this.ParentForm;
                                    if (parentForm != null)
                                    {
                                        parentForm.Hide();
                                    }

                                    // Abrir o "Form1"
                                    SistemaForm form1 = new SistemaForm();
                                    form1.Show();
                                }
                                if (acesso == 2)
                                {

                                }
                                if (acesso == 3)
                                {

                                }



                            }
                            else
                            {
                                MessageBox.Show("Erro ao converter nível de acesso.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nível de acesso não encontrado.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Login ou senha inválido");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao conectar-se ao banco de dados: " + ex.Message);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Torna o controle de usuário "Login" invisível
            this.Visible = false;

            // Cria uma instância do controle de usuário "Cadastro"
            Cadastro cadastroControl = new Cadastro();

            // Definir o controle de usuário "Cadastro" para preencher o espaço disponível
            cadastroControl.Dock = DockStyle.Fill;

            // Adicionar o controle de usuário "Cadastro" ao mesmo contêiner que o controle de usuário "Login"
            this.Parent.Controls.Add(cadastroControl);

            // Colocar o controle de usuário "Cadastro" na frente (acima) do controle de usuário "Login"
            cadastroControl.BringToFront();
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
