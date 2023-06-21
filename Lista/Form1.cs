using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lista
{
    public partial class Form1 : Form
    {

        // declaração das variáveis de conexão e comandos SQL

        SqlConnection conexao;
        SqlCommand comando;
        SqlDataAdapter da;
        SqlDataReader dr;

        string strSQL;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                // conexão com o banco de dados sql server

                conexao = new SqlConnection("Server = DESKTOP-B330Q0G\\SQLEXPRESS; Database = Lista;Trusted_Connection = True; ");

                // comando sql para inserção de dados na tabela LISTA_1

                strSQL = "INSERT INTO LISTA_1 (NOME, IDADE) VALUES (@NOME, @IDADE)";

                // criação do comando SQL e associando os parametros

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@NOME", txtNome.Text);
                comando.Parameters.AddWithValue("@IDADE", txtIdade.Text);

                // abri conexão com o banco de dados

                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }
            finally 
            {
                // fecha conexão com banco de dados

                conexao.Close();
                conexao = null;
                comando = null;

            }    



            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection("Server = DESKTOP-B330Q0G\\SQLEXPRESS; Database = Lista;Trusted_Connection = True; ");

                strSQL = "SELECT * FROM Lista_1";

                // criação do dataset para armazenar os dados retornados do banco de dados

                DataSet ds = new DataSet();

                // criação do dataadapter para preencher o dataset com os resultados da consulta

                da = new SqlDataAdapter(strSQL, conexao);

                // abre a conexão com o banco de dados e preenche o dataset

                conexao.Open();

                da.Fill(ds);

                // define a fonte de dados do datagridview como a primeira tabela do dataset

                dgvDados.DataSource = ds.Tables[0];


               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conexao.Close();
               
                conexao = null;
                comando = null;

            }





        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection("Server = DESKTOP-B330Q0G\\SQLEXPRESS; Database = Lista;Trusted_Connection = True; ");

                strSQL = "SELECT *FROM LISTA_1 WHERE ID = @ID";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@ID", txtID.Text);
                
                conexao.Open() ;

                dr= comando.ExecuteReader(); 
                
                while (dr.Read()) {

                    txtNome.Text = (string) dr["nome"];
                    txtIdade.Text = Convert.ToString (dr["idade"]);

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection("Server = DESKTOP-B330Q0G\\SQLEXPRESS; Database = Lista;Trusted_Connection = True; ");

                strSQL = "UPDATE LISTA_1 SET NOME = @NOME, IDADE = @IDADE WHERE ID = @ID";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@ID", txtID.Text);
                comando.Parameters.AddWithValue("@NOME", txtNome.Text);
                comando.Parameters.AddWithValue("@IDADE", txtIdade.Text);


                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection("Server = DESKTOP-B330Q0G\\SQLEXPRESS; Database = Lista;Trusted_Connection = True; ");

                strSQL = "DELETE LISTA_1 WHERE ID = @ID";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@ID", txtID.Text);
                


                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
    }

