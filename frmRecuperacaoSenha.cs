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
    public partial class frmRecuperacaoSenha : Form
    {
        public frmRecuperacaoSenha()
        {
            InitializeComponent();
        }

        private void btnAlteraSenha_Click(object sender, EventArgs e)
        {
            string conex = "server =localhost; user id =root; password =; port =3306; database = acompanhamento_financeiro";
            MySqlConnection cnx = new MySqlConnection(conex);

            string comand = "SELECT usu_senha FROM tb_usuario WHERE usu_email = '" + txtRecuperaSenha.Text + "';";
            MySqlDataAdapter da = new MySqlDataAdapter(comand, cnx);

            DataTable recupera = new DataTable();
            da.Fill(recupera);

            if (recupera.Rows.Count == 1)
            {
                frmAlteraSenha altera = new frmAlteraSenha();
                altera.Show();
            }
            else
            {
                MessageBox.Show("Nenhum Usuário encontrado!");
            }

            this.Close();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
