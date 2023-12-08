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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ClosedXML.Excel;

namespace FINAL_V2.UsuaryControl
{
    public partial class Faturamento : UserControl
    {

        public Faturamento()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChamarDados();
        }

        private void ChamarDados()
        {
            DateTime dataLimite = dateTimePicker1.Value; // Obtenha o valor do DateTimePicker

            string connectionString = "Data Source=26.170.34.113;Initial Catalog=SistemaYiG;User ID=sa;Password=123";

            // Crie uma consulta SQL para obter os dados desejados da tabela NFADM com base na data
            string sqlQuery = "SELECT NomeProduto, IDNota, ValorComercial, Lucro, Data FROM NFADM " +
                              "WHERE Data >= @DataLimite";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                try
                {
                    // Defina o parâmetro para a data limite
                    command.Parameters.AddWithValue("@DataLimite", dataLimite);

                    // Abra a conexão
                    connection.Open();

                    // Crie um adaptador de dados
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        // Crie um DataTable para armazenar os resultados
                        DataTable dataTable = new DataTable();

                        // Preencha o DataTable com os resultados da consulta
                        adapter.Fill(dataTable);

                        // Limpe os dados existentes no DataGridView
                        dataGridView1.Rows.Clear();

                        // Variáveis para armazenar a soma de ValorComercial e Lucro
                        decimal somaValorComercial = 0;
                        decimal somaLucro = 0;

                        // Adicione os dados ao DataGridView sem gerar novas colunas
                        foreach (DataRow row in dataTable.Rows)
                        {
                            dataGridView1.Rows.Add(row["NomeProduto"], row["IDNota"], row["ValorComercial"], row["Lucro"], row["Data"]);

                            // Some o ValorComercial e o Lucro às variáveis de soma
                            somaValorComercial += Convert.ToDecimal(row["ValorComercial"]);
                            somaLucro += Convert.ToDecimal(row["Lucro"]);
                        }

                        // Mostre a soma de ValorComercial na Label1
                        label1.Text = somaValorComercial.ToString("C2");

                        // Mostre a soma de Lucro na Label2
                        label2.Text = somaLucro.ToString("C2");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao consultar o banco de dados: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Obtém os IDs dos registros selecionados no DataGridView
            List<int> idsToRemove = new List<int>();

            // Verifica se há linhas selecionadas
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (int.TryParse(row.Cells["Column2"].Value.ToString(), out int id))
                    {
                        idsToRemove.Add(id);
                    }
                }

                // Remove os registros do banco de dados
                if (idsToRemove.Any())
                {
                    RemoverRegistrosDoBanco(idsToRemove); // Método para remover registros no banco de dados
                    ChamarDados();
                }
            }
            else
            {
                MessageBox.Show("Nenhuma linha selecionada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Método para remover os registros do banco de dados
        private void RemoverRegistrosDoBanco(List<int> idsToRemove)
        {
            string connectionString = "Data Source=26.170.34.113;Initial Catalog=SistemaYiG;User ID=sa;Password=123"; // Substitua pela sua string de conexão

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (int id in idsToRemove)
                {
                    string deleteQuery = "DELETE FROM NFADM WHERE IDNota = @ID"; // Use o nome da coluna correto na sua tabela
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private DataTable ConvertToDataTable(DataGridView dataGridView)
        {
            DataTable dt = new DataTable();

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                dt.Columns.Add(column.HeaderText);
            }

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                DataRow dataRow = dt.NewRow();

                foreach (DataGridViewCell cell in row.Cells)
                {
                    dataRow[cell.ColumnIndex] = cell.Value;
                }

                dt.Rows.Add(dataRow);
            }

            return dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Verifica se há dados no DataGridView
            if (dataGridView1.Rows.Count > 0)
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            // Cria um novo arquivo Excel
                            using (XLWorkbook workbook = new XLWorkbook())
                            {
                                // Adiciona uma planilha ao arquivo Excel
                                var worksheet = workbook.Worksheets.Add("Dados");

                                // Converte o DataGridView para um DataTable
                                DataTable dt = ConvertToDataTable(dataGridView1);

                                // Copia os dados do DataTable para a planilha Excel
                                worksheet.Cell(1, 1).InsertTable(dt);

                                // Salva o arquivo Excel no local escolhido pelo usuário
                                workbook.SaveAs(sfd.FileName);
                            }

                            MessageBox.Show("Dados exportados com sucesso para o Excel!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao exportar para Excel: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Não há dados para exportar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
