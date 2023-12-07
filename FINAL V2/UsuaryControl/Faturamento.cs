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

namespace FINAL_V2.UsuaryControl
{
    public partial class Faturamento : UserControl
    {

        

        public Faturamento()
        {
            InitializeComponent();
        }

        private void Faturamento_Load(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dataLimite = dateTimePicker1.Value; // Obtenha o valor do DateTimePicker

            string connectionString = "Data Source=26.170.34.113;Initial Catalog=SistemaYiG;User ID=sa;Password=123";

            // Crie uma consulta SQL para obter os dados desejados da tabela NFADM com base na data
            string sqlQuery = "SELECT NomeProduto, IDNota, ValorComercial, Lucro FROM NFADM " +
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
                            dataGridView1.Rows.Add(row["NomeProduto"], row["IDNota"], row["ValorComercial"], row["Lucro"]);

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

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
