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
        private int idUsuario;
        private string caminhoImagem = "";

        private void btnCadastrarPet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomePet.Text) || cmbTipoAnimal.SelectedItem == null ||
                cmbSexo.SelectedItem == null || string.IsNullOrWhiteSpace(txtPeso.Text) ||
                string.IsNullOrWhiteSpace(txtIdade.Text) || string.IsNullOrWhiteSpace(caminhoImagem))
            {
                MessageBox.Show("Preencha todos os campos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            byte[] imagemBytes = File.ReadAllBytes(caminhoImagem);

            using (MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=CadastroPetDB;password=;"))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Pets (idUsuario, nomePet, tipoAnimal, sexo, peso, idade, foto) " +
                                   "VALUES (@idUsuario, @nomePet, @tipoAnimal, @sexo, @peso, @idade, @foto)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@nomePet", txtNomePet.Text);
                    cmd.Parameters.AddWithValue("@tipoAnimal", cmbTipoAnimal.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@sexo", cmbSexo.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@peso", Convert.ToDecimal(txtPeso.Text));
                    cmd.Parameters.AddWithValue("@idade", Convert.ToInt32(txtIdade.Text));
                    cmd.Parameters.AddWithValue("@foto", imagemBytes);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Pet cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar pet: " + ex.Message);
                }
            }
        }

        private void btnSelecionarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                caminhoImagem = ofd.FileName;
                pbFotoPet.ImageLocation = caminhoImagem;
            }
        }

        
        public FormCadastroPet(int idUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;

            cmbTipoAnimal.Items.AddRange(new string[] { "Cachorro", "Gato", "Pássaro", "Peixe", "Outro" });
            cmbSexo.Items.AddRange(new string[] { "Macho", "Fêmea" });
        }

        private void FormCadastroPet_Load(object sender, EventArgs e)
        {

        }
    }
}
