using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Pi_C_
{
    public partial class FormCadastroPet : Form
    {
        private int id_dono;
        private string caminhoImagem = "";

        private void btnCadastrarPet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomePet.Text) || cmbTipoAnimal.SelectedItem == null ||
                cmbSexo.SelectedItem == null || string.IsNullOrWhiteSpace(txtPeso.Text) ||
                string.IsNullOrWhiteSpace(caminhoImagem))
            {
                MessageBox.Show("Preencha todos os campos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Convertendo peso com validação
            if (!decimal.TryParse(txtPeso.Text, out decimal peso))
            {
                MessageBox.Show("Peso inválido! Digite um valor numérico.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] imagemBytes = File.ReadAllBytes(caminhoImagem);

            using (MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=petland_bd;password=;"))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO pets_cadastrados (nome, tipo, sexo, peso, data_nascimento, imagem, id_dono) " +
                                   "VALUES (@nome, @tipo, @sexo, @peso, @dataNascimento, @imagem, @id_dono)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nome", txtNomePet.Text);
                    cmd.Parameters.AddWithValue("@tipo", cmbTipoAnimal.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@sexo", cmbSexo.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@peso", peso);
                    cmd.Parameters.AddWithValue("@dataNascimento", dtpDataNascimentopet.Value.Date);
                    cmd.Parameters.AddWithValue("@imagem", imagemBytes);
                    cmd.Parameters.AddWithValue("@id_dono", id_dono);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Pet cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar pet: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSelecionarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                caminhoImagem = ofd.FileName;
                pbFotoPet.Image = Image.FromFile(caminhoImagem); // Exibe a imagem corretamente
            }
        }

        
        public FormCadastroPet(int id_dono)
        {
            InitializeComponent();
            this.id_dono = id_dono;

            cmbTipoAnimal.Items.AddRange(new string[] { "Cachorro", "Gato", "Pássaro", "Peixe", "Outro" });
            cmbSexo.Items.AddRange(new string[] { "Macho", "Fêmea" });
        }

        private void FormCadastroPet_Load(object sender, EventArgs e)
        {

        }

        private void cmbTipoAnimal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
