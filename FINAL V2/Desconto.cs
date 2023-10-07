using System;
using System.Windows.Forms;

namespace FINAL_V2
{
    public partial class Desconto : Form
    {
        private int valorLabel = 0;
        private string desconto = "";
        public int ValorLabel
        {
            get { return valorLabel; }
        }
        public Desconto()
        {
            InitializeComponent();
            label5.Text = valorLabel.ToString();
            this.KeyUp += Desconto_KeyUp;
            this.Shown += (sender, e) => AtualizarSomaTotala();

        }
        private void AtualizarSomaTotala()
        {
            valorLabel = ValorLabel;

        }


        private void Desconto_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se a tecla foi pressionada
            if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Subtract || e.KeyCode == Keys.Divide)
            {
                // Atualiza o valor quando a tecla é pressionada
                AtualizarValor(e.KeyCode);
            }
            else if (e.KeyCode == Keys.Multiply) // Tecla '*'
            {
                // Apenas atualize o valor quando a tecla é pressionada, não quando é liberada
                if (e.Modifiers == Keys.None)
                {
                    AtualizarValor(e.KeyCode);
                }
            }
            else if (e.KeyCode == Keys.Enter) // Tecla 'Enter'
            {
                MessageBox.Show($"Valor da variável valorLabel: {valorLabel}");
                
            }
        }


        private void Desconto_KeyUp(object sender, KeyEventArgs e)
        {
            // Verifica se a tecla foi liberada
            if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Subtract || e.KeyCode == Keys.Multiply || e.KeyCode == Keys.Divide)
            {
                // Se a tecla for liberada, não atualize o valor novamente
                // Isso evita a duplicação

            }
            
        }

        private void AtualizarValor(Keys key)
        {
            if (key == Keys.Add) // Tecla '+'
            {
                valorLabel += 1;
            }
            else if (key == Keys.Subtract) // Tecla '-'
            {
                valorLabel -= 1;
            }
            else if (key == Keys.Multiply) // Tecla '*'
            {
                valorLabel += 10;
            }
            else if (key == Keys.Divide) // Tecla '/'
            {
                valorLabel -= 10;
            }

            desconto = valorLabel.ToString(); // Atribui o valor à variável desconto
            label5.Text = desconto; // Atualiza o Label com o valor e o símbolo '%'
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Desconto_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        




    }
}
