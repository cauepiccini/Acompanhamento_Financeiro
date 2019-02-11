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
    public partial class frmAlteraSenha : Form
    {
        public frmAlteraSenha()
        {
            InitializeComponent();
        }

        private void btnAlteraSenha_Click(object sender, EventArgs e)
        {
          if (txtConfirmaSenha.Text.Equals(txtNovaSenha.Text))
            {
                string conex = "server =localhost; user id =root; password =; port =3306; database = acompanhamento_financeiro";
                MySqlConnection cnx = new MySqlConnection(conex);

                string comando = "UPDATE tb_usuario SET usu_senha='" + txtNovaSenha.Text + "';";
                MySqlCommand cmd = new MySqlCommand(comando, cnx);
                cnx.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Alterado com sucesso!!!");
                cnx.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Os campos não coincidem! Verifique e tente novamente");
            }
        }

        bool desmascarar;

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (desmascarar == true)
            {
                txtNovaSenha.UseSystemPasswordChar = false;
                desmascarar = false;
            }
            else
            {
                txtNovaSenha.UseSystemPasswordChar = true;
                desmascarar = true;
            }
        }

        private void btnMostra_Click(object sender, EventArgs e)
        {
            if (desmascarar == true)
            {
                txtConfirmaSenha.UseSystemPasswordChar = false;
                desmascarar = false;
            }
            else
            {
                txtConfirmaSenha.UseSystemPasswordChar = true;
                desmascarar = true;
            }
        }
    }
}
