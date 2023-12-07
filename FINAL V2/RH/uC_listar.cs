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
using System.IO;



namespace FINAL_V2.RH
{
    public partial class uC_listar : UserControl
    {

        public string nomeSelecionado;
        public PictureBox PictureBoxFuncionario => pictureBox2;

        public string NomeSelecionado { get; set; }

        public uC_listar()
        {
            InitializeComponent();
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            CarregarNomesFuncionarios();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            NomeSelecionado = comboBox1.SelectedItem?.ToString();
            CarregarInformacoesFuncionario();
        }

        public void atualizarLabels(string nome, string idade, string cargo, string telefone, string email, string endereco, string rg, string cpf, string ctps, string salario, string conta)
        {
            // Atualiza os labels com os valores do banco de dados
            textBox2.Text = nome;
            lblIdade.Text = idade;
            lblCargo.Text = cargo;
            lblTelefone.Text = telefone;
            lblEmail.Text = email;
            textBox1.Text = endereco;
            lblRg.Text = rg;
            lblCpf.Text = cpf;
            lblCtps.Text = ctps;
            lblSalario.Text = salario;
            lblConta.Text = conta;
        }

        private void CarregarNomesFuncionarios()
        {
            try
            {
                string connectionString = "Data Source=26.170.34.113;Initial Catalog=SistemaYiG;User ID=sa;Password=123";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT nome FROM funcionariosrh";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nomeFuncionario = reader["nome"].ToString();
                                comboBox1.Items.Add(nomeFuncionario);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao obter nomes dos funcionários: {ex.Message}");
            }
        }

        public void CarregarInformacoesFuncionario()
        {
            if (!string.IsNullOrEmpty(NomeSelecionado))
            {
                try
                {
                    string connectionString = "Data Source=26.170.34.113;Initial Catalog=SistemaYiG;User ID=sa;Password=123";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "SELECT nome, idade, cargo, telefone, email, endereco, rg, cpf, ctps, salario, conta, caminho_fotos FROM funcionariosrh WHERE nome = @Nome";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Nome", NomeSelecionado);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Atribua os valores aos campos apropriados, incluindo o caminho da imagem
                                string nome = reader["nome"].ToString();
                                string idade = reader["idade"].ToString();
                                string cargo = reader["cargo"].ToString();
                                string telefone = reader["telefone"].ToString();
                                string email = reader["email"].ToString();
                                string endereco = reader["endereco"].ToString();
                                string rg = reader["rg"].ToString();
                                string cpf = reader["cpf"].ToString();
                                string ctps = reader["ctps"].ToString();
                                string salario = reader["salario"].ToString();
                                string conta = reader["conta"].ToString();
                                string caminhoDaImagem = reader["caminho_fotos"].ToString();

                                // Atualize os labels
                                textBox2.Text = nome;
                                lblIdade.Text = idade;
                                lblCargo.Text = cargo;
                                lblTelefone.Text = telefone;
                                lblEmail.Text = email;
                                textBox1.Text = endereco;
                                lblRg.Text = rg;
                                lblCpf.Text = cpf;
                                lblCtps.Text = ctps;
                                lblSalario.Text = salario;
                                lblConta.Text = conta;

                                // Carregue a imagem
                                CarregarImagem(caminhoDaImagem);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao buscar informações do usuário: {ex.Message}");
                }
            }
        }

        private void CarregarImagem(string caminhoDaImagem)
        {
            // Caminho da pasta onde as fotos estão salvas.
            string pastaFotos = @"C:\Users\Micro\Documents\fotosfun\";

            // Construa o caminho completo da foto.
            string caminhoCompletoDaImagem = Path.Combine(pastaFotos, caminhoDaImagem);

            // Verifique se o arquivo de imagem existe.
            if (File.Exists(caminhoCompletoDaImagem))
            {
                // Carrega a imagem no PictureBox.
                pictureBox2.Image = Image.FromFile(caminhoCompletoDaImagem);
            }
            else
            {
                MessageBox.Show("Erro ao tentar exibir foto do funcionário!");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTelefone_Click(object sender, EventArgs e)
        {

        }

        private void lblRg_Click(object sender, EventArgs e)
        {

        }

        private void lblEndereco_Click(object sender, EventArgs e)
        {

        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Verifica se um item está selecionado na ComboBox
            if (comboBox1.SelectedItem != null)
            {
                nomeSelecionado = comboBox1.SelectedItem.ToString();

                DialogResult resultado = MessageBox.Show(
                    "Tem certeza que deseja remover " + nomeSelecionado + " do sistema?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                // Verifica a resposta do usuário
                if (resultado == DialogResult.Yes)
                {
                    // Conexão com o banco de dados para buscar os detalhes do usuário
                    string connectionString = "Data Source=26.170.34.113;Initial Catalog=SistemaYiG;User ID=sa;Password=123";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        // Apagar do BD
                        try
                        {
                            connection.Open();

                            // Consulta SQL para excluir o registro com base no nome
                            string queryDelete = "DELETE FROM funcionariosrh WHERE nome = @Nome";
                            SqlCommand commandDelete = new SqlCommand(queryDelete, connection);
                            commandDelete.Parameters.AddWithValue("@Nome", nomeSelecionado);

                            int rowsAffected = commandDelete.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show(nomeSelecionado + " foi removido com sucesso!");

                                // Atualize a ComboBox para refletir a remoção
                                CarregarNomesFuncionarios();
                            }
                            else
                            {
                                MessageBox.Show("Nenhum registro foi removido.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao remover o registro: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Remoção cancelada!");
                }
            }
            else
            {
                MessageBox.Show("Não há nenhum nome selecionado!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
