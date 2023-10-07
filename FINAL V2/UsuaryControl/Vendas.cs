using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;
using pix_payload_generator;
using pix_payload_generator.net.Models.CobrancaModels;
using pix_payload_generator.net.Models.PayloadModels;

namespace FINAL_V2.UsuaryControl
{
    public partial class Vendas : UserControl
    {


        private int valorLabel = 0;
        private List<Produto> produtosCadastrados = new List<Produto>();
        private decimal somaTotal = 0;
        private decimal somaTotala = 0;
        private Desconto descontoForm;
        public decimal DescontoValue { get; set; }

        public Vendas(decimal somaTotal, List<Vendas.Produto> produtosCadastrados)
        {
            InitializeComponent();
            this.somaTotal = somaTotal;
            this.produtosCadastrados = produtosCadastrados;
            descontoForm = new Desconto();
            somaTotala = descontoForm.ValorLabel; // Altere para descontoForm.ValorLabel
            this.KeyUp += Sistema_KeyUp;
        }

        private void Sistema_KeyUp(object sender, KeyEventArgs e)
        {
            // Verifica se a tecla F1 foi pressionada
            if (e.KeyCode == Keys.F2)
            {
                // Exibe a mensagem desejada
                MessageBox.Show("Você pressionou a tecla F1!");
            }
        }

        public class Produto
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Quantidade { get; set; }
            public decimal Valor { get; set; }
            public string Tipo { get; set; }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e) // adicionar intens
        {
            int id;
            if (e.KeyCode == Keys.Enter && int.TryParse(textBox1.Text, out id))
            {
                string connectionString = "Data Source=26.170.34.113;Initial Catalog=SistemaYiG;User ID=sa;Password=123";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        // Consulta SQL para selecionar o produto com base no ID
                        string query = "SELECT * FROM Estoque WHERE lid = @lid";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@lid", id);

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            Produto produto = new Produto
                            {
                                Id = Convert.ToInt32(reader["lid"]),
                                Nome = reader["Nome"].ToString(),
                                Quantidade = "1", // Sempre começa com 1 ao ser adicionado
                                Valor = Convert.ToDecimal(reader["Preço"]),
                                Tipo = reader["Tipo"].ToString()
                            };

                            // Verifica se o produto já está na lista
                            Produto produtoExistente = produtosCadastrados.FirstOrDefault(p => p.Id == produto.Id);
                            if (produtoExistente != null)
                            {
                                // Se o produto já existe na lista, incrementa a quantidade e o valor
                                int quantidadeExistente = Convert.ToInt32(produtoExistente.Quantidade);
                                produtoExistente.Quantidade = (quantidadeExistente + 1).ToString();
                                produtoExistente.Valor += produto.Valor;

                                // Atualiza a linha na grid
                                int rowIndex = dataGridView1.Rows.Cast<DataGridViewRow>().ToList().FindIndex(r => (int)r.Cells[0].Value == produto.Id);
                                dataGridView1.Rows[rowIndex].Cells[2].Value = produtoExistente.Quantidade;

                                // Garanta que o valor seja tratado como decimal aqui
                                dataGridView1.Rows[rowIndex].Cells[3].Value = (produtoExistente.Valor / 100).ToString("N2");
                            }
                            else
                            {
                                // Se o produto não existe na lista, adiciona-o
                                produtosCadastrados.Add(produto);
                                dataGridView1.Rows.Add(produto.Id, produto.Nome, produto.Quantidade, (produto.Valor / 100).ToString("N2"), produto.Tipo);
                            }

                            textBox1.Clear(); // Limpa o TextBox após adicionar

                            // Calcula a soma total novamente
                            somaTotal = produtosCadastrados.Sum(p => p.Valor);
                            button13.Text = $"R${(somaTotal / 100):F2}"; // Formata a somaTotal como moeda




                            // Opcionalmente, você pode selecionar a última linha no DataGridView para que ela esteja visível
                            if (dataGridView1.Rows.Count > 0)
                            {
                                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
                            }
                        }
                        else
                        {
                            MessageBox.Show("Produto não encontrado.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao consultar o banco de dados: " + ex.Message);
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e) // gerar qr
        {

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("00020126580014BR.GOV.BCB.PIX0136271aa240-1e82-4e8a-a6f3-5350415eb0d55204000053039865802BR5925Yuri Bernardo Siebeneichl6009SAO PAULO61080540900062240520ekpiML64c4DoBZxmgieb63047AD9", QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            pictureBox1.Image = qrCodeImage;
        }

        private void button10_Click(object sender, EventArgs e)
        {

            descontoForm.ShowDialog(); // Abre o formulário Desconto como uma janela de diálogo

        }


        private void AtualizarSomaTotala()
        {
            somaTotala = descontoForm.ValorLabel;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AtualizarSomaTotala();
            MessageBox.Show($"Soma Total: {somaTotala:C2}");

        }



        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        
        private string desconto = "";
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel31_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
