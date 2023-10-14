using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINAL_V2
{
    public partial class Vendas : Form
    {

        private bool isDragging = false;
        private Point lastCursorPos;
        private Point lastFormPos;
        private Point lastCursorPosition;
        private int valorLabel = 0;
        private List<Produto> produtosCadastrados = new List<Produto>();
        private decimal somaTotal = 1;
        private decimal somaTotal2 = 0;
        private decimal somaTotal3 = 0;
        private decimal somaTotala = 1;
        private int linhaSelecionada = -1;
        private Desconto descontoForm;
        public decimal DescontoValue { get; set; }
        private ClienteView clienteViewForm;

        private string desconto = "";

        public int ValorLabel
        {
            get { return valorLabel; }
            set
            {
                valorLabel = value;
                
            }
        }
        public Vendas(decimal somaTotal, List<Vendas.Produto> produtosCadastrados)
        {
            InitializeComponent();
            clienteViewForm = new ClienteView();
            textBox1.Focus();
            this.somaTotal = somaTotal;
            this.produtosCadastrados = produtosCadastrados;
            descontoForm = new Desconto();
            this.KeyPreview = true;
            this.FormClosed += Desconto_FormClosed;
            // Configurar o intervalo do Timer para 1000 milissegundos (1 segundo)
            timer1.Interval = 1;

            // Assinar o evento Tick do Timer
            timer1.Tick += TimerAtualizarSoma_Tick;

            // Iniciar o Timer
            timer1.Start();


            textBox1.Focus();
        }
        private void TimerAtualizarSoma_Tick(object sender, EventArgs e)
        {
            // Executa a função para atualizar a soma total a cada segundo
            AtualizarSomaTotala();

            



            // Calcula a somaTotal3 com base na porcentagem em somaTotala
            decimal porcentagemDesconto = somaTotala / 100; // Converte a porcentagem em um valor decimal
            decimal desconto = somaTotal * porcentagemDesconto;
            decimal somaTotal3 = somaTotal - desconto;

            // Define o valor de somaTotal como o texto do botão (button12)
            button13.Text = $"R${(somaTotal3 / 100):F2}"; // Formate a somaTotal3 como moeda, se necessário

            // Calcula a diferença entre somaTotal e somaTotal3
            decimal diferenca = somaTotal - somaTotal3;
            somaTotal2 = desconto;
            somaTotal3 *= diferenca;

            button12.Text = $"R${(somaTotal2 / 100):F2}";

        }


        private void SistemaForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && dataGridView1.SelectedRows.Count > 0)
            {
                // Obtenha a linha selecionada
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Obtenha o valor do produto a ser subtraído
                decimal valorProduto = Convert.ToDecimal(selectedRow.Cells[3].Value);

                // Remova a linha do DataGridView
                dataGridView1.Rows.Remove(selectedRow);

                // Subtraia o valor do produto da soma total
                somaTotal -= valorProduto * 100;

                // Atualize o texto do button13 com a nova soma total formatada como moeda
                button13.Text = $"R${(somaTotal / 100):F2}";
            }
            

            if (e.KeyCode == Keys.F2)
            {
                // Limpar a lista de produtos e o DataGridView
                produtosCadastrados.Clear();
                dataGridView1.Rows.Clear();

                // Redefinir as variáveis de soma
                somaTotal = 0;
                somaTotal2 = 0;
                somaTotal3 = 0;
                somaTotala = 0;

                descontoForm.ValorLabell = 0;
                // Atualizar os valores dos botões
                button12.Text = $"R${(somaTotal2 / 100):F2}";
                button13.Text = $"R${(somaTotal3 / 100):F2}";


            }
            if (e.KeyCode == Keys.F3)
            {
                Crédito creditoForm = new Crédito();
                creditoForm.ShowDialog();
            }
            if (e.KeyCode == Keys.F4)
            {
                Débito debitoForm = new Débito();
                debitoForm.ShowDialog();
            }
            if (e.KeyCode == Keys.F5)
            {
                Pix pixForm = new Pix();
                pixForm.ShowDialog();
            }
            if (e.KeyCode == Keys.F6)
            {
                Dinheiro dinheiroForm = new Dinheiro();
                dinheiroForm.ShowDialog();
            }
            // Verifique se a tecla F7 foi pressionada
            if (e.KeyCode == Keys.F7)
            {
                AtualizarSomaTotala();
                descontoForm.ShowDialog(); // Abre o formulário Desconto como uma janela de diálogo

            }
            if (e.KeyCode == Keys.F2)
            {
                // Limpar a lista de produtos e o DataGridView
                produtosCadastrados.Clear();
                dataGridView1.Rows.Clear();

                // Redefinir as variáveis de soma
                somaTotal = 0;
                somaTotal2 = 0;
                somaTotal3 = 0;
                somaTotala = 0;

                descontoForm.ValorLabell = 0;
                // Atualizar os valores dos botões
                button12.Text = $"R${(somaTotal2 / 100):F2}";
                button13.Text = $"R${(somaTotal3 / 100):F2}";


            }

            if (e.KeyCode == Keys.F12)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    if (linhaSelecionada < dataGridView1.Rows.Count - 1)
                    {
                        // Desselecione a linha anterior (se houver uma linha anterior selecionada)
                        if (linhaSelecionada >= 0)
                        {
                            dataGridView1.Rows[linhaSelecionada].Selected = false;
                        }

                        // Incrementa a variável de controle para a próxima linha
                        linhaSelecionada++;

                        // Seleciona a próxima linha no DataGridView
                        dataGridView1.Rows[linhaSelecionada].Selected = true;
                    }
                    else
                    {
                        // Se já estiver na última linha, selecione a primeira linha novamente
                        if (linhaSelecionada >= 0)
                        {
                            dataGridView1.Rows[linhaSelecionada].Selected = false;
                        }
                        linhaSelecionada = 0;
                        dataGridView1.Rows[linhaSelecionada].Selected = true;
                    }
                }
            }

        }
        private void Desconto_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Atualize a soma total no formulário de vendas
            AtualizarSomaTotala();
            
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
                            // Formata a somaTotal como moeda
                            button13.Text = $"R${(somaTotal3 / 100):F2}";



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

            
        }

        private void button10_Click_1(object sender, EventArgs e)
        {

            descontoForm.ShowDialog(); // Abre o formulário Desconto como uma janela de diálogo

        }

        private void AtualizarSomaTotala()
        {
            somaTotala = descontoForm.ValorLabell;

        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Limpar a lista de produtos e o DataGridView
            produtosCadastrados.Clear();
            dataGridView1.Rows.Clear();

            // Redefinir as variáveis de soma
            somaTotal = 0;
            somaTotal2 = 0;
            somaTotal3 = 0;
            somaTotala = 0;

            descontoForm.ValorLabell = 0;
            // Atualizar os valores dos botões
            button12.Text = $"R${(somaTotal2 / 100):F2}";
            button13.Text = $"R${(somaTotal3 / 100):F2}";

            // Outras ações de redefinição, se necessário

            // Exemplo de mensagem informando que tudo foi redefinido
            MessageBox.Show("Todas as variáveis e o DataGridView foram redefinidos.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Verifique se há pelo menos uma linha selecionada
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtenha a linha selecionada
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Remova a linha do DataGridView
                dataGridView1.Rows.Remove(selectedRow);
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void button6_Click(object sender, EventArgs e)
        {
            Dinheiro dinheiroForm = new Dinheiro();
            dinheiroForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Pix pixForm = new Pix();
            pixForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Débito debitoForm = new Débito();
            debitoForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Crédito creditoForm = new Crédito();    
            creditoForm.ShowDialog();
        }

        private void panel19_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursorPos = Cursor.Position;
                lastFormPos = this.Location;
            }
        }

        private void panel19_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentCursorPos = Cursor.Position;
                int deltaX = currentCursorPos.X - lastCursorPos.X;
                int deltaY = currentCursorPos.Y - lastCursorPos.Y;

                this.Location = new Point(lastFormPos.X + deltaX, lastFormPos.Y + deltaY);
            }
        }

        private void panel19_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void panel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        




    }
}
