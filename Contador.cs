using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace AssApp
{
    class Contador
    {
        public static string ContAgua, ContTele, ContTelevisao, ContGaso, ContOut, ContLuz, ContGas, Ganho, Total1, ContaData, GastoData, GanhoData;
        public static double intContAgua, intContTele, intContTelevi, intContGaso, intContOut, intContLuz, intContGas, intGanho, TotalConta, Total;

        public static string Entrete, Mercado, Alimentacao, Saude, Viagens, Transporte, OutrasCat, TotalGasto1;
        public static double intEntrete, intMercado, intAlimentacao, intSaude, intViagens, intTransporte, intOutrasCat, TotalGasto, Total2;


        public void InsereContas()
        {
            try
            {
                if (!ContAgua.Equals("") && !ContTele.Equals("") && !ContGaso.Equals("") && !ContOut.Equals("") && !ContLuz.Equals("") && !ContGas.Equals("") &&
                     !ContTelevisao.Equals("") && !ContaData.Equals(""))
                {
                    string conex = "server =localhost; user id =root; password =; port =3306; database = acompanhamento_financeiro";
                    MySqlConnection cnx = new MySqlConnection(conex);
                    string cmd = "INSERT INTO tb_contcontas(con_agua, con_telefone, con_televisao, con_gaso, con_out, con_luz, con_gas, con_data)" +
                    "VALUES ('" + ContAgua + "', '" + ContTele + "', '" + ContTelevisao + "', '" + ContGaso + "', '" + ContOut + "', '" + ContLuz + "', '" + ContGas + "', '" + ContaData + "');";
                    MySqlCommand insere = new MySqlCommand(cmd, cnx);

                    cnx.Open();
                    insere.ExecuteNonQuery();
                    cnx.Close();
                }
                else
                {
                    MessageBox.Show("Não deixe nenhum espaço em branco!");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public void InsereGastos()
        {
            try
            {
                if (!Entrete.Equals("") && !Mercado.Equals("") && !Alimentacao.Equals("") && !Saude.Equals("") && 
                    !Viagens.Equals("") && !Transporte.Equals("") && !OutrasCat.Equals("") && !GastoData.Equals(""))
                {
                    string conex = "server =localhost; user id =root; password =; port =3306; database = acompanhamento_financeiro";
                    MySqlConnection cnx = new MySqlConnection(conex);
                    string cmd = "INSERT INTO tb_gastopessoal(con_entrete, con_mercado, con_alimenta, con_saude, con_viagens, con_transporte, con_outras, con_data)"
                        + "VALUES('"+Entrete+"', '"+Mercado+"', '"+Alimentacao+"', '"+Saude+"', '"+Viagens+"', '"+Transporte+"', '"+OutrasCat+"', '"+GastoData+"');";
                    MySqlCommand insere = new MySqlCommand(cmd, cnx);

                    cnx.Open();
                    insere.ExecuteNonQuery();
                    cnx.Close();
                }
                else
                {
                    MessageBox.Show("Não deixe nenhum espaço em branco!");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public void InsereGanho()
        {
            try
            {
                if (!Ganho.Equals("") && !GanhoData.Equals(""))
                {
                    string conex = "server =localhost; user id =root; password =; port =3306; database = acompanhamento_financeiro";
                    MySqlConnection cnx = new MySqlConnection(conex);
                    string cmd = "INSERT INTO tb_contganho(con_ganho, con_data) VALUES ('" + Ganho + "', '"+GanhoData+"');";
                    MySqlCommand dados = new MySqlCommand(cmd, cnx);

                    cnx.Open();
                    dados.ExecuteNonQuery();
                    cnx.Close();

                }
                else
                {
                    MessageBox.Show("Não deixe o espaço em branco!");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void AlterarContas()
        {
            if (!ContAgua.Equals("") && !ContTele.Equals("") && !ContGaso.Equals("") && !ContOut.Equals("") && !ContLuz.Equals("") && !ContGas.Equals("") &&
                !ContTelevisao.Equals("") && !ContaData.Equals(""))
            {
                string conex = "server =localhost; user id =root; password =; port =3306; database = acompanhamento_financeiro";
                MySqlConnection cnx = new MySqlConnection(conex);
                string cmd = "UPDATE tb_contcontas SET con_agua = '" + ContAgua + "', con_telefone = '" + ContTele + "', con_televisao = '" + ContTelevisao + "', con_gaso = '" + ContGaso + "', con_out = '" + ContOut
                    + "', con_luz = '" + ContLuz + "', con_gas = '" + ContGas + "', con_data = '"+ContaData+"';";
                MySqlCommand altera = new MySqlCommand(cmd, cnx);

                cnx.Open();
                altera.ExecuteNonQuery();
                cnx.Close();
            }
            else
            {
                MessageBox.Show("Não deixe nenhum espaço em branco!");
            }

        }

        public void AlteraGastos()
        {
            try
            {
                if (!Entrete.Equals("") && !Mercado.Equals("") && !Alimentacao.Equals("") && !Saude.Equals("") &&
                    !Viagens.Equals("") && !Transporte.Equals("") && !OutrasCat.Equals("") && !GastoData.Equals(""))
                {
                    string conex = "server =localhost; user id =root; password =; port =3306; database = acompanhamento_financeiro";
                    MySqlConnection cnx = new MySqlConnection(conex);
                    string cmd = "UPDATE tb_gastopessoal SET con_entrete = '" + Entrete + "', con_mercado = '" + Mercado + "', con_alimenta = '" + Alimentacao + "', con_saude = '" + Saude + "', con_viagens = '" + Viagens
                        + "', con_transporte = '" + Transporte + "', con_outras = '" + OutrasCat + "', con_data = '"+GastoData+"';";
                    MySqlCommand insere = new MySqlCommand(cmd, cnx);

                    cnx.Open();
                    insere.ExecuteNonQuery();
                    cnx.Close();
                }
                else
                {
                    MessageBox.Show("Não deixe nenhum espaço em branco!");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public void AlterarGanho()
        {
            if (!Ganho.Equals("") && !GanhoData.Equals(""))
            {
                string conex = "server =localhost; user id =root; password =; port =3306; database = acompanhamento_financeiro";
                MySqlConnection cnx = new MySqlConnection(conex);
                string cmd = "UPDATE tb_contganho SET con_ganho = '" + Ganho + "', con_data = '"+GanhoData+"';";
                MySqlCommand alt = new MySqlCommand(cmd, cnx);

                cnx.Open();
                alt.ExecuteNonQuery();
                cnx.Close();
            }
            else
            {
                MessageBox.Show("Não deixe o espaço em branco!");
            }
        }

        public string CalculaGastos()
        {

            string cnx = "server =localhost; user id =root; password =; port =3306; database = acompanhamento_financeiro";
            MySqlConnection cnn = new MySqlConnection(cnx);
            string bd = "SELECT * FROM tb_contcontas";
            MySqlCommand commd = new MySqlCommand(bd, cnn);

            cnn.Open();

            MySqlDataReader ler = commd.ExecuteReader();
            while (ler.Read())
            {
                intEntrete = Convert.ToDouble(ler["con_entrete"].ToString());
                intMercado = Convert.ToDouble(ler["con_mercado"].ToString());
                intAlimentacao = Convert.ToDouble(ler["con_alimenta"].ToString());
                intSaude = Convert.ToDouble(ler["con_saude"].ToString());
                intViagens = Convert.ToDouble(ler["con_viagens"].ToString());
                intTransporte = Convert.ToDouble(ler["con_transporte"].ToString());
                intOutrasCat = Convert.ToDouble(ler["con_outras"].ToString());


                break;
            }
            cnn.Close();


            string conex = "server =localhost; user id =root; password =; port =3306; database = acompanhamento_financeiro";
            MySqlConnection conn = new MySqlConnection(conex);
            string sql = "SELECT * FROM tb_contcontas";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();

            MySqlDataReader le = cmd.ExecuteReader();
            while (le.Read())
            {
                intContAgua = Convert.ToDouble(le["con_agua"].ToString());
                intContTele = Convert.ToDouble(le["con_telefone"].ToString());
                intContTelevi = Convert.ToDouble(le["con_televisao"].ToString());
                intContOut = Convert.ToDouble(le["con_out"].ToString());
                intContLuz = Convert.ToDouble(le["con_luz"].ToString());
                intContGaso = Convert.ToDouble(le["con_gaso"].ToString());
                intContGas = Convert.ToDouble(le["con_gas"].ToString());

                TotalConta = intContAgua + intContTelevi + intContGas + intContGaso + intContLuz + intContOut + intContTele;

                TotalGasto = intEntrete + intMercado + intAlimentacao + intSaude + intViagens + intTransporte + intOutrasCat;

                Total2 = TotalGasto + TotalConta;
                break;
            }
            conn.Close();

            TotalGasto1 = Convert.ToString(Total2);

            return TotalGasto1;

        }

        public string CalculaTotal()
        {

            string conexao = "server =localhost; user id =root; password =; port =3306; database = acompanhamento_financeiro";
            MySqlConnection conecta = new MySqlConnection(conexao);
            string bd = "SELECT con_ganho FROM tb_contganho";
            MySqlCommand command = new MySqlCommand(bd, conecta);
            conecta.Open();

            MySqlDataReader ler = command.ExecuteReader();
            while (ler.Read())
            {
                intGanho = Convert.ToDouble(ler["con_ganho"].ToString());
                //
                break;
            }
            conecta.Close();

            string cnx = "server =localhost; user id =root; password =; port =3306; database = acompanhamento_financeiro";
            MySqlConnection cnn = new MySqlConnection(cnx);
            string query = "SELECT * FROM tb_gastopessoal";
            MySqlCommand comand = new MySqlCommand(query, cnn);
            cnn.Open();

            MySqlDataReader leitor = comand.ExecuteReader();
            while (leitor.Read())
            {
                intEntrete = Convert.ToDouble(leitor["con_entrete"].ToString());
                //
                intMercado = Convert.ToDouble(leitor["con_mercado"].ToString());
                //
                intAlimentacao = Convert.ToDouble(leitor["con_alimenta"].ToString());
                //
                intSaude = Convert.ToDouble(leitor["con_saude"].ToString());
                //
                intViagens = Convert.ToDouble(leitor["con_viagens"].ToString());
                //
                intTransporte = Convert.ToDouble(leitor["con_transporte"].ToString());
                //
                intOutrasCat = Convert.ToDouble(leitor["con_outras"].ToString());
                //

                TotalGasto = intEntrete + intMercado + intAlimentacao + intSaude + intViagens + intTransporte + intOutrasCat;

                break;
            }
            cnn.Close();

            string conex = "server =localhost; user id =root; password =; port =3306; database = acompanhamento_financeiro";
            MySqlConnection conn = new MySqlConnection(conex);
            string sql = "SELECT * FROM tb_contcontas";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();

            MySqlDataReader le = cmd.ExecuteReader();
            while (le.Read())
            {
                intContAgua = Convert.ToDouble(le["con_agua"].ToString());
                intContTele = Convert.ToDouble(le["con_telefone"].ToString());
                intContTelevi = Convert.ToDouble(le["con_televisao"].ToString());
                intContOut = Convert.ToDouble(le["con_out"].ToString());
                intContLuz = Convert.ToDouble(le["con_luz"].ToString());
                intContGaso = Convert.ToDouble(le["con_gaso"].ToString());
                intContGas = Convert.ToDouble(le["con_gas"].ToString());

                TotalConta = intContAgua + intContTelevi + intContGas + intContGaso + intContLuz + intContOut + intContTele;

                Total2 = TotalConta + TotalGasto;

                Total = intGanho - Total2;
                break;
            }
            conn.Close();

            string conexo = "server =localhost; user id =root; password =; port =3306; database = acompanhamento_financeiro";
            MySqlConnection con = new MySqlConnection(conexo);
            string sbd = "INSERT INTO tb_cont (con_total, con_contatotal, con_gastototal, con_sobra)"
                        +" VALUES ('" + Total2 + "', '" + TotalConta + "', '" + TotalGasto + "', '"+Total1+"');";
            MySqlCommand conmand = new MySqlCommand(sbd, con);
            con.Open();
            conmand.ExecuteNonQuery();

            Total1 = Convert.ToString(Total);

            return Total1;
            con.Close();
        }

        public void TotalContVsGan()
        {
            string conexo = "server =localhost; user id =root; password =; port =3306; database = acompanhamento_financeiro";
            MySqlConnection con = new MySqlConnection(conexo);
            string sbd = "UPDATE tb_cont SET con_total = '" + Total2 + "', con_contatotal = '" + TotalConta + "', con_gastototal ='" + TotalGasto + "',"
                + " con_sobra ='" + Total1 + "';";
            MySqlCommand conmand = new MySqlCommand(sbd, con);
            con.Open();
            conmand.ExecuteNonQuery();
            con.Close();
        }
    }
}
