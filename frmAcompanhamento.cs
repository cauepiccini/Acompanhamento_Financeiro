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
    public partial class frmAcompanhamento : Form
    {
        public frmAcompanhamento()
        {
            InitializeComponent();
        }

        private void frmAcompanhamento_Load(object sender, EventArgs e)
        {
            pnlGanho.Visible = false;
            pnlGastos.Visible = false;
            pnlResumo.Visible = false;
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            pnlGanho.Visible = false;
            pnlResumo.Visible = false;
            pnlGastos.Visible = false;
            new frmEntrada().Show();
            this.Hide();
        }

        private void btnSaida_Click(object sender, EventArgs e)
        {
            pnlGastos.Visible = true;
            pnlResumo.Visible = false;
            pnlGanho.Visible = false;
        }

        private void btnResuGanho_Click(object sender, EventArgs e)
        {
            GraficoGanho();

            pnlGanho.Visible = true;
            pnlGastos.Visible = false;
            pnlResumo.Visible = false;
        }

        private void btnFixos_Click(object sender, EventArgs e)
        {
            new frmFixos().Show();
            this.Hide();
        }

        private void btnVariados_Click(object sender, EventArgs e)
        {
            new frmVariaveis().Show();
            this.Hide();
        }

        private void btnGanhos_Click(object sender, EventArgs e)
        {
            new frmEntrada().Show();
            this.Hide();
        }

        private void btnResumo_Click(object sender, EventArgs e)
        {
            Contador cont = new Contador();
            cont.CalculaTotal();
            cont.TotalContVsGan();

            GraficoContGas();
            GraficoTudo();

            pnlResumo.Visible = true; 
            pnlGastos.Visible = false;
            pnlGanho.Visible = false;
        }

        public void GraficoContGas()
        {
            try
            {
                string conex = "server =localhost; user id =root; password=; port =3306; database = acompanhamento_financeiro";
                MySqlConnection con = new MySqlConnection(conex);
                string cmd = "SELECT * FROM tb_contcontas";
                MySqlCommand command = new MySqlCommand(cmd, con);
                con.Open();

                MySqlDataReader le = command.ExecuteReader();
                while (le.Read())
                {
                    chrGastosContas.Series["Contas"].Points.AddXY("Gás", le.GetString("con_gas"));
                    //
                    chrGastosContas.Series["Contas"].Points.AddXY("Luz", le.GetDouble("con_luz"));
                    //
                    chrGastosContas.Series["Contas"].Points.AddXY("TV a Cabo", le.GetString("con_televisao"));
                    //
                    chrGastosContas.Series["Contas"].Points.AddXY("Gasolina", le.GetString("con_gaso"));
                    //
                    chrGastosContas.Series["Contas"].Points.AddXY("Telefone", le.GetString("con_telefone"));
                    //
                    chrGastosContas.Series["Contas"].Points.AddXY("Água", le.GetString("con_agua"));
                    //
                    chrGastosContas.Series["Contas"].Points.AddXY("Outros", le.GetString("con_out"));
                    //
                    break;
                }
                con.Close();

                string cnx = "server =localhost; user id =root; password=; port =3306; database = acompanhamento_financeiro";
                MySqlConnection cnn = new MySqlConnection(cnx);
                string commd = "SELECT * FROM tb_gastopessoal";
                MySqlCommand comand = new MySqlCommand(commd, cnn);
                cnn.Open();

                MySqlDataReader ler = comand.ExecuteReader();
                while (ler.Read())
                {
                    chrGastosContas.Series["Gastos"].Points.AddXY("Entretenimento", ler.GetString("con_entrete"));
                    //
                    chrGastosContas.Series["Gastos"].Points.AddXY("Mercado", ler.GetDouble("con_mercado"));
                    //
                    chrGastosContas.Series["Gastos"].Points.AddXY("Alimentação", ler.GetString("con_alimenta"));
                    //
                    chrGastosContas.Series["Gastos"].Points.AddXY("Saúde", ler.GetString("con_saude"));
                    //
                    chrGastosContas.Series["Gastos"].Points.AddXY("Viagens", ler.GetString("con_viagens"));
                    //
                    chrGastosContas.Series["Gastos"].Points.AddXY("Transporte", ler.GetString("con_transporte"));
                    //
                    chrGastosContas.Series["Gastos"].Points.AddXY("Outras Categorias", ler.GetString("con_outras"));
                    //
                    break;
                }
                cnn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
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

        public void GraficoTudo()
        {
            try
            {
                string cnx = "server =localhost; user id =root; password=; port =3306; database = acompanhamento_financeiro";
                MySqlConnection conn = new MySqlConnection(cnx);
                string cmd = "SELECT * FROM tb_cont";
                MySqlCommand commando = new MySqlCommand(cmd, conn);
                conn.Open();

                MySqlDataReader ler = commando.ExecuteReader();
                while (ler.Read())
                {
                    chrTudo.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
                    chrTudo.PaletteCustomColors = new Color[] { Color.Red, Color.OrangeRed, Color.Green };
                    //
                    chrTudo.Series["Tudo"].Points.AddXY("Gastos Fixos", ler.GetString("con_contatotal"));
                    //
                    chrTudo.Series["Tudo"].Points.AddXY("Gastos Variados", ler.GetString("con_gastototal"));
                    //
                    break;
                }
                conn.Close();

                string conex = "server =localhost; user id =root; password=; port =3306; database = acompanhamento_financeiro";
                MySqlConnection con = new MySqlConnection(conex);
                string comand = "SELECT * FROM tb_contganho";
                MySqlCommand comando = new MySqlCommand(comand, con);
                con.Open();

                MySqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    chrTudo.Series["Tudo"].Points.AddXY("Ganho", leitor.GetString("con_ganho"));
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
    }
}
