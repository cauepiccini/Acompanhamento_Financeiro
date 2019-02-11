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
    public partial class frmCadastro : Form
    {
        bool desmascarar;

        public frmCadastro()
        {
            InitializeComponent();
        }

        private void picIconeCadastro_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCadastrar_Click(object sender, EventArgs e)
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
                if(txtConfirSenha.Text == txtSenha.Text)
                {
                    if (!txtNome.Equals("") && !txtEmail.Equals("") && !mskRG.Equals("") && !mskNascimento.Equals("") &&
                        !txtSenha.Equals("") && !txtConfirSenha.Equals(""))
                    {
                        Usuario usu = new Usuario();
                        usu.InsereDados();
                        this.Close();
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

        private void desmascara2_Click(object sender, EventArgs e)
        {
            if (desmascarar == true)
            {
                txtConfirSenha.UseSystemPasswordChar = false;
                desmascarar = false;
            }
            else
            {
                txtConfirSenha.UseSystemPasswordChar = true;
                desmascarar = true;
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
