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
    public partial class frmEntrada : Form
    {
        public frmEntrada()
        {
            InitializeComponent();
        }

        private void frmEntrada_Load(object sender, EventArgs e)
        {
            pnlAlterarGanho.Visible = false;
            pnlGanho.Visible = true;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            pnlAlterarGanho.Visible = false;
            pnlGanho.Visible = true;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            CarregaGanho();
            pnlAlterarGanho.Visible = true;
            pnlGanho.Visible = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Contador.Ganho = txtGanho.Text;
            Contador.GanhoData = mskData.Text;

            Contador cont = new Contador();

            cont.InsereGanho();
            pnlGanho.Visible = false;
            pnlAlterarGanho.Visible = false;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtGanho.Text = "";
            mskData.Text = "";
        }

        private void btnAltera_Click(object sender, EventArgs e)
        {
            Contador.Ganho = txtGanho.Text;
            Contador.GanhoData = mskAlteraData.Text;

            Contador cont = new Contador();

            cont.AlterarGanho();
            pnlGanho.Visible = false;
            pnlAlterarGanho.Visible = false;
        }

        private void btnAltLimpar_Click(object sender, EventArgs e)
        {
            txtAltGanho.Text = "";
            mskAlteraData.Text = "";
        }

        private void CarregaGanho()
        {
            string conex = "server =localhost; user id =root; password =; port =3306; database = acompanhamento_financeiro";
            MySqlConnection conn = new MySqlConnection(conex);
            string sql = "SELECT con_ganho, con_data from tb_contganho";
            MySqlCommand cmd = new MySqlCommand(sql, conn);


            conn.Open();
            MySqlDataReader leitor = cmd.ExecuteReader();
            while (leitor.Read())
            {
                txtAltGanho.Text = leitor["con_ganho"].ToString();
                mskAlteraData.Text = leitor["con_data"].ToString();
            }
            conn.Close();
        }
    }
}
