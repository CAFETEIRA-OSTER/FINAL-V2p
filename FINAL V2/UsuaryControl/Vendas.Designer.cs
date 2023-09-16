namespace FINAL_V2.UsuaryControl
{
    partial class Vendas
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preço = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D = new System.Windows.Forms.DataGridView();
            this.Unidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPreçoTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Lblpagar = new System.Windows.Forms.Label();
            this.btnImprimirFatura = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnLimparCu = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtUnidade = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtquantidade = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNomeLivro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.IdLivro = new System.Windows.Forms.Label();
            this.txtIDLivro = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.D)).BeginInit();
            this.SuspendLayout();
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.MinimumWidth = 6;
            this.Total.Name = "Total";
            this.Total.Width = 125;
            // 
            // Preço
            // 
            this.Preço.HeaderText = "Preço";
            this.Preço.MinimumWidth = 6;
            this.Preço.Name = "Preço";
            this.Preço.Width = 125;
            // 
            // Nome
            // 
            this.Nome.HeaderText = "Nome";
            this.Nome.MinimumWidth = 6;
            this.Nome.Name = "Nome";
            this.Nome.Width = 125;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Width = 125;
            // 
            // D
            // 
            this.D.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.D.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Nome,
            this.Preço,
            this.Unidade,
            this.Total});
            this.D.Location = new System.Drawing.Point(150, 225);
            this.D.Margin = new System.Windows.Forms.Padding(2);
            this.D.Name = "D";
            this.D.RowHeadersWidth = 51;
            this.D.RowTemplate.Height = 24;
            this.D.Size = new System.Drawing.Size(771, 150);
            this.D.TabIndex = 54;
            this.D.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.D_CellClick_1);
            // 
            // Unidade
            // 
            this.Unidade.HeaderText = "Unidade";
            this.Unidade.MinimumWidth = 6;
            this.Unidade.Name = "Unidade";
            this.Unidade.Width = 125;
            // 
            // txtPreçoTotal
            // 
            this.txtPreçoTotal.Location = new System.Drawing.Point(493, 151);
            this.txtPreçoTotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtPreçoTotal.Name = "txtPreçoTotal";
            this.txtPreçoTotal.Size = new System.Drawing.Size(76, 20);
            this.txtPreçoTotal.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(491, 134);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 52;
            this.label5.Text = "Preço Total";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(26, 28);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(109, 420);
            this.listBox1.TabIndex = 51;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            // 
            // Lblpagar
            // 
            this.Lblpagar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Lblpagar.Location = new System.Drawing.Point(448, 399);
            this.Lblpagar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lblpagar.Name = "Lblpagar";
            this.Lblpagar.Size = new System.Drawing.Size(75, 19);
            this.Lblpagar.TabIndex = 50;
            this.Lblpagar.Text = "label5";
            this.Lblpagar.Click += new System.EventHandler(this.Lblpagar_Click);
            // 
            // btnImprimirFatura
            // 
            this.btnImprimirFatura.Location = new System.Drawing.Point(540, 399);
            this.btnImprimirFatura.Margin = new System.Windows.Forms.Padding(2);
            this.btnImprimirFatura.Name = "btnImprimirFatura";
            this.btnImprimirFatura.Size = new System.Drawing.Size(92, 19);
            this.btnImprimirFatura.TabIndex = 49;
            this.btnImprimirFatura.Text = "Imprimir Fatura";
            this.btnImprimirFatura.UseVisualStyleBackColor = true;
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(347, 399);
            this.btnRemover.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(75, 20);
            this.btnRemover.TabIndex = 48;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(491, 195);
            this.btnAdicionar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(110, 25);
            this.btnAdicionar.TabIndex = 47;
            this.btnAdicionar.Text = "Adicionar no Carrinho";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnLimparCu
            // 
            this.btnLimparCu.Location = new System.Drawing.Point(360, 195);
            this.btnLimparCu.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimparCu.Name = "btnLimparCu";
            this.btnLimparCu.Size = new System.Drawing.Size(83, 26);
            this.btnLimparCu.TabIndex = 46;
            this.btnLimparCu.Text = "Limpar Cuppon";
            this.btnLimparCu.UseVisualStyleBackColor = true;
            this.btnLimparCu.Click += new System.EventHandler(this.btnLimparCu_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(360, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "ID do Livro";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(360, 61);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(85, 20);
            this.textBox1.TabIndex = 44;
            // 
            // txtUnidade
            // 
            this.txtUnidade.Location = new System.Drawing.Point(491, 111);
            this.txtUnidade.Margin = new System.Windows.Forms.Padding(2);
            this.txtUnidade.Name = "txtUnidade";
            this.txtUnidade.Size = new System.Drawing.Size(76, 20);
            this.txtUnidade.TabIndex = 43;
            this.txtUnidade.TextChanged += new System.EventHandler(this.txtUnidade_TextChanged_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(488, 96);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "Unidade";
            // 
            // txtquantidade
            // 
            this.txtquantidade.Location = new System.Drawing.Point(491, 61);
            this.txtquantidade.Margin = new System.Windows.Forms.Padding(2);
            this.txtquantidade.Name = "txtquantidade";
            this.txtquantidade.Size = new System.Drawing.Size(76, 20);
            this.txtquantidade.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(488, 44);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Preço por Unidade";
            // 
            // txtNomeLivro
            // 
            this.txtNomeLivro.Location = new System.Drawing.Point(362, 111);
            this.txtNomeLivro.Margin = new System.Windows.Forms.Padding(2);
            this.txtNomeLivro.Name = "txtNomeLivro";
            this.txtNomeLivro.Size = new System.Drawing.Size(76, 20);
            this.txtNomeLivro.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(360, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Nome Do Livro";
            // 
            // IdLivro
            // 
            this.IdLivro.AutoSize = true;
            this.IdLivro.ForeColor = System.Drawing.Color.White;
            this.IdLivro.Location = new System.Drawing.Point(195, 44);
            this.IdLivro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.IdLivro.Name = "IdLivro";
            this.IdLivro.Size = new System.Drawing.Size(59, 13);
            this.IdLivro.TabIndex = 36;
            this.IdLivro.Text = "ID do Livro";
            // 
            // txtIDLivro
            // 
            this.txtIDLivro.Location = new System.Drawing.Point(184, 72);
            this.txtIDLivro.Margin = new System.Windows.Forms.Padding(2);
            this.txtIDLivro.Name = "txtIDLivro";
            this.txtIDLivro.Size = new System.Drawing.Size(85, 20);
            this.txtIDLivro.TabIndex = 35;
            this.txtIDLivro.TextChanged += new System.EventHandler(this.txtIDLivro_TextChanged);
            this.txtIDLivro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIDLivro_KeyDown);
            // 
            // Vendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.D);
            this.Controls.Add(this.txtPreçoTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.Lblpagar);
            this.Controls.Add(this.btnImprimirFatura);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.btnLimparCu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtUnidade);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtquantidade);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNomeLivro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IdLivro);
            this.Controls.Add(this.txtIDLivro);
            this.Name = "Vendas";
            this.Size = new System.Drawing.Size(963, 478);
            this.Load += new System.EventHandler(this.Vendas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.D)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Preço;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridView D;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidade;
        private System.Windows.Forms.TextBox txtPreçoTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label Lblpagar;
        private System.Windows.Forms.Button btnImprimirFatura;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnLimparCu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtUnidade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtquantidade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNomeLivro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label IdLivro;
        private System.Windows.Forms.TextBox txtIDLivro;
    }
}
