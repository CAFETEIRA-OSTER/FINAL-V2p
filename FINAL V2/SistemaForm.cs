using FINAL_V2.UsuaryControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FINAL_V2
{
    public partial class SistemaForm : Form
    {
        private bool isDragging = false;  // Variável para rastrear se o formulário está sendo arrastado
        private Point lastCursorPosition;  // Armazena a última posição do cursor durante o arrasto
        private Desconto descontoForm;  // Instância do formulário de desconto
        private int nivelAcesso;  // Variável para armazenar o nível de acesso do usuário
        private string Operador;
        private Timer timer;

        public class GlobalDataSistema
        {
            public static string OperadorGlobal { get; set; }
        }


        // Construtor do formulário, recebe uma instância do formulário de login (ou controle de usuário)
        public SistemaForm(Login loginForm)
        {
            InitializeComponent();
            InitializeContextMenu();  // Inicializa o menu de contexto
            Application.EnableVisualStyles();
            this.KeyPreview = true;
            descontoForm = new Desconto();  // Inicializa o formulário de desconto
            vendasToolStripMenuItem1.Select();  // Seleciona o item de menu de vendas

            // Armazena o nível de acesso do usuário
            this.nivelAcesso = loginForm.NivelAcesso;
            this.Operador = loginForm.NomeUsuario;
        }

        // Manipulador de eventos para a tecla pressionada
        private void SistemaForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                GlobalDataSistema.OperadorGlobal = Operador;
                // Lógica para quando a tecla F1 é pressionada
                decimal somaTotal = 0;  // Valor apropriado a ser definido
                List<Vendas.Produto> produtosCadastrados = new List<Vendas.Produto>();  // Produtos apropriados a serem preenchidos
                List<Vendas.Produto> produtosSelecionados = new List<Vendas.Produto>();

                // Instâncias dos formulários de vendas e visualização de cliente
                Vendas vendasForm = new Vendas(somaTotal, produtosCadastrados);
                ClienteView clienteViewForm = new ClienteView();

                // Configuração da posição dos formulários
                vendasForm.StartPosition = FormStartPosition.Manual;
                vendasForm.Location = new Point(0, 0);  // Posição do segundo monitor ou qualquer posição desejada

                clienteViewForm.StartPosition = FormStartPosition.Manual;
                clienteViewForm.Location = new Point(0, 0);  // Posição do primeiro monitor ou qualquer posição desejada

                // Exibição dos formulários
                vendasForm.Show();
                clienteViewForm.Show();
            }
        }

        // Método para inicializar o menu de contexto
        private void InitializeContextMenu()
        {
            // Ícones para os itens de menu
            Image iconFech = Properties.Resources.x;
            Image iconMin = Properties.Resources.menos;

            // Adiciona itens de menu ao contextoMenuStrip1
            contextMenuStrip1.Items.Add("Fechar", iconFech, CloseToolStripMenuItem_Click);
            contextMenuStrip1.Items.Add("Minimizar", iconMin, MinimizeToolStripMenuItem_Click);

            // Associa o contextMenuStrip1 ao panel4
            panel4.ContextMenuStrip = contextMenuStrip1;
        }

        // Manipulador de eventos para o item de menu de restaurar
        private void RestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                // Restaura o formulário para o tamanho normal e centraliza na tela
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
        }

        // Manipulador de eventos para o item de menu de minimizar
        private void MinimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Minimiza o formulário
            this.WindowState = FormWindowState.Minimized;
        }

        // Manipulador de eventos para o item de menu de maximizar
        private void MaximizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Maximiza o formulário
            this.WindowState = FormWindowState.Maximized;
        }

        // Manipulador de eventos para o item de menu de fechar
        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Fecha o formulário
            this.Close();
        }

        // Manipulador de eventos para o clique do mouse no formulário
        private void SistemaForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Exibe o menu de contexto personalizado contextMenuStrip1 na posição do clique com o botão direito
                contextMenuStrip1.Show(this, e.Location);
            }
        }

        // Método para receber e exibir o nível de acesso nas labels
        public void Receberlabels()
        {
            // Exibe o valor do nível de acesso em uma label
            label1.Text = ("Acesso: ") + nivelAcesso.ToString();
            label2.Text = ("Operador: ") +Operador.ToString();
        }

        // Manipulador de eventos para o botão do mouse pressionado no painel
        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursorPosition = e.Location;
            }
        }

        // Manipulador de eventos para o movimento do mouse no painel
        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int deltaX = e.X - lastCursorPosition.X;
                int deltaY = e.Y - lastCursorPosition.Y;

                this.Left += deltaX;
                this.Top += deltaY;
            }
        }

        // Manipulador de eventos para o botão do mouse liberado no painel
        private void panel4_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;

                
            }
        }

        // Manipulador de eventos para o botão de minimizar
        private void button3_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Manipulador de eventos para o botão de fechar
        private void button2_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        // Manipulador de eventos para o item de menu de faturamento
        private void faturamentoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;

            // Cria uma instância do controle de usuário "Faturamento"
            Faturamento faturamentoControl = new Faturamento();

            // Define o controle de usuário para preencher o espaço disponível
            faturamentoControl.Dock = DockStyle.Fill;

            // Adiciona o controle de usuário "Faturamento" ao formulário principal
            panel3.Controls.Add(faturamentoControl);

            // Define a visibilidade do controle de usuário como verdadeira
            faturamentoControl.Visible = true;

            // Garante que o controle de usuário "Faturamento" está na frente de outros controles, se necessário
            faturamentoControl.BringToFront();
        }

        // Manipulador de eventos para o item de menu de vendas
        private void vendasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            decimal somaTotal = 0; // Defina o valor apropriado
            List<Vendas.Produto> produtosCadastrados = new List<Vendas.Produto>(); // Preencha com produtos apropriados
            List<Vendas.Produto> produtosSelecionados = new List<Vendas.Produto>();

            // Cria uma instância do formulário "Vendas" com os argumentos necessários
            Vendas vendasForm = new Vendas(somaTotal, produtosCadastrados);
            ClienteView clienteViewForm = new ClienteView();

            // Define a posição do formulário "Vendas"
            vendasForm.StartPosition = FormStartPosition.Manual;
            vendasForm.Location = new Point(0, 0); // Posição do segundo monitor, ou qualquer posição que você desejar

            // Define a posição do formulário "ClienteView"
            clienteViewForm.StartPosition = FormStartPosition.Manual;
            clienteViewForm.Location = new Point(0, 0); // Posição do primeiro monitor, ou qualquer posição que você desejar

            // Exibe ambos os formulários
            vendasForm.Show();
            clienteViewForm.Show();
        }

        // Manipulador de eventos para o item de menu de consultar
        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;

            // Cria uma instância do controle de usuário "Consultar"
            Consultar consultarControl = new Consultar();

            // Define o controle de usuário para preencher o espaço disponível
            consultarControl.Dock = DockStyle.Fill;

            // Adiciona o controle de usuário "Consultar" ao formulário principal
            panel3.Controls.Add(consultarControl);

            // Define a visibilidade do controle de usuário como verdadeira
            consultarControl.Visible = true;

            // Garante que o controle de usuário "Consultar" está na frente de outros controles, se necessário
            consultarControl.BringToFront();
        }

        // Manipulador de eventos para o item de menu de cadastrar
        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;

            // Cria uma instância do controle de usuário "Cadastrar"
            Cadastrar cadastroControl = new Cadastrar();

            // Define o controle de usuário para preencher o espaço disponível
            cadastroControl.Dock = DockStyle.Fill;

            // Adiciona o controle de usuário "Cadastrar" ao formulário principal
            panel3.Controls.Add(cadastroControl);

            // Define a visibilidade do controle de usuário como verdadeira
            cadastroControl.Visible = true;

            // Garante que o controle de usuário "Cadastrar" está na frente de outros controles, se necessário
            cadastroControl.BringToFront();
        }

        // Manipulador de eventos do formulário ao ser carregado
        private void SistemaForm_Load(object sender, EventArgs e)
        {
            Receberlabels();  // Atualiza as labels com o nível de acesso
            // Inicializa o timer
            timer = new Timer();
            timer.Interval = 1000; // Intervalo em milissegundos (1 segundo)
            timer.Tick += Timer1_Tick;
            timer.Start();

            if (nivelAcesso == 2)
            {
                estoqueToolStripMenuItem1.Enabled = false;
                financeiroToolStripMenuItem1.Enabled = false;
                funcionáriosToolStripMenuItem1.Enabled = false;
            }
            if (nivelAcesso == 3)
            {
                estoqueToolStripMenuItem1.Enabled = false;
                financeiroToolStripMenuItem1.Enabled = false;
                vendasToolStripMenuItem1.Enabled = false;
            }
            

        }


        private void Timer1_Tick(object sender, EventArgs e)
        {
            // Atualiza o label3 com o horário atual
            label3.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void estoqueToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ajudaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Abre o link no navegador padrão
            Process.Start("https://92e41e-2.myshopify.com/?_ab=0&_fd=0&_sc=1");
        }
    }
}
