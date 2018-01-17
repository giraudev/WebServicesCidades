using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace WebServicesCidades.Models
{
    public class DAOCidades
    {
        //variável para conexão com o BD
        SqlConnection con = null;
        //variável para comando do BD
        SqlCommand cmd = null;
        //variavel para ler os dados do BD
        SqlDataReader rd = null;

        //string para a conexão com BD
        string connectionString = @"Data Source=.\SqlExpress;Initial Catalog=ProjetoCidades;user id=sa;password=senai@123";

        public List<Cidades> Listar()
        {
            //lista para exibir os dados do SELECT do BD
            List<Cidades> cidades = new List<Cidades>();
            try
            {
                con = new SqlConnection(connectionString);
                //abrir o BD
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                //definindo o tipo de comando q será enviado
                cmd.CommandText = "Select * from Cidades";
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    cidades.Add(new Cidades()
                    {
                        Id = rd.GetInt32(0),
                        Nome = rd.GetString(1),
                        Estado = rd.GetString(2),
                        Habitantes = rd.GetInt32(3)
                    });
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao tentar apagar os dados na tabela. " + ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao tentar apagar os dados na tabela. " + e.Message);
            }
            finally
            {
                con.Close();
            }
            return cidades;
        }

        public bool Cadastro(Cidades cidades)
        {
            bool resultado = false;
            try
            {
                con = new SqlConnection(connectionString);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Cidades(nome, estado, habitantes) values (@n, @e, @h)";
                cmd.Parameters.AddWithValue("@n", cidades.Nome);
                cmd.Parameters.AddWithValue("@e", cidades.Estado);
                cmd.Parameters.AddWithValue("@h", cidades.Habitantes);

                //executenonquery = para insert, update e delete. O reader é sé para ler.
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                    resultado = true;
                //lembrar de limpar todos os parametros
                cmd.Parameters.Clear();
            }
            catch (SqlException se)
            {
                throw new Exception("Erro ao tentar apagar os dados na tabela. " + se.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao tentar apagar os dados na tabela. " + e.Message);
            }
            finally
            {
                con.Close();
            }
            return resultado;

        }

        public string Excluir(int id)
        {
            string msg = "";

            try
            {
                con = new SqlConnection(connectionString);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Cidades where Id=@i";
                cmd.Parameters.AddWithValue("@i", id);
                int r = cmd.ExecuteNonQuery();

                if (r > 0)
                    msg = "Registro apagado.";
                else
                    msg = "Não foi possível apagar";

                cmd.Parameters.Clear();
            }
            catch (SqlException se)
            {
                throw new Exception("Erro ao tentar apagar os dados na tabela. " + se.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao tentar apagar os dados na tabela. " + e.Message);
            }
            finally
            {
                con.Close();
            }
            return msg;
        }
        public string Editar(Cidades cidade)
        {
            string msg = "";
            try
            {
                con = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update Cidades set Nome = @n, Estado = @e , Habitantes = @h where Id = @i";
                cmd.Parameters.AddWithValue("@n", cidade.Nome);
                cmd.Parameters.AddWithValue("@e", cidade.Estado);
                cmd.Parameters.AddWithValue("@h", cidade.Habitantes);
                cmd.Parameters.AddWithValue("@i", cidade.Id);
                con.Open();

                int r = cmd.ExecuteNonQuery();

                if (r > 0)
                    msg = "Atualização Efetuada";
                else
                    msg = "Não foi possível atualizar";
                cmd.Parameters.Clear();

            }
            catch (SqlException se)
            {
                throw new Exception("Erro ao tentar atualizar dados " + se.Message);
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro ao tentar atualizar dados " + e.Message);
            }
            finally
            {
                con.Close();
            }

            return msg;
        }


    }
}