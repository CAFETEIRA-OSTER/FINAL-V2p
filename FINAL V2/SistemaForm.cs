using FINAL_V2.UsuaryControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        
        public SistemaForm(Login loginForm)
        {
            InitializeComponent();
            InitializeContextMenu();
            Application.EnableVisualStyles();
            this.KeyPreview = true;
            descontoForm = new Desconto();
            vendasToolStripMenuItem1.Select();

            // Use a propriedade NivelAcesso para armazenar o nível de acesso
            this.nivelAcesso = loginForm.NivelAcesso; // Alteração aqui
        }

        
        private void SistemaForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                decimal somaTotal = 0; // Defina o valor apropriado
                List<Vendas.Produto> produtosCadastrados = new List<Vendas.Produto>(); // Preencha com produtos apropriados
                List<Vendas.Produto> produtosSelecionados = new List<Vendas.Produto>();


                Vendas vendasForm = new Vendas(somaTotal, produtosCadastrados);
                ClienteView clienteViewForm = new ClienteView();

                vendasForm.StartPosition = FormStartPosition.Manual;
                vendasForm.Location = new Point(0, 0); // Posição do segundo monitor, ou qualquer posição que você desejar

                clienteViewForm.StartPosition = FormStartPosition.Manual;
                clienteViewForm.Location = new Point(0, 0); // Posição do primeiro monitor, ou qualquer posição que você desejar

                vendasForm.Show();
                clienteViewForm.Show();
            }
        }
            private void InitializeContextMenu()
        {
            Image iconFech = Properties.Resources.x;
            contextMenuStrip1.Items.Add("Fechar", iconFech, CloseToolStripMenuItem_Click);
            Image iconMin = Properties.Resources.menos;
            contextMenuStrip1.Items.Add("Minimizar", iconMin, MinimizeToolStripMenuItem_Click);
            // Associe o contextMenuStrip1 ao panel4
            panel4.ContextMenuStrip = contextMenuStrip1;



        }
        private void RestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen; // Centraliza o formulário na tela
            }
        }

        private void MinimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MaximizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SistemaForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Exibe o menu de contexto personalizado contextMenuStrip1 na posição do clique com o botão direito
                contextMenuStrip1.Show(this, e.Location);
            }
        }

        public void Receberlabels()
        {
            // Faça o que quiser com o valor do NivelAcesso
            // Por exemplo, atribua-o a um rótulo (label) em seu formulário
            label1.Text = ("Acesso: ") + nivelAcesso.ToString();
        }
        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursorPosition = e.Location;
            }
        }

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

        private void panel4_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;

                // Obtém a largura da tela primária
                int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
                int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

                // Define uma margem (por exemplo, 10 pixels) para considerar como "perto" da borda
                int margin = 10;

                // Verifique se o formulário está à esquerda ou à direita da metade da tela, considerando a margem
                if (this.Left <= margin)
                {
                    // Alinhe o formulário à esquerda da tela
                    this.Left = 0;
                }
                else if (this.Left + this.Width >= screenWidth - margin)
                {
                    // Alinhe o formulário à direita da tela
                    this.Left = screenWidth - this.Width;
                }  
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void faturamentoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            // Cria uma instância do controle de usuário "Faturamento"
            Faturamento faturamentoControl = new Faturamento();

            // Define o controle de usuário para preencher o espaço disponível
            faturamentoControl.Dock = DockStyle.Fill;

            // Adicione o controle de usuário "Faturamento" ao formulário principal
            panel3.Controls.Add(faturamentoControl);

            // Defina a visibilidade do controle de usuário como verdadeira
            faturamentoControl.Visible = true;


            // Garanta que o controle de usuário "Faturamento" está na frente de outros controles, se necessário
            faturamentoControl.BringToFront();
        }
        private void vendasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            decimal somaTotal = 0; // Defina o valor apropriado
            List<Vendas.Produto> produtosCadastrados = new List<Vendas.Produto>(); // Preencha com produtos apropriados
            List<Vendas.Produto> produtosSelecionados = new List<Vendas.Produto>();


            Vendas vendasForm = new Vendas(somaTotal, produtosCadastrados);
            ClienteView clienteViewForm = new ClienteView();

            vendasForm.StartPosition = FormStartPosition.Manual;
            vendasForm.Location = new Point(0, 0); // Posição do segundo monitor, ou qualquer posição que você desejar

            clienteViewForm.StartPosition = FormStartPosition.Manual;
            clienteViewForm.Location = new Point(0, 0); // Posição do primeiro monitor, ou qualquer posição que você desejar

            vendasForm.Show();
            clienteViewForm.Show();
        }

        /* private void vendasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Certifique-se de que 'somaTotal' e 'produtosCadastrados' tenham valores apropriados aqui
            decimal somaTotal = 0; // Defina o valor apropriado
            List<Vendas.Produto> produtosCadastrados = new List<Vendas.Produto>(); // Preencha com produtos apropriados

            // Crie uma instância do formulário "FormVendas" com os argumentos necessários
            Vendas vendasForm = new Vendas(somaTotal, produtosCadastrados);

            // Determine qual é o monitor 1 e monitor 2 (supondo que você tenha pelo menos dois monitores)
            Screen[] screens = Screen.AllScreens;

            // Verifique se há pelo menos dois monitores disponíveis
            if (screens.Length >= 2)
            {
                // Defina o formulário "FormVendas" para o segundo monitor (monitor 1)
                vendasForm.StartPosition = FormStartPosition.Manual;
                vendasForm.Location = screens[0].WorkingArea.Location; // Posição do segundo monitor

                // Crie uma instância do formulário "ClienteView"
                ClienteView clienteViewForm = new ClienteView();

                // Defina o formulário "ClienteView" para o primeiro monitor (monitor 0)
                clienteViewForm.StartPosition = FormStartPosition.Manual;
                clienteViewForm.Location = screens[0].WorkingArea.Location; // Posição do primeiro monitor

                // Mostre ambos os formulários
                vendasForm.Show();
                clienteViewForm.Show();
            }
            else
            {
                // Defina o formulário "FormVendas" para o segundo monitor (monitor 1)
                vendasForm.StartPosition = FormStartPosition.Manual;
                vendasForm.Location = screens[0].WorkingArea.Location; // Posição do segundo monitor

                // Crie uma instância do formulário "ClienteView"
                ClienteView clienteViewForm = new ClienteView();

                // Defina o formulário "ClienteView" para o primeiro monitor (monitor 0)
                clienteViewForm.StartPosition = FormStartPosition.Manual;
                clienteViewForm.Location = screens[0].WorkingArea.Location; // Posição do primeiro monitor
                // Em caso de apenas um monitor, exiba apenas o formulário "FormVendas" normalmente
                vendasForm.ShowDialog();
                clienteViewForm.Show();
            }
        }*/


        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            // Cria uma instância do controle de usuário "Faturamento"
            Consultar consultarControl = new Consultar();

            // Define o controle de usuário para preencher o espaço disponível
            consultarControl.Dock = DockStyle.Fill;

            // Adicione o controle de usuário "Faturamento" ao formulário principal
            panel3.Controls.Add(consultarControl);

            // Defina a visibilidade do controle de usuário como verdadeira
            consultarControl.Visible = true;


            // Garanta que o controle de usuário "Faturamento" está na frente de outros controles, se necessário
            consultarControl.BringToFront();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            // Cria uma instância do controle de usuário "Faturamento"
            Cadastrar cadastroControl = new Cadastrar();

            // Define o controle de usuário para preencher o espaço disponível
            cadastroControl.Dock = DockStyle.Fill;

            // Adicione o controle de usuário "Faturamento" ao formulário principal
            panel3.Controls.Add(cadastroControl);

            // Defina a visibilidade do controle de usuário como verdadeira
            cadastroControl.Visible = true;


            // Garanta que o controle de usuário "Faturamento" está na frente de outros controles, se necessário
            cadastroControl.BringToFront();
        }

        private void SistemaForm_Load(object sender, EventArgs e)
        {
            Receberlabels();
        }
    }
}