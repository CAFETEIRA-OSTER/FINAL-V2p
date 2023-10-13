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
        private bool isDragging = false;
        private Point lastCursorPosition;
        private Desconto descontoForm; // Adicione esta linha
        
        public SistemaForm()
        {
            InitializeComponent();
            InitializeContextMenu();
            Application.EnableVisualStyles();
            this.KeyPreview = true;
            descontoForm = new Desconto(); // Inicialize o descontoForm aqui
            vendasToolStripMenuItem1.Select();


        }
        private void SistemaForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                // Certifique-se de que 'somaTotal' e 'produtosCadastrados' tenham valores apropriados aqui
                decimal somaTotal = 0; // Defina o valor apropriado
                List<Vendas.Produto> produtosCadastrados = new List<Vendas.Produto>(); // Preencha com produtos apropriados


                // Crie uma instância do formulário "FormVendas" com os argumentos necessários
                Vendas vendasForm = new Vendas(somaTotal, produtosCadastrados);

                // Mostre o formulário "FormVendas"
                vendasForm.ShowDialog();

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

        private void SistemaForm_Load(object sender, EventArgs e)
        {
            // ...
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
            // Certifique-se de que 'somaTotal' e 'produtosCadastrados' tenham valores apropriados aqui
            decimal somaTotal = 0; // Defina o valor apropriado
            List<Vendas.Produto> produtosCadastrados = new List<Vendas.Produto>(); // Preencha com produtos apropriados


            // Crie uma instância do formulário "FormVendas" com os argumentos necessários
            Vendas vendasForm = new Vendas(somaTotal, produtosCadastrados);

            // Mostre o formulário "FormVendas"
            vendasForm.ShowDialog();



        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}