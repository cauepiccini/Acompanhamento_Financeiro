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
    public partial class frmPerfil : Form
    {

        public frmPerfil()
        {
            InitializeComponent();
        }

        private void frmPerfil_Load(object sender, EventArgs e)
        {
            CarregaDado();
            pnlConfig.Visible = false;
            pnlTampa.Visible = true;
        }

        private void picVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CarregaDado()
        {
            string conex = "server =localhost; user id =root; password =; port =3306; database = acompanhamento_financeiro";
            MySqlConnection conn = new MySqlConnection(conex);
            string sql = "SELECT usu_nome, usu_email, usu_nascimento, usu_sexo FROM tb_usuario";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();
            MySqlDataReader le = cmd.ExecuteReader();
            while (le.Read())
            {
                lblEmail.Text = le["usu_email"].ToString();
                lblNascimento.Text = le["usu_nascimento"].ToString();
                lblNome.Text = "Bem Vindo: " + le["usu_nome"].ToString();
                lblSexo.Text = le["usu_sexo"].ToString();
            }
            conn.Close();
        }


        public void GraficoGanho()
        {
            try
            {
                string conex = "server =localhost; user id =root; password=; port =3306; database = acompanhamento_financeiro";
                MySqlConnection con = new MySqlConnection(conex);
                string cmd = "SELECT * FROM tb_contganho";
                MySqlCommand command = new MySqlCommand(cmd, con);
                con.Open();

                MySqlDataReader le = command.ExecuteReader();
                while (le.Read())
                {
                    chrGanho.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
                    chrGanho.PaletteCustomColors = new Color[] { Color.Green };
                    //
                    chrGanho.Series["Ganho"].Points.AddXY("Ganho", le.GetString("con_ganho"));
                    //
                    break;
                }
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnCarrega_Click(object sender, EventArgs e)
        {
            GraficoGanho();
            pnlTampa.Visible = false;
        }

        private void picConfig_Click(object sender, EventArgs e)
        {
            pnlConfig.Visible = true;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            pnlConfig.Visible = false;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            new frmAlteraCadastro().Show();
            this.Hide();
        }
    }
}
