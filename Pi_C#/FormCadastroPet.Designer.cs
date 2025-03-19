namespace Pi_C_
{
    partial class FormCadastroPet
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
            this.Nome = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNomePet = new System.Windows.Forms.TextBox();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.cmbTipoAnimal = new System.Windows.Forms.ComboBox();
            this.cmbSexo = new System.Windows.Forms.ComboBox();
            this.btnCadastrarPet = new System.Windows.Forms.Button();
            this.btnSelecionarFoto = new System.Windows.Forms.Button();
            this.pbFotoPet = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDataNascimentopet = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoPet)).BeginInit();
            this.SuspendLayout();
            // 
            // Nome
            // 
            this.Nome.AutoSize = true;
            this.Nome.Location = new System.Drawing.Point(102, 61);
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(35, 13);
            this.Nome.TabIndex = 0;
            this.Nome.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo de Animal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sexo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(106, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Peso";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Data de nascimento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(109, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Foto";
            // 
            // txtNomePet
            // 
            this.txtNomePet.Location = new System.Drawing.Point(143, 58);
            this.txtNomePet.Name = "txtNomePet";
            this.txtNomePet.Size = new System.Drawing.Size(121, 20);
            this.txtNomePet.TabIndex = 6;
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(143, 166);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(121, 20);
            this.txtPeso.TabIndex = 7;
            // 
            // cmbTipoAnimal
            // 
            this.cmbTipoAnimal.FormattingEnabled = true;
            this.cmbTipoAnimal.Location = new System.Drawing.Point(143, 93);
            this.cmbTipoAnimal.Name = "cmbTipoAnimal";
            this.cmbTipoAnimal.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoAnimal.TabIndex = 9;
            this.cmbTipoAnimal.SelectedIndexChanged += new System.EventHandler(this.cmbTipoAnimal_SelectedIndexChanged);
            // 
            // cmbSexo
            // 
            this.cmbSexo.FormattingEnabled = true;
            this.cmbSexo.Location = new System.Drawing.Point(143, 129);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(121, 21);
            this.cmbSexo.TabIndex = 10;
            // 
            // btnCadastrarPet
            // 
            this.btnCadastrarPet.Location = new System.Drawing.Point(105, 337);
            this.btnCadastrarPet.Name = "btnCadastrarPet";
            this.btnCadastrarPet.Size = new System.Drawing.Size(201, 26);
            this.btnCadastrarPet.TabIndex = 11;
            this.btnCadastrarPet.Text = "Cadastrar";
            this.btnCadastrarPet.UseVisualStyleBackColor = true;
            this.btnCadastrarPet.Click += new System.EventHandler(this.btnCadastrarPet_Click);
            // 
            // btnSelecionarFoto
            // 
            this.btnSelecionarFoto.Location = new System.Drawing.Point(143, 299);
            this.btnSelecionarFoto.Name = "btnSelecionarFoto";
            this.btnSelecionarFoto.Size = new System.Drawing.Size(121, 23);
            this.btnSelecionarFoto.TabIndex = 12;
            this.btnSelecionarFoto.Text = "Selecionar Foto";
            this.btnSelecionarFoto.UseVisualStyleBackColor = true;
            this.btnSelecionarFoto.Click += new System.EventHandler(this.btnSelecionarFoto_Click);
            // 
            // pbFotoPet
            // 
            this.pbFotoPet.Location = new System.Drawing.Point(143, 243);
            this.pbFotoPet.Name = "pbFotoPet";
            this.pbFotoPet.Size = new System.Drawing.Size(121, 50);
            this.pbFotoPet.TabIndex = 13;
            this.pbFotoPet.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Cadastro Pet";
            // 
            // dtpDataNascimentopet
            // 
            this.dtpDataNascimentopet.Location = new System.Drawing.Point(143, 203);
            this.dtpDataNascimentopet.Name = "dtpDataNascimentopet";
            this.dtpDataNascimentopet.Size = new System.Drawing.Size(200, 20);
            this.dtpDataNascimentopet.TabIndex = 15;
            this.dtpDataNascimentopet.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // FormCadastroPet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 414);
            this.Controls.Add(this.dtpDataNascimentopet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbFotoPet);
            this.Controls.Add(this.btnSelecionarFoto);
            this.Controls.Add(this.btnCadastrarPet);
            this.Controls.Add(this.cmbSexo);
            this.Controls.Add(this.cmbTipoAnimal);
            this.Controls.Add(this.txtPeso);
            this.Controls.Add(this.txtNomePet);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Nome);
            this.Name = "FormCadastroPet";
            this.Text = "FormCadastroPet";
            this.Load += new System.EventHandler(this.FormCadastroPet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoPet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Nome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNomePet;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.ComboBox cmbTipoAnimal;
        private System.Windows.Forms.ComboBox cmbSexo;
        private System.Windows.Forms.Button btnCadastrarPet;
        private System.Windows.Forms.Button btnSelecionarFoto;
        private System.Windows.Forms.PictureBox pbFotoPet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDataNascimentopet;
    }
}