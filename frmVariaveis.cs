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
    public partial class frmVariaveis : Form
    {
        public frmVariaveis()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            CarregaVaria();
            pnlAlteraGastos.Visible = true;
            pnlGastos.Visible = false;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            pnlGastos.Visible = true;
            pnlAlteraGastos.Visible = false;
        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            Contador cont = new Contador();

            Contador.Entrete = txtEntrete.Text;
            Contador.Mercado = txtMercado.Text;
            Contador.Alimentacao = txtAlimenta.Text;
            Contador.Viagens = txtViagens.Text;
            Contador.Transporte = txtTransp.Text;
            Contador.Saude = txtSaude.Text;
            Contador.OutrasCat = txtOutras.Text;
            Contador.GastoData = mskData.Text;

            cont.InsereGastos();

            pnlGastos.Visible = false;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtAlimenta.Text = "";
            txtEntrete.Text = "";
            txtMercado.Text = "";
            txtOutras.Text = "";
            txtSaude.Text = "";
            txtTransp.Text = "";
            txtViagens.Text = "";
            mskData.Text = "";
        }

        private void frmVariaveis_Load(object sender, EventArgs e)
        {
            pnlAlteraGastos.Visible = false;
        }

        private void btnAltera_Click(object sender, EventArgs e)
        {
            Contador cont = new Contador();

            Contador.Entrete = txtEntre.Text;
            Contador.Mercado = txtMer.Text;
            Contador.Alimentacao = txtAli.Text;
            Contador.Viagens = txtVia.Text;
            Contador.Transporte = txtTrans.Text;
            Contador.Saude = txtSau.Text;
            Contador.OutrasCat = txtOutr.Text;
            Contador.GastoData = mskAlteraData.Text;

            cont.AlteraGastos();

            pnlAlteraGastos.Visible = false;
        }

        private void btnAlteraLimpar_Click(object sender, EventArgs e)
        {
            txtAli.Text = "";
            txtEntre.Text = "";
            txtMer.Text = "";
            txtOutr.Text = "";
            txtSau.Text = "";
            txtTrans.Text = "";
            txtVia.Text = "";
            mskAlteraData.Text = "";
        }

        private void CarregaVaria()
        {
            string conex = "server =localhost; user id =root; password =; port =3306; database = acompanhamento_financeiro";
            MySqlConnection conn = new MySqlConnection(conex);
            string sql = "SELECT con_entrete, con_mercado, con_alimenta, con_saude, con_viagens," +
            "con_transporte, con_outras, con_data from tb_gastopessoal";
            MySqlCommand cmd = new MySqlCommand(sql, conn);


            conn.Open();
            MySqlDataReader leitor = cmd.ExecuteReader();
            while (leitor.Read())
            {
                txtAli.Text = leitor["con_alimenta"].ToString();
                txtEntre.Text = leitor["con_entrete"].ToString();
                txtMer.Text = leitor["con_mercado"].ToString();
                txtOutr.Text = leitor["con_outras"].ToString();
                txtSau.Text = leitor["con_saude"].ToString();
                txtTrans.Text = leitor["con_transporte"].ToString();
                txtVia.Text = leitor["con_viagens"].ToString();
                mskAlteraData.Text = leitor["con_data"].ToString();
            }
            conn.Close();
        }
    }
}
