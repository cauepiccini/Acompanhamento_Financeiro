using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AssApp
{
    class Usuario
    {
        public static string Nome, Email, RG, Nascimento, Sexo, Senha, ConfirmSenha;

        public void InsereDados()
        {
            try
            {
                    if(Validar.RG(RG) == true)
                    {
                        string conex = "server =localhost; user id =root; password =; port =3306; database = acompanhamento_financeiro";
                        MySqlConnection cnx = new MySqlConnection(conex);
                        string cmd = "INSERT INTO tb_usuario(usu_nome, usu_email, usu_rg, usu_nascimento, usu_sexo, usu_senha) VALUES('" + Nome + "','" + Email + "','" + RG + "','" + Nascimento + "','" + Sexo + "','" + Senha + "')";
                        MySqlCommand insere = new MySqlCommand(cmd,cnx);

                        cnx.Open();
                        insere.ExecuteNonQuery();
                        //MessageBox.Show("Cadastrado com sucesso" + "\n" + "Volte clicando no Icone");
                        cnx.Close();
                    }
                    else
                    {
                        MessageBox.Show("RG Invalido");
                    }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public bool PegarDados()
        {
            try
            {
                string BancoDeDados = "server =localhost; user id =root; password =; port =3306; database = acompanhamento_financeiro";
                MySqlConnection ConexaoMySQL = new MySqlConnection(BancoDeDados);

                string ComandoSelect = "SELECT * FROM tb_usuario WHERE usu_email = '" + Email + "' and usu_senha = '" + Senha + "';";
                MySqlDataAdapter ExecutaComando = new MySqlDataAdapter(ComandoSelect, ConexaoMySQL);

                DataTable Tabela = new DataTable();
                ExecutaComando.Fill(Tabela);
                if (Tabela.Rows.Count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            } 
        }

        public void AlterarDados()
        {
            try
            {
                string conex = "server =localhost; user id =root; password =; port =3306; database =acompanhamento_financeiro";
                MySqlConnection cnx = new MySqlConnection(conex);
                string cmd = "UPDATE tb_usuario SET usu_nome ='" + Nome + "', usu_email ='" + Email + "', usu_rg ='" + RG + "', usu_nascimento ='" + Nascimento + "', usu_sexo ='" + Sexo + "', usu_senha ='" + Senha + "';";
                MySqlCommand command = new MySqlCommand(cmd, cnx);
                cnx.Open();

                command.ExecuteNonQuery();
                cnx.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void ExcluiDados()
        {
            try
            {
                string conex = "server =localhost; user id =root; password =; port =3306; database =acompanhamento_financeiro";
                MySqlConnection cnx = new MySqlConnection(conex);
                string cmd = "DELETE FROM tb_usuario WHERE usu_nome = '"+Nome+"';";
                MySqlCommand command = new MySqlCommand(cmd, cnx);
                cnx.Open();

                command.ExecuteNonQuery();
                cnx.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
