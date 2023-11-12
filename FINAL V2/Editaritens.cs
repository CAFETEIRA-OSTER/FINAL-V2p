using FINAL_V2.UsuaryControl;
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

namespace FINAL_V2
{
    public partial class Editaritens : Form
    {

        private Cadastrar formCadastrar;
        private int idSelecionado;

        public Editaritens(Cadastrar formCadastrar, int idSelecionado)
        {
            InitializeComponent();
            this.formCadastrar = formCadastrar;
            this.idSelecionado = idSelecionado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obter os valores dos controles
            string nome = txtNome.Text.Trim();
            string quantidadeText = txtQuantidade.Text.Trim();
            string precoText = txtPreco.Text.Trim();
            string tipo = cmbTipo.Text.Trim();
            string lucroText = txtLucro.Text.Trim();
            string secao = cmbSecao.Text.Trim();

            // Verificar se algum campo obrigatório está vazio
            if (string.IsNullOrEmpty(nome) ||
                string.IsNullOrEmpty(quantidadeText) ||
                string.IsNullOrEmpty(precoText) ||
                string.IsNullOrEmpty(tipo) ||
                string.IsNullOrEmpty(lucroText) ||
                string.IsNullOrEmpty(secao))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.", "Campo(s) Vazio(s)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tentar converter os valores para os tipos apropriados
            if (!int.TryParse(quantidadeText, out int quantidade) ||
                !decimal.TryParse(precoText, out decimal preco) ||
                !decimal.TryParse(lucroText, out decimal lucro))
            {
                MessageBox.Show("Certifique-se de inserir valores numéricos válidos nos campos 'Quantidade', 'Preço' e 'Lucro'.", "Valor Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Conectar ao banco de dados
            string connectionString = "Data Source=26.170.34.113;Initial Catalog=SistemaYiG;User ID=sa;Password=123";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Atualizar os dados na tabela "Estoque" com base no ID selecionado
                    string query = "UPDATE Estoque SET Nome = @Nome, Quantidade = @Quantidade, Preço = @Preco, Tipo = @Tipo, Lucro = @Lucro, Seção = @Secao WHERE lid = @idSelecionado";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Adicionar parâmetros
                        command.Parameters.AddWithValue("@Nome", nome);
                        command.Parameters.AddWithValue("@Quantidade", quantidade);
                        command.Parameters.AddWithValue("@Preco", preco);
                        command.Parameters.AddWithValue("@Tipo", tipo);
                        command.Parameters.AddWithValue("@Lucro", lucro);
                        command.Parameters.AddWithValue("@Secao", secao);
                        command.Parameters.AddWithValue("@idSelecionado", idSelecionado);

                        // Executar a instrução SQL
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Dados atualizados com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Nenhum dado foi atualizado. Verifique se o ID selecionado é válido.", "Atualização sem Êxito", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao acessar o banco de dados: " + ex.ToString());
                }
            }
        }


        private void Editaritens_Load(object sender, EventArgs e)
        {
            // Conectar ao banco de dados
            string connectionString = "Data Source=26.170.34.113;Initial Catalog=SistemaYiG;User ID=sa;Password=123";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Consulta SQL para obter as informações do ID selecionado
                    string query = "SELECT Nome, Quantidade, Preço, Tipo, Lucro, Seção FROM Estoque WHERE lid = @idSelecionado";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Adicionar parâmetros
                        command.Parameters.AddWithValue("@idSelecionado", idSelecionado);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Preencher os campos do formulário com os valores do banco de dados
                                txtNome.Text = reader["Nome"].ToString();
                                txtQuantidade.Text = reader["Quantidade"].ToString();
                                txtPreco.Text = reader["Preço"].ToString();
                                cmbTipo.Text = reader["Tipo"].ToString();
                                txtLucro.Text = reader["Lucro"].ToString();
                                cmbSecao.Text = reader["Seção"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Nenhuma informação encontrada para o ID selecionado.", "ID Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.Close(); // Fecha o formulário se não houver informações encontradas
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao acessar o banco de dados: " + ex.ToString());
                }
            }
        }

    }
}
