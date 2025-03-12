using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Pi_C_
{
    public partial class FormCadastroUsuario : Form
    {
        public FormCadastroUsuario()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormCadastroUsuario_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=teste_c#_pi;password=;"))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO usuarios (nome, sobrenome, cpf, email, senha, cep, estado, cidade, dataNascimento) " +
                                   "VALUES (@nome, @sobrenome, @cpf, @email, @senha, @cep, @estado, @cidade, @dataNascimento)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@sobrenome", txtSobrenome.Text);
                    cmd.Parameters.AddWithValue("@cpf", txtCPF.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@cep", txtCEP.Text);
                    cmd.Parameters.AddWithValue("@senha", txtSenha.Text);
                    cmd.Parameters.AddWithValue("@estado", txtEstado.Text);
                    cmd.Parameters.AddWithValue("@cidade", txtCidade.Text);
                    cmd.Parameters.AddWithValue("@dataNascimento", dtpDataNascimento.Value.Date);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Usuário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Pegando o ID do usuário cadastrado
                    cmd = new MySqlCommand("SELECT LAST_INSERT_ID()", conn);
                    int idUsuario = Convert.ToInt32(cmd.ExecuteScalar());

                    // Abrir tela de confirmação do pet
                    FormConfirmaPet confirmaPet = new FormConfirmaPet(idUsuario);
                    confirmaPet.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar usuário: " + ex.Message);
                }
            }
        }

        private void dtpDataNascimento_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
