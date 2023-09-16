using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINAL_V2.UsuaryControl
{
    public partial class Vendas : UserControl
    {

        private decimal preçototal = 0.0m; // Declare como decimal em vez de int

        Função fx = new Função();
        String consulta;
        DataSet ds;
        protected Int64 quantidade, novaquantidade;
        protected int n;
        String Valorid;
        int valorpago;
        protected Int64 numUnit;
        protected Int64 numValor;

        public Vendas()
        {
            InitializeComponent();
           

            

        }

        private void Vendas_Load(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            consulta = "select Nome from Estoque where Quantidade >'0'";
            ds = fx.GetData(consulta);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }


        


        private void D_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (D.Rows[e.RowIndex].Cells[4].Value != null)
                {
                    valorpago = int.Parse(D.Rows[e.RowIndex].Cells[4].Value.ToString());
                }

                if (D.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    Valorid = D.Rows[e.RowIndex].Cells[0].Value.ToString();
                }

                if (D.Rows[e.RowIndex].Cells[3].Value != null)
                {
                    numUnit = Int64.Parse(D.Rows[e.RowIndex].Cells[3].Value.ToString());
                }
            }
            catch (Exception)
            {

            }
        }

        private void AdicionarLivroAoDataGridView()
        {
            string idLivro = txtIDLivro.Text;

            // Verifique se o produto já está no DataGridView
            foreach (DataGridViewRow row in D.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == idLivro)
                {
                    // Produto com o mesmo "lid" encontrado no DataGridView, incremente a quantidade existente
                    int quantidadeExistente;
                    if (int.TryParse(row.Cells[2].Value.ToString(), out quantidadeExistente))
                    {
                        // O valor foi analisado com sucesso, agora você pode usá-lo
                        int novaQuantidade = quantidadeExistente + 1;

                        // Atualize a quantidade no DataGridView
                        row.Cells[2].Value = novaQuantidade;

                        // Atualize a quantidade total no DataGridView
                        decimal precoUnitario = decimal.Parse(row.Cells[3].Value.ToString());
                        decimal novoPrecoTotal = precoUnitario * novaQuantidade;
                        row.Cells[4].Value = novoPrecoTotal.ToString("0.00"); // Formata para duas casas decimais

                        // Atualize a label com o novo total
                        preçototal += precoUnitario;
                        Lblpagar.Text = "R$" + preçototal.ToString("0.00"); // Formata para duas casas decimais

                        // Não é necessário atualizar a quantidade no banco de dados neste ponto
                        return;
                    }
                    else
                    {
                        // Lidar com o caso em que o valor não é um número válido
                        MessageBox.Show("A quantidade existente não é um número válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Saia da função para evitar adicionar novamente
                    }
                }
            }

            // Se não encontrou o produto no DataGridView, realize a consulta
            consulta = "select lid, Nome, Quantidade, Preço from Estoque where lid = '" + idLivro + "'";
            ds = fx.GetData(consulta);

            if (ds.Tables[0].Rows.Count > 0)
            {
                int n = D.Rows.Add();
                D.Rows[n].Cells[0].Value = ds.Tables[0].Rows[0]["lid"].ToString();
                D.Rows[n].Cells[1].Value = ds.Tables[0].Rows[0]["Nome"].ToString();
                D.Rows[n].Cells[2].Value = "1"; // Inicializa com 1 unidade
                D.Rows[n].Cells[3].Value = ds.Tables[0].Rows[0]["Preço"].ToString(); // Preço unitário

                // Atualize a quantidade disponível do livro no banco de dados
                long novaQuantidade = Int64.Parse(ds.Tables[0].Rows[0]["Quantidade"].ToString()) - 1;
                consulta = "update Estoque set Quantidade=" + novaQuantidade + " where lid ='" + idLivro + "'";
                fx.SetData(consulta, "Livro adicionado na compra");

                // Calcula o preço total para a nova linha
                decimal precoUnitario = decimal.Parse(ds.Tables[0].Rows[0]["Preço"].ToString());
                decimal precoTotal = precoUnitario * 1; // 1 unidade
                D.Rows[n].Cells[4].Value = precoTotal.ToString("0.00"); // Formata para duas casas decimais

                // Atualize a label com o novo total
                preçototal += precoTotal;
                Lblpagar.Text = "R$" + preçototal.ToString("0.00"); // Formata para duas casas decimais
            }
            else
            {
                MessageBox.Show("Livro não encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Limpe o campo de texto
            txtIDLivro.Clear();
        }






        private void btnLimparCu_Click_1(object sender, EventArgs e)
        {
            limpar();
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            txtUnidade.Clear();
            String nome = listBox1.GetItemText(listBox1.SelectedItem);
            txtNomeLivro.Text = nome;
            consulta = "select lid, Preço from Estoque where Nome='" + nome + "'";
            ds = fx.GetData(consulta);
            textBox1.Text = ds.Tables[0].Rows[0][0].ToString();
            txtquantidade.Text = ds.Tables[0].Rows[0][1].ToString();
        }


        

        // ...

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                consulta = "select Quantidade from Estoque where lid ='" + textBox1.Text + "'";
                ds = fx.GetData(consulta);

                // Verifique se o DataSet contém pelo menos uma linha.
                if (ds.Tables[0].Rows.Count > 0)
                {
                    quantidade = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                    decimal precoTotal;

                    if (decimal.TryParse(txtPreçoTotal.Text, out precoTotal) && precoTotal >= 0)
                    {
                        novaquantidade = quantidade - Int64.Parse(txtUnidade.Text);

                        if (novaquantidade >= 0)
                        {
                            n = D.Rows.Add();
                            D.Rows[n].Cells[0].Value = textBox1.Text;
                            D.Rows[n].Cells[1].Value = txtNomeLivro.Text;
                            D.Rows[n].Cells[2].Value = txtquantidade.Text;
                            D.Rows[n].Cells[3].Value = txtUnidade.Text;

                            // Formate o preço total com duas casas decimais
                            D.Rows[n].Cells[4].Value = precoTotal.ToString("0.00");

                            preçototal += precoTotal;
                            Lblpagar.Text = "R$" + preçototal.ToString("0.00"); // Formate o total como moeda

                            consulta = "update Estoque set Quantidade=" + novaquantidade + " where lid ='" + textBox1.Text + "'";

                        }
                        else
                        {
                            MessageBox.Show("Livro fora de Estoque. \n Existe somente:" + quantidade + "", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Preço total inválido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // Lide com o caso em que o DataSet está vazio, por exemplo, mostrando uma mensagem de erro.
                    MessageBox.Show("Não foi possível encontrar informações do livro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Livro não selecionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtUnidade_TextChanged_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUnidade.Text))
            {
                if (decimal.TryParse(txtquantidade.Text, out decimal Punit) && decimal.TryParse(txtUnidade.Text, out decimal Nunit))
                {
                    decimal Tpagar = (Punit * Nunit) / 100; // Divida por 100 para obter o valor correto em reais
                    txtPreçoTotal.Text = Tpagar.ToString("0.00"); // Formatar o resultado como moeda (duas casas decimais)
                }
                else
                {
                    // Lidar com entrada inválida, por exemplo, mostrar uma mensagem de erro
                    // e limpar o campo txtPreçoTotal.
                    txtPreçoTotal.Clear();
                }
            }
            else
            {
                txtPreçoTotal.Clear();
            }
        }


        public void limpar()
        {
            textBox1.Clear();
            txtNomeLivro.Clear();
            txtquantidade.Clear();
            txtUnidade.Clear();
            txtPreçoTotal.Clear();

        }

        private void txtIDLivro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AdicionarLivroAoDataGridView();
            }
        }

        private void Lblpagar_Click(object sender, EventArgs e)
        {

        }

        private void txtIDLivro_TextChanged(object sender, EventArgs e)
        {

        }

        







    }
}
