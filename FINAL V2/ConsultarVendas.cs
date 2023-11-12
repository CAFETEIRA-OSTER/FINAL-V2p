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
    public partial class ConsultarVendas : Form
    {
        private int lastSelectedRowIndex = -1;

        public ConsultarVendas()
        {
            InitializeComponent();
            textBox2.KeyDown += TextBox2_KeyDown;
            dataGridView1.KeyDown += DataGridView1_KeyDown;
            

            // Defina a propriedade de seleção para linha inteira
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifique se a tecla pressionada é Enter
            if (e.KeyCode == Keys.Enter)
            {
                // Chame o método para exibir dados no DataGridView
                ExibirDadosNoDataGridView();
            }
            if (e.KeyCode == Keys.Escape)
            {
                // Mensagem de depuração
                Console.WriteLine("Tecla 'Esc' pressionada. Fechando o formulário.");

                // Ou use MessageBox para uma mensagem visual
                // MessageBox.Show("Tecla 'Esc' pressionada. Fechando o formulário.");

                // Feche o formulário
                this.Close();
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

                        // Se houver linhas no DataGridView, selecione a primeira
                        if (dataGridView1.Rows.Count > 0)
                        {
                            SelecionarLinha(0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao acessar o banco de dados: " + ex.ToString());
                }
            }
        }

        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Escape)
            {
                // Mensagem de depuração
                Console.WriteLine("Tecla 'Esc' pressionada. Fechando o formulário.");

                // Ou use MessageBox para uma mensagem visual
                // MessageBox.Show("Tecla 'Esc' pressionada. Fechando o formulário.");

                // Feche o formulário
                this.Close();
            }
            // Verifique se a tecla pressionada é F12
            if (e.KeyCode == Keys.F12)
            {
                // Impede a seleção de colunas
                e.Handled = true;

                // Alterne entre as linhas acima e abaixo
                if (lastSelectedRowIndex >= 0 && lastSelectedRowIndex < dataGridView1.Rows.Count - 1)
                {
                    SelecionarLinha(lastSelectedRowIndex + 1);
                }
                else if (lastSelectedRowIndex == dataGridView1.Rows.Count - 1)
                {
                    SelecionarLinha(0);
                }
            }
        }
        
        private void SelecionarLinha(int rowIndex)
        {
            // Desmarque a última linha selecionada
            if (lastSelectedRowIndex >= 0 && lastSelectedRowIndex < dataGridView1.Rows.Count)
            {
                dataGridView1.Rows[lastSelectedRowIndex].Selected = false;
            }

            // Marque a nova linha
            dataGridView1.Rows[rowIndex].Selected = true;

            // Atualize o índice da última linha selecionada
            lastSelectedRowIndex = rowIndex;
        }
        

        private void AdicionarLinhaAoFormVendas()
        {
            // Verifique se há pelo menos uma linha selecionada
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtém as informações da linha selecionada
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Cria uma lista para armazenar as informações da linha
                List<object> informacoesLinha = new List<object>();

                // Adiciona as células da linha à lista
                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    informacoesLinha.Add(cell.Value);
                }

                // Chama o evento personalizado no formulário pai (Vendas) e passa as informações
                (this.ParentForm as Vendas)?.AdicionarLinhaAoDataGridView(informacoesLinha);
            }
        }
        





        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ConsultarVendas_Load(object sender, EventArgs e)
        {

        }
    }
}
