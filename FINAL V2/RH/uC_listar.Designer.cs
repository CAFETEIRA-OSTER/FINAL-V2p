namespace FINAL_V2.RH
{
    partial class uC_listar
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
            this.components = new System.ComponentModel.Container();
            this.sistemaYigDataSet1 = new FINAL_V2.SistemaYigDataSet();
            this.funcionariosrhTableAdapter = new FINAL_V2.DataSet1TableAdapters.TableAdapterManager();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblConta = new System.Windows.Forms.Label();
            this.lblSalario = new System.Windows.Forms.Label();
            this.lblCtps = new System.Windows.Forms.Label();
            this.lblCpf = new System.Windows.Forms.Label();
            this.lblRg = new System.Windows.Forms.Label();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblTelefone = new System.Windows.Forms.Label();
            this.lblCargo = new System.Windows.Forms.Label();
            this.lblIdade = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.sistemaYigDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.funcionariosrhBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.sistemaYigDataSet1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaYigDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.funcionariosrhBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // sistemaYigDataSet1
            // 
            this.sistemaYigDataSet1.DataSetName = "SistemaYigDataSet";
            this.sistemaYigDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // funcionariosrhTableAdapter
            // 
            this.funcionariosrhTableAdapter.BackupDataSetBeforeUpdate = false;
            this.funcionariosrhTableAdapter.cadastradosTableAdapter = null;
            this.funcionariosrhTableAdapter.cidadeTableAdapter = null;
            this.funcionariosrhTableAdapter.Connection = null;
            this.funcionariosrhTableAdapter.estoqueTableAdapter = null;
            this.funcionariosrhTableAdapter.loginTableAdapter = null;
            this.funcionariosrhTableAdapter.UpdateOrder = FINAL_V2.DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::FINAL_V2.Properties.Resources.listar;
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.lblConta);
            this.panel1.Controls.Add(this.lblSalario);
            this.panel1.Controls.Add(this.lblCtps);
            this.panel1.Controls.Add(this.lblCpf);
            this.panel1.Controls.Add(this.lblRg);
            this.panel1.Controls.Add(this.lblEndereco);
            this.panel1.Controls.Add(this.lblEmail);
            this.panel1.Controls.Add(this.lblTelefone);
            this.panel1.Controls.Add(this.lblCargo);
            this.panel1.Controls.Add(this.lblIdade);
            this.panel1.Controls.Add(this.lblNome);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(966, 474);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(42, 243);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(181, 32);
            this.comboBox1.TabIndex = 64;
            // 
            // lblConta
            // 
            this.lblConta.AutoSize = true;
            this.lblConta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(50)))));
            this.lblConta.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold);
            this.lblConta.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblConta.Location = new System.Drawing.Point(692, 230);
            this.lblConta.Name = "lblConta";
            this.lblConta.Size = new System.Drawing.Size(83, 29);
            this.lblConta.TabIndex = 63;
            this.lblConta.Text = "Nome";
            // 
            // lblSalario
            // 
            this.lblSalario.AutoSize = true;
            this.lblSalario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(50)))));
            this.lblSalario.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold);
            this.lblSalario.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSalario.Location = new System.Drawing.Point(705, 179);
            this.lblSalario.Name = "lblSalario";
            this.lblSalario.Size = new System.Drawing.Size(83, 29);
            this.lblSalario.TabIndex = 62;
            this.lblSalario.Text = "Nome";
            // 
            // lblCtps
            // 
            this.lblCtps.AutoSize = true;
            this.lblCtps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(50)))));
            this.lblCtps.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold);
            this.lblCtps.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCtps.Location = new System.Drawing.Point(686, 129);
            this.lblCtps.Name = "lblCtps";
            this.lblCtps.Size = new System.Drawing.Size(83, 29);
            this.lblCtps.TabIndex = 61;
            this.lblCtps.Text = "Nome";
            // 
            // lblCpf
            // 
            this.lblCpf.AutoSize = true;
            this.lblCpf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(50)))));
            this.lblCpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold);
            this.lblCpf.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCpf.Location = new System.Drawing.Point(673, 80);
            this.lblCpf.Name = "lblCpf";
            this.lblCpf.Size = new System.Drawing.Size(83, 29);
            this.lblCpf.TabIndex = 60;
            this.lblCpf.Text = "Nome";
            // 
            // lblRg
            // 
            this.lblRg.AutoSize = true;
            this.lblRg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(50)))));
            this.lblRg.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold);
            this.lblRg.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRg.Location = new System.Drawing.Point(664, 30);
            this.lblRg.Name = "lblRg";
            this.lblRg.Size = new System.Drawing.Size(83, 29);
            this.lblRg.TabIndex = 59;
            this.lblRg.Text = "Nome";
            this.lblRg.Click += new System.EventHandler(this.lblRg_Click);
            // 
            // lblEndereco
            // 
            this.lblEndereco.AutoSize = true;
            this.lblEndereco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(50)))));
            this.lblEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold);
            this.lblEndereco.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblEndereco.Location = new System.Drawing.Point(371, 280);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(0, 29);
            this.lblEndereco.TabIndex = 58;
            this.lblEndereco.Click += new System.EventHandler(this.lblEndereco_Click);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(50)))));
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblEmail.Location = new System.Drawing.Point(335, 235);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(61, 22);
            this.lblEmail.TabIndex = 57;
            this.lblEmail.Text = "Nome";
            this.lblEmail.Click += new System.EventHandler(this.lblEmail_Click);
            // 
            // lblTelefone
            // 
            this.lblTelefone.AutoSize = true;
            this.lblTelefone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(50)))));
            this.lblTelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold);
            this.lblTelefone.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTelefone.Location = new System.Drawing.Point(362, 180);
            this.lblTelefone.Name = "lblTelefone";
            this.lblTelefone.Size = new System.Drawing.Size(83, 29);
            this.lblTelefone.TabIndex = 56;
            this.lblTelefone.Text = "Nome";
            this.lblTelefone.Click += new System.EventHandler(this.lblTelefone_Click);
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(50)))));
            this.lblCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold);
            this.lblCargo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCargo.Location = new System.Drawing.Point(334, 130);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(83, 29);
            this.lblCargo.TabIndex = 55;
            this.lblCargo.Text = "Nome";
            // 
            // lblIdade
            // 
            this.lblIdade.AutoSize = true;
            this.lblIdade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(50)))));
            this.lblIdade.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold);
            this.lblIdade.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblIdade.Location = new System.Drawing.Point(334, 80);
            this.lblIdade.Name = "lblIdade";
            this.lblIdade.Size = new System.Drawing.Size(83, 29);
            this.lblIdade.TabIndex = 54;
            this.lblIdade.Text = "Nome";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(50)))));
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold);
            this.lblNome.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNome.Location = new System.Drawing.Point(334, 30);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(83, 29);
            this.lblNome.TabIndex = 53;
            this.lblNome.Text = "Nome";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox2.Location = new System.Drawing.Point(42, 48);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(181, 175);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 51;
            this.pictureBox2.TabStop = false;
            // 
            // uC_listar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "uC_listar";
            this.Size = new System.Drawing.Size(966, 474);
            ((System.ComponentModel.ISupportInitialize)(this.sistemaYigDataSet1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaYigDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.funcionariosrhBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SistemaYigDataSet sistemaYigDataSet1;
        private System.Windows.Forms.BindingSource sistemaYigDataSetBindingSource;
        private System.Windows.Forms.BindingSource funcionariosrhBindingSource;
        private DataSet1TableAdapters.TableAdapterManager funcionariosrhTableAdapter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblConta;
        private System.Windows.Forms.Label lblSalario;
        private System.Windows.Forms.Label lblCtps;
        private System.Windows.Forms.Label lblCpf;
        private System.Windows.Forms.Label lblRg;
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblTelefone;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.Label lblIdade;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
