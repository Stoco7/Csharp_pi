using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pi_C_
{
    public partial class FormConfirmaPet : Form
    {
        private int idUsuario;

        private void btnNao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cadastro concluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }

        private void btnSim_Click(object sender, EventArgs e)
        {
            FormCadastroPet formPet = new FormCadastroPet(idUsuario);
            formPet.Show();
            this.Hide();
        }

        public FormConfirmaPet(int idUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
        }

        private void FormConfirmaPet_Load(object sender, EventArgs e)
        {

        }
    }
}
