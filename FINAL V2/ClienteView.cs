using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FINAL_V2.Vendas;

namespace FINAL_V2
{
    public partial class ClienteView : Form
    {
        public ClienteView()
        {
            InitializeComponent();

            // Configurar o intervalo do Timer para 1000 milissegundos (1 segundo)
            timer1.Interval = 1000;  // Defina o intervalo de acordo com a sua necessidade

            // Assine o evento Tick do Timer
            timer1.Tick += Timer1_Tick;

            // Iniciar o Timer
            timer1.Start();

        }

        // Suponha que você já tenha uma instância criada
        
        private void Timer1_Tick(object sender, EventArgs e)
        {
            
        }

        






        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }

}
