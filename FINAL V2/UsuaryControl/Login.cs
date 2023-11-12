using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FINAL_V2.UsuaryControl
{
    public partial class Login : UserControl
    {
        // Variável pública para armazenar o nível de acesso
        public int NivelAcesso { get; private set; }

        // Variável pública para armazenar o nome do usuário
        public string NomeUsuario { get; private set; }

        public Login()
        {
            InitializeComponent();
        }

        // Manipulador de eventos para o clique no botão de login
        private void button1_Click_1(object sender, EventArgs e)
        {
            // String de conexão com o banco de dados
            string connectionString = "Data Source=26.170.34.113;Initial Catalog=SistemaYiG;User ID=sa;Password=123";

            // Usando a declaração para garantir que os recursos são liberados após o uso
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Obtém o nome de usuário e senha inseridos nos campos de texto
                    string username = textBox1.Text;
                    string password = textBox2.Text;

                    // Consulta SQL para verificar se existe um registro com o mesmo username e password
                    string query = "SELECT COUNT(*) FROM cadastro WHERE Username = @Username AND Password = @Password";

                    // Usando a declaração para garantir que os recursos são liberados após o uso
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Adiciona parâmetros à consulta SQL
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        // Executa a consulta e obtém o número de registros correspondentes
                        int count = (int)command.ExecuteScalar();

                        // Verifica se o login é bem-sucedido
                        if (count > 0)
                        {
                            // Consulta SQL para obter o nível de acesso e o nome do usuário
                            string acessoQuery = "SELECT Acesso, Username FROM cadastro WHERE Username = @Username";

                            // Usando a declaração para garantir que os recursos são liberados após o uso
                            using (SqlCommand acessoCommand = new SqlCommand(acessoQuery, connection))
                            {
                                acessoCommand.Parameters.AddWithValue("@Username", username);

                                // Cria um leitor de dados para ler os resultados da consulta
                                using (SqlDataReader reader = acessoCommand.ExecuteReader())
                                {
                                    // Verifica se há linhas retornadas
                                    if (reader.HasRows)
                                    {
                                        // Lê a primeira linha (deveria haver apenas uma)
                                        reader.Read();

                                        // Obtém o valor do nível de acesso
                                        object acessoResult = reader["Acesso"];

                                        // Obtém o valor do nome do usuário
                                        object nomeResult = reader["Username"];

                                        // Verifica se os valores são válidos e os converte para int e string, respectivamente
                                        if (acessoResult != null && nomeResult != null && int.TryParse(acessoResult.ToString(), out int nivelAcesso))
                                        {
                                            // Armazena o nível de acesso e o nome nas variáveis públicas
                                            NivelAcesso = nivelAcesso;
                                            NomeUsuario = nomeResult.ToString();

                                            // Exibe uma mensagem com o nível de acesso e o nome (pode ser substituído por outra lógica)
                                            MessageBox.Show($"Login bem-sucedido! Nível de acesso: {NivelAcesso}, Nome: {NomeUsuario}");

                                            // Oculta o controle de usuário "Login"
                                            this.Hide();

                                            // Abre o formulário principal (SistemaForm) passando a instância do Login
                                            SistemaForm form1 = new SistemaForm(this);
                                            form1.Show();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Nível de acesso ou nome inválido.");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Login ou senha inválido");
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Login ou senha inválido");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao conectar-se ao banco de dados: " + ex.Message);
                }
            }
        }

        // Manipulador de eventos para o clique no link de cadastro
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Torna o controle de usuário "Login" invisível
            this.Visible = false;

            // Cria uma instância do controle de usuário "Cadastro"
            Cadastro cadastroControl = new Cadastro();

            // Define o controle de usuário "Cadastro" para preencher o espaço disponível
            cadastroControl.Dock = DockStyle.Fill;

            // Adiciona o controle de usuário "Cadastro" ao mesmo contêiner que o controle de usuário "Login"
            this.Parent.Controls.Add(cadastroControl);

            // Coloca o controle de usuário "Cadastro" na frente (acima) do controle de usuário "Login"
            cadastroControl.BringToFront();
        }

        // Manipulador de eventos para o clique no botão de fechar
        private void button2_Click_1(object sender, EventArgs e)
        {
            // Certifica-se de que você tem uma referência válida para o formulário "LoginForm"
            LoginForm loginForm = this.ParentForm as LoginForm;

            if (loginForm != null)
            {
                // Fecha o formulário "LoginForm"
                loginForm.Close();
            }
        }
    }
}
