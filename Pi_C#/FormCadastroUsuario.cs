using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
           // Validação de idade mínima (18 anos)
            if (!ValidarMaioridade(dtpDataNascimento.Value))
            {
                MessageBox.Show("Você deve ter pelo menos 18 anos para se cadastrar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validação de CPF
            if (!ValidarCPF(txtCPF.Text))
            {
                MessageBox.Show("CPF inválido! Digite um CPF válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validação de E-mail
            if (!ValidarEmail(txtEmail.Text))
            {
                MessageBox.Show("E-mail inválido! Digite um e-mail válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=petland_bd;password=;"))
            {
                try
                {
                    conn.Open();
                    string senhaCriptografada = GerarHashSHA256(txtSenha.Text);

                    string query = "INSERT INTO usuarios (nome, sobrenome, data_nascimento, cpf, email, senha, cep, cidade, estado) " +
                                   "VALUES (@nome, @sobrenome, @dataNascimento, @cpf, @email, @senha, @cep, @cidade, @estado)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@sobrenome", txtSobrenome.Text);
                    cmd.Parameters.AddWithValue("@dataNascimento", dtpDataNascimento.Value.Date);
                    cmd.Parameters.AddWithValue("@cpf", txtCPF.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@senha", senhaCriptografada);
                    cmd.Parameters.AddWithValue("@cep", txtCEP.Text);
                    cmd.Parameters.AddWithValue("@cidade", txtCidade.Text);
                    cmd.Parameters.AddWithValue("@estado", txtEstado.Text);

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
        private bool ValidarMaioridade(DateTime dataNascimento)
        {
            int idade = DateTime.Today.Year - dataNascimento.Year;
            if (dataNascimento > DateTime.Today.AddYears(-idade)) idade--;
            return idade >= 18;
        }

        // Método para validar CPF
        private bool ValidarCPF(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", ""); // Remove pontos e traços

            if (cpf.Length != 11 || !cpf.All(char.IsDigit))
                return false;

            string[] cpfsInvalidos = { "00000000000", "11111111111", "22222222222", "33333333333", "44444444444",
                                        "55555555555", "66666666666", "77777777777", "88888888888", "99999999999" };

            if (cpfsInvalidos.Contains(cpf))
                return false;

            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            int digito1 = (resto < 2) ? 0 : (11 - resto);

            tempCpf += digito1;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            int digito2 = (resto < 2) ? 0 : (11 - resto);

            return cpf.EndsWith(digito1.ToString() + digito2.ToString());
        }

        // Método para validar E-mail
        private bool ValidarEmail(string email)
        {
            string padraoEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, padraoEmail);
        }

        // Método para criptografar a senha
        private string GerarHashSHA256(string senha)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(senha);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

		private void dtpDataNascimento_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}