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
    public partial class Consultar : UserControl
    {


        public class Produto
        {
            public int lid { get; set; }
            public string Nome { get; set; }
            public int Quantidade { get; set; }
            public decimal Valor { get; set; }
            public string Tipo { get; set; }
            public decimal Lucro { get; set; }
            public string Secao { get; set; }
        }

        public Consultar()
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
