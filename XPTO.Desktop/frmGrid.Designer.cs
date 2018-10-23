namespace XPTO.Desktop
{
    partial class frmGrid
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvCaixas = new System.Windows.Forms.DataGridView();
            this.Pos01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pos02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pos03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pos04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pos05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pos06 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaixas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCaixas
            // 
            this.dgvCaixas.AllowUserToAddRows = false;
            this.dgvCaixas.AllowUserToDeleteRows = false;
            this.dgvCaixas.AllowUserToResizeRows = false;
            this.dgvCaixas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCaixas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCaixas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaixas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pos01,
            this.pos02,
            this.pos03,
            this.Pos04,
            this.pos05,
            this.Pos06});
            this.dgvCaixas.Location = new System.Drawing.Point(13, 13);
            this.dgvCaixas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCaixas.MultiSelect = false;
            this.dgvCaixas.Name = "dgvCaixas";
            this.dgvCaixas.RowHeadersVisible = false;
            this.dgvCaixas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCaixas.Size = new System.Drawing.Size(855, 390);
            this.dgvCaixas.TabIndex = 6;
            // 
            // Pos01
            // 
            this.Pos01.HeaderText = "Primeiro Nome";
            this.Pos01.Name = "Pos01";
            this.Pos01.Width = 130;
            // 
            // pos02
            // 
            this.pos02.HeaderText = "Segundo Nome";
            this.pos02.Name = "pos02";
            this.pos02.Width = 124;
            // 
            // pos03
            // 
            this.pos03.HeaderText = "Sexo";
            this.pos03.Name = "pos03";
            this.pos03.Width = 68;
            // 
            // Pos04
            // 
            this.Pos04.HeaderText = "Email";
            this.Pos04.Name = "Pos04";
            this.Pos04.Width = 71;
            // 
            // pos05
            // 
            this.pos05.HeaderText = "Data Nascimento";
            this.pos05.Name = "pos05";
            this.pos05.Width = 133;
            // 
            // Pos06
            // 
            this.Pos06.HeaderText = "Produto";
            this.Pos06.Name = "Pos06";
            this.Pos06.Width = 87;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(794, 410);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 41);
            this.button1.TabIndex = 7;
            this.button1.Text = "Sair";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 473);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvCaixas);
            this.Name = "frmGrid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visulizar Informação ";
            this.Load += new System.EventHandler(this.frmGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaixas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCaixas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pos01;
        private System.Windows.Forms.DataGridViewTextBoxColumn pos02;
        private System.Windows.Forms.DataGridViewTextBoxColumn pos03;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pos04;
        private System.Windows.Forms.DataGridViewTextBoxColumn pos05;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pos06;
        private System.Windows.Forms.Button button1;
    }
}