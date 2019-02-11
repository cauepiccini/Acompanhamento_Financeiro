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
    public partial class frmFixos : Form
    {
        public frmFixos()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Contador.ContAgua = txtAgua.Text;
            Contador.ContGas = txtGas.Text;
            Contador.ContGaso = txtGaso.Text;
            Contador.ContLuz = txtLuz.Text;
            Contador.ContOut = txtOut.Text;
            Contador.ContTele = txtTele.Text;
            Contador.ContTelevisao = txtTelevi.Text;
            Contador.ContaData = mskData.Text;

            Contador cont = new Contador();

            cont.InsereContas();

            pnlContas.Visible = false;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtAgua.Text = "";
            txtGas.Text = "";
            txtGaso.Text = "";
            txtLuz.Text = "";
            txtOut.Text = "";
            txtTele.Text = "";
            txtTelevi.Text = "";
            mskData.Text = "";
        }

        private void CarregaContas()
        {
            string conex = "server =localhost; user id =root; password =; port =3306; database = acompanhamento_financeiro";
            MySqlConnection conn = new MySqlConnection(conex);
            string sql = "SELECT con_agua, con_telefone, con_out, con_luz, con_gaso, con_gas," +
            "con_televisao, con_data from tb_contcontas";
            MySqlCommand cmd = new MySqlCommand(sql, conn);


            conn.Open();
            MySqlDataReader leitor = cmd.ExecuteReader();
            while (leitor.Read())
            {
                txtAlteraAgua.Text = leitor["con_agua"].ToString();
                txtAlteraOut.Text = leitor["con_out"].ToString();
                txtAlteraTelevis.Text = leitor["con_televisao"].ToString();
                txtAlteraGas.Text = leitor["con_gas"].ToString();
                txtAlteraGaso.Text = leitor["con_gaso"].ToString();
                txtAlteraTele.Text = leitor["con_telefone"].ToString();
                txtAlteraLuz.Text = leitor["con_luz"].ToString();
                mskAlteraData.Text = leitor["con_data"].ToString();
            }
            conn.Close();
        }

        private void btnAltera_Click(object sender, EventArgs e)
        {
            Contador.ContAgua = txtAlteraAgua.Text;
            Contador.ContGas = txtAlteraGas.Text;
            Contador.ContGaso = txtAlteraGaso.Text;
            Contador.ContLuz = txtAlteraLuz.Text;
            Contador.ContOut = txtAlteraOut.Text;
            Contador.ContTele = txtAlteraTele.Text;
            Contador.ContTelevisao = txtAlteraTelevis.Text;
            Contador.ContaData = mskAlteraData.Text;

            Contador cont = new Contador();

            cont.AlterarContas();

            pnlAlteraGanho.Visible = false;
        }

        private void btnAlterarLimpar_Click(object sender, EventArgs e)
        {
            txtAlteraAgua.Text = "";
            txtAlteraGas.Text = "";
            txtAlteraGaso.Text = "";
            txtAlteraLuz.Text = "";
            txtAlteraOut.Text = "";
            txtAlteraTele.Text = "";
            txtAlteraTelevis.Text = "";
            mskAlteraData.Text = "";
        }

        private void frmFixos_Load(object sender, EventArgs e)
        {
            pnlContas.Visible = true;
            pnlAlteraGanho.Visible = false;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            pnlAlteraGanho.Visible = true;
            pnlContas.Visible = false;
            CarregaContas();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            pnlAlteraGanho.Visible = false;
            pnlContas.Visible = true;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
