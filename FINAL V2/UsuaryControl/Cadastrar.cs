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
using static FINAL_V2.Vendas;

namespace FINAL_V2.UsuaryControl
{
    public partial class Cadastrar : UserControl
    {

        public int IDSelecionado { get; set; }
        public Cadastrar()
        {
            InitializeComponent();  
            // Adicione o manipulador de eventos ao evento KeyDown do TextBox
            textBox2.KeyDown += TextBox2_KeyDown;
            textBox1.KeyDown += TextBox1_KeyDown;

        }

        private void TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifique se a tecla pressionada é Enter
            if (e.KeyCode == Keys.Enter)
            {
                // Chame o método para exibir dados no DataGridView
                ExibirDadosNoDataGridView();
            }
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifique se a tecla pressionada é Enter
            if (e.KeyCode == Keys.Enter)
            {
                // Chame o método para exibir dados no DataGridView
                ExibirDadosNoDataGridViewID();
            }
        }
        private void ExibirDadosNoDataGridViewID()
        {
            // Conectar ao banco de dados
            string connectionString = "Data Source=26.170.34.113;Initial Catalog=SistemaYiG;User ID=sa;Password=123";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Obter o texto do TextBox para usar como critério de filtro
                    string filtroNome = textBox1.Text;

                    // Definir a consulta SQL para recuperar dados da tabela "estoque" com filtro
                    string query = "SELECT lid, Nome, Quantidade, Preço, Tipo, Lucro, Seção FROM Estoque WHERE lid LIKE @filtroNome";

                    // Criar um adaptador de dados e um conjunto de dados
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        // Adicionar o parâmetro para o filtro
                        adapter.SelectCommand.Parameters.AddWithValue("@filtroNome", "%" + filtroNome + "%");

                        DataTable dataTable = new DataTable();

                        // Preencher o conjunto de dados com os dados do adaptador
                        adapter.Fill(dataTable);

                        // Limpar as linhas existentes no DataGridView
                        dataGridView1.Rows.Clear();

                        // Adicionar as linhas ao DataGridView com base nos resultados da consulta
                        foreach (DataRow row in dataTable.Rows)
                        {
                            // Adiciona uma nova linha ao DataGridView com os valores do banco de dados
                            dataGridView1.Rows.Add(row.ItemArray);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao acessar o banco de dados: " + ex.ToString());
                }
            }
        }
        private void ExibirDadosNoDataGridView()
        {
            // Conectar ao banco de dados
            string connectionString = "Data Source=26.170.34.113;Initial Catalog=SistemaYiG;User ID=sa;Password=123";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Obter o texto do TextBox para usar como critério de filtro
                    string filtroNome = textBox2.Text;

                    // Definir a consulta SQL para recuperar dados da tabela "estoque" com filtro
                    string query = "SELECT lid, Nome, Quantidade, Preço, Tipo, Lucro, Seção FROM Estoque WHERE nome LIKE @filtroNome";

                    // Criar um adaptador de dados e um conjunto de dados
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        // Adicionar o parâmetro para o filtro
                        adapter.SelectCommand.Parameters.AddWithValue("@filtroNome", "%" + filtroNome + "%");

                        DataTable dataTable = new DataTable();

                        // Preencher o conjunto de dados com os dados do adaptador
                        adapter.Fill(dataTable);

                        // Limpar as linhas existentes no DataGridView
                        dataGridView1.Rows.Clear();

                        // Adicionar as linhas ao DataGridView com base nos resultados da consulta
                        foreach (DataRow row in dataTable.Rows)
                        {
                            // Adiciona uma nova linha ao DataGridView com os valores do banco de dados
                            dataGridView1.Rows.Add(row.ItemArray);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao acessar o banco de dados: " + ex.ToString());
                }
            }
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

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

                    // Inserir os dados na tabela "Estoque"
                    string query = "INSERT INTO Estoque (Nome, Quantidade, Preço, Tipo, Lucro, Seção) " +
                                   "VALUES (@Nome, @Quantidade, @Preco, @Tipo, @Lucro, @Secao)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Adicionar parâmetros
                        command.Parameters.AddWithValue("@Nome", nome);
                        command.Parameters.AddWithValue("@Quantidade", quantidade);
                        command.Parameters.AddWithValue("@Preco", preco);
                        command.Parameters.AddWithValue("@Tipo", tipo);
                        command.Parameters.AddWithValue("@Lucro", lucro);
                        command.Parameters.AddWithValue("@Secao", secao);

                        // Executar a instrução SQL
                        command.ExecuteNonQuery();

                        MessageBox.Show("Dados inseridos com sucesso!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao acessar o banco de dados: " + ex.ToString());
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            // Verifica se há pelo menos uma linha selecionada no DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtém o valor do ID da linha selecionada
                int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["lid"].Value);

                // Atribui o valor do ID à variável pública no formulário atual
                IDSelecionado = selectedId;
                ObterIDSelecionado();

                // Corrigir a chamada do construtor para incluir ambos os argumentos
                Editaritens removeritensForm = new Editaritens(this, IDSelecionado);
                removeritensForm.Show();
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma linha.", "Nenhuma Linha Selecionada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        public int ObterIDSelecionado()
        {
            return IDSelecionado;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Verifica se há pelo menos uma linha selecionada no DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Exibe uma mensagem de confirmação
                DialogResult result = MessageBox.Show("Você tem certeza que deseja apagar o(s) item(ns) selecionado(s)?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Remove os itens selecionados
                    RemoverItensSelecionados();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma linha.", "Nenhuma Linha Selecionada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RemoverItensSelecionados()
        {
            // Conectar ao banco de dados
            string connectionString = "Data Source=26.170.34.113;Initial Catalog=SistemaYiG;User ID=sa;Password=123";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Loop através das linhas selecionadas e remove cada uma
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        // Obtém o valor do ID da linha selecionada
                        int selectedId = Convert.ToInt32(row.Cells["lid"].Value);

                        // Define a consulta SQL para remover o item com base no ID
                        string query = "DELETE FROM Estoque WHERE lid = @selectedId";

                        // Cria e executa o comando SQL para remover o item
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Adiciona o parâmetro para o ID
                            command.Parameters.AddWithValue("@selectedId", selectedId);

                            // Executa a instrução SQL
                            command.ExecuteNonQuery();
                        }
                    }

                    // Atualiza o DataGridView após a remoção
                    ExibirDadosNoDataGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao acessar o banco de dados: " + ex.ToString());
                }
            }
        }

        // Variável pública para armazenar o ID selecionado

    }
}
