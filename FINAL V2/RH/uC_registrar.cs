using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINAL_V2.RH
{
    public partial class uC_registrar : UserControl
    {

        string caminhoFotos = @"C:\FOTOS";

        private string caminhoDaFoto = ""; // Variável para armazenar o caminho da foto

        private string connectionString = "Data Source=26.170.34.113;Initial Catalog=SistemaYiG;User ID=sa;Password=123";


        public uC_registrar()
        {
            InitializeComponent();
        }

        private void btnCadFun_Click_1(object sender, EventArgs e)
        {
            string nome = textBox1.Text;
            string idade = textBox2.Text;
            string cargo = textBox3.Text;
            string telefone = maskedTextBox1.Text;
            string email = textBox5.Text;
            string endereco = textBox6.Text;
            string rg = maskedTextBox2.Text;
            string cpf = maskedTextBox3.Text;
            string ctps = maskedTextBox4.Text;
            string salario = maskedTextBox5.Text;
            string conta = textBox4.Text;

            // Verifique se o caminho da foto está vazio (ou seja, nenhuma foto foi selecionada)
            if (string.IsNullOrEmpty(caminhoDaFoto))
            {
                // Verifique se há campos de texto em branco
                if (string.IsNullOrEmpty(nome) ||
                    string.IsNullOrEmpty(idade) ||
                    string.IsNullOrEmpty(cargo) ||
                    string.IsNullOrEmpty(telefone) ||
                    string.IsNullOrEmpty(email) ||
                    string.IsNullOrEmpty(endereco) ||
                    string.IsNullOrEmpty(rg) ||
                    string.IsNullOrEmpty(cpf) ||
                    string.IsNullOrEmpty(ctps) ||
                    string.IsNullOrEmpty(salario) ||
                    string.IsNullOrEmpty(conta))
                {
                    MessageBox.Show("Não foi selecionada uma foto e há campos em branco. Preencha todos os campos e selecione uma foto antes de cadastrar.");
                }
                else
                {
                    MessageBox.Show("Não foi selecionada uma foto. Selecione uma foto antes de cadastrar.");
                }
                return;
            }

            // Condição para evitar inserção de dados em branco
            if (string.IsNullOrEmpty(nome) ||
                string.IsNullOrEmpty(idade) ||
                string.IsNullOrEmpty(cargo) ||
                string.IsNullOrEmpty(telefone) ||
                string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(endereco) ||
                string.IsNullOrEmpty(rg) ||
                string.IsNullOrEmpty(cpf) ||
                string.IsNullOrEmpty(ctps) ||
                string.IsNullOrEmpty(salario) ||
                string.IsNullOrEmpty(conta))
            {
                MessageBox.Show("Há campos em branco. Preencha todos os campos antes de inserir os dados.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Cria uma instrução SQL para inserir os dados na tabela
                    string query = "INSERT INTO funcionariosrh (nome, idade, cargo, telefone, email, endereco, rg, cpf, ctps, salario, conta, caminho_fotos) VALUES (@Nome, @Idade, @Cargo, @Telefone, @Email, @Endereco, @Rg, @Cpf, @Ctps, @Salario, @Conta, @Caminho_Fotos)";
                    SqlCommand command = new SqlCommand(query, connection);

                    // Define os parâmetros para a instrução SQL
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Idade", idade);
                    command.Parameters.AddWithValue("@Cargo", cargo);
                    command.Parameters.AddWithValue("@Telefone", telefone);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Endereco", endereco);
                    command.Parameters.AddWithValue("@Rg", rg);
                    command.Parameters.AddWithValue("@Cpf", cpf);
                    command.Parameters.AddWithValue("@Ctps", ctps);
                    command.Parameters.AddWithValue("@Salario", salario);
                    command.Parameters.AddWithValue("@Conta", conta);

                    // Associe o caminho da foto aos parâmetros
                    command.Parameters.AddWithValue("@Caminho_Fotos", caminhoDaFoto);

                    // Executa a instrução SQL
                    command.ExecuteNonQuery();

                    // Salvar a imagem na pasta "C:\Users\Micro\Documents\fotosfun"
                    string nomeArquivo = Path.GetFileName(caminhoDaFoto);
                    string diretorioDeDestino = @"C:\FOTOS";

                    if (!Directory.Exists(diretorioDeDestino))
                    {
                        Directory.CreateDirectory(diretorioDeDestino);
                    }

                    string caminhoDeDestino = Path.Combine(diretorioDeDestino, nomeArquivo);

                    // Verifique se o arquivo de destino já existe e gere um nome exclusivo, se necessário.
                    if (File.Exists(caminhoDeDestino))
                    {
                        string nomeBase = Path.GetFileNameWithoutExtension(nomeArquivo);
                        string extensao = Path.GetExtension(nomeArquivo);
                        int contador = 1;

                        while (File.Exists(caminhoDeDestino))
                        {
                            nomeArquivo = nomeBase + "_" + contador + extensao;
                            caminhoDeDestino = Path.Combine(diretorioDeDestino, nomeArquivo);
                            contador++;
                        }
                    }

                    // Copie o arquivo selecionado para o diretório de destino
                    File.Copy(caminhoDaFoto, caminhoDeDestino);

                    // Limpa as TextBoxes após a inserção
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    maskedTextBox1.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    maskedTextBox2.Clear();
                    maskedTextBox3.Clear();
                    maskedTextBox4.Clear();
                    maskedTextBox5.Clear();
                    textBox4.Clear();

                    // Exibe uma mensagem de sucesso
                    MessageBox.Show("Dados inseridos com sucesso!");

                    //Limpa o caminho da foto após a inserção
                    caminhoDaFoto = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro: " + ex.Message);
                }
            }
        }

        
        private void btnFotoFun_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Selecione uma foto do funcionário";
            openFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // O usuário selecionou um arquivo, você pode obter o caminho do arquivo selecionado.
                caminhoDaFoto = openFileDialog.FileName;

                MessageBox.Show("A foto foi selecionada com sucesso!");
            }
        }

    }
}
