using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FINAL_V2.SistemaForm;
using static FINAL_V2.Vendas;

namespace FINAL_V2
{
    public partial class ClienteView : Form
    {
        
        
        List<Produto> produtosCadastradosClienteView = new List<Produto>();
        ProdutoRepository produtoRepository = new ProdutoRepository();

        // Criar um objeto Produto
        Produto novoProduto = new Produto
        {
            Id = 1,
            Nome = "Produto Novo",
            Quantidade = "10",
            Valor = 100.0m,
            
        };
        private BindingList<Vendas.Produto> produtosExibicao = new BindingList<Vendas.Produto>();

        
        public ClienteView()
        {
            
            
            InitializeComponent();
            

            dataGridView1.DataSource = produtosExibicao;
            // Configurar o intervalo do Timer para 1000 milissegundos (1 segundo)
            timer1.Interval = 10;  // Defina o intervalo de acordo com a sua necessidade

            // Assine o evento Tick do Timer
            timer1.Tick += Timer1_Tick;

            // Iniciar o Timer
            timer1.Start();

            // Configurar o intervalo do Timer para 1000 milissegundos (1 segundo)
            timer2.Interval = 1000;  // Defina o intervalo de acordo com a sua necessidade

            // Assine o evento Tick do Timer
            timer2.Tick += timer2_Tick;

            // Iniciar o Timer
            timer2.Start();

        }



        private void Timer1_Tick(object sender, EventArgs e)
        {
            AtualizarDataGrid();
            AtualizarPreco();
            AtualizarOperador();
        }

        private void AtualizarPreco()
        {
            button9.Text = GlobalData.Preco.ToString();
            
        }
        
        private void AtualizarOperador()
        {
            
            button3.Text = GlobalDataSistema.OperadorGlobal;
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        // No formulário ClienteView (button7_Click)
        private void AtualizarDataGrid()
        {
            dataGridView1.Rows.Clear();
            // Acesse os dados do DataGridView1 do formulário Vendas diretamente
            List<Vendas.Produto> dadosDoDataGridView1 = DadosDoDataGridViewSingleton.Instance.DadosDoDataGridView;

            // Limpe a lista de exibição atual
            produtosExibicao.Clear();

            // Adicione os novos dados à lista de exibição
            foreach (Vendas.Produto produto in dadosDoDataGridView1)
            {
                produtosExibicao.Add(produto);
            }

            // Defina o tamanho da fonte para todas as colunas
            Font novaFonte = new Font(dataGridView1.DefaultCellStyle.Font.FontFamily, 18);
            dataGridView1.DefaultCellStyle.Font = novaFonte;

            dataGridView1.Columns[0].Width = 85;
            dataGridView1.Columns[2].Width = 35;
            dataGridView1.Columns[3].Width = 100;

        }







        // Adicione este método para atualizar o DataGridView com os novos dados







        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            // Atualizar a hora atual em tempo real no button4
            button4.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void ClienteView_Load_2(object sender, EventArgs e)
        {
            // Atribuir a data atual ao button5
            button5.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void button7_Click_1(object sender, EventArgs e)
        {

        }
    }

}
