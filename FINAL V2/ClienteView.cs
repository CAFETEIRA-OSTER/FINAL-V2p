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
            AtualizarNF();
        }

        private void AtualizarPreco()
        {
            button13.Text = "R$ " + GlobalData.Preco.ToString("F2");
            button11.Text = "R$ " + (GlobalData.DescontoView / 100).ToString("F2");
            button9.Text = "R$" + (GlobalData.Preco + (GlobalData.DescontoView / 100)).ToString("F2") ;

        }

        private void AtualizarNF()
        {
            button6.Text = "CUPOM FISCAL NÚMERO: " + GlobalData.NF.ToString();
        }

        private void AtualizarOperador()
        {
            
            button3.Text = GlobalDataSistema.OperadorGlobal;

        }

        private void AtualizaDados()
        {
            button6.Text = GlobalData.NF.ToString();
            button3.Text = GlobalDataSistema.OperadorGlobal;
        }

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

        private void timer2_Tick(object sender, EventArgs e)
        {
            // Atualizar a hora atual em tempo real no button4
            button4.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void ClienteView_Load_2(object sender, EventArgs e)
        {
            // Atribuir a data atual ao button5
            button5.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dataGridView1.Focus();


        }

    }

}
