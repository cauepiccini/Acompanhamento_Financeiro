using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AssApp
{
    public partial class frmPrincipal : Form
    {
        bool desmascarar;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            frmCadastro cadastro = new frmCadastro();
            cadastro.Show();
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            Usuario usu = new Usuario();

            Usuario.Email = txtEmail.Text;
            Usuario.Senha = txtSenha.Text;

            bool logado = usu.PegarDados();
            if (logado == true)
            {
                frmMenu menu = new frmMenu();
                menu.Email = txtEmail.Text;
                this.Hide();
                menu.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuario e/ou Senha incorreto(s)");
            }
        }

        private void lnkEsqueceuSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRecuperacaoSenha RecSenha = new frmRecuperacaoSenha();
            RecSenha.Show();
        }

        private void btnVer_Click(object sender, EventArgs e)
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

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogar.Focus();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSenha.Focus();
            }
        }
    }
}
