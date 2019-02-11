using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AssApp
{
    public partial class frmAlteraCadastro : Form
    {
        public frmAlteraCadastro()
        {
            InitializeComponent();
        }

        private void CarregaDados()
        {
            string conex = "server =localhost; user id =root; password =; port =3306; database = acompanhamento_financeiro";
            MySqlConnection conn = new MySqlConnection(conex);
            string sql = "SELECT * FROM tb_usuario";
            MySqlCommand cmd = new MySqlCommand(sql, conn);


            conn.Open();
            MySqlDataReader leitor = cmd.ExecuteReader();
            while (leitor.Read())
            {
                txtNome.Text = leitor["usu_nome"].ToString();
                txtEmail.Text = leitor["usu_email"].ToString();
                txtSenha.Text = leitor["usu_senha"].ToString();
                txtConfirSenha.Text = leitor["usu_senha"].ToString();
                mskRG.Text = leitor["usu_rg"].ToString();
                mskNascimento.Text = leitor["usu_nascimento"].ToString();
                if (leitor["usu_sexo"].ToString() == "Masculino")
                {
                    rdbMasc.Checked = true;
                    Usuario.Sexo = "Masculino";
                }
                else if (leitor["usu_sexo"].ToString() == "Feminino")
                {
                    rdbFemin.Checked = true;
                    Usuario.Sexo = "Feminino";
                }
                else
                {
                    Usuario.Sexo = "Outro";
                }
            }
            conn.Close();
        }

        private void frmAlteraCadastro_Load(object sender, EventArgs e)
        {
            CarregaDados();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Usuario.Nome = txtNome.Text;
            Usuario.Email = txtEmail.Text;
            Usuario.RG = mskRG.Text;
            Usuario.Nascimento = mskNascimento.Text;

            if (rdbMasc.Checked == true)
            {
                Usuario.Sexo = "Masculino";
            }
            else if (rdbFemin.Checked == true)
            {
                Usuario.Sexo = "Feminino";
            }
            else
            {
                Usuario.Sexo = "Outro";
            }
            Usuario.Senha = txtSenha.Text;

            if (!txtEmail.Equals("@gmail.com") || !txtEmail.Equals("@hotmail.com") || !txtEmail.Equals("@outlook.com"))
            {
                if (txtConfirSenha.Text == txtSenha.Text)
                {
                    if (!txtNome.Equals("") && !txtEmail.Equals("") && !mskRG.Equals("") && !mskNascimento.Equals("") &&
                        !txtSenha.Equals("") && !txtConfirSenha.Equals(""))
                    {
                        Usuario usu = new Usuario();
                        usu.AlterarDados();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Não deixe nenhum espaço em branco!");
                    }
                }
                else
                {
                    MessageBox.Show("Senhas não coincidem!");
                }
            }
            else
            {
                MessageBox.Show("Email incorreto");
            }
        }

        bool desmascarar;

        private void desmascara1_Click(object sender, EventArgs e)
        {
            if (desmascarar == true)
            {
                txtSenha.UseSystemPasswordChar = false;
                desmascarar = false;
            }
            else
            {
                txtSenha.UseSystemPasswordChar = true;
                desmascarar = true;
            }
        }

        private void btnExclui_Click(object sender, EventArgs e)
        {
            Usuario usu = new Usuario();
            Usuario.Nome = txtNome.Text;

            usu.ExcluiDados();

            Application.Exit();
        }
    }
}
