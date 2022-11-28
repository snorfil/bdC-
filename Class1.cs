using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoBDconsola
{
    internal class Class1
    {
        string sql = "SELECT TOP (5) [usuario],[contraseña] FROM [AdventureWorksLT2019].[dbo].[usuarios] ";
 


        public Class1()
        {
           //insertar("leandropo", "siloo");
            //Connect(sql);

        }

        public void FindById(string usuario) {
            
        }

     

        public void Connect(string sql)
        {
            string connectionString = null;
            SqlConnection connection;
            SqlCommand comand;
            SqlDataReader reader;
            connectionString = @"Data Source = C09PC07\SQLEXPRESS; Initial Catalog = AdventureWorksLT2019; Integrated Security = True";

            connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                comand = new SqlCommand(sql, connection);
                reader = comand.ExecuteReader();
                int contador = 0;
                int rows = reader.FieldCount;

                while (reader.Read())
                {
                    string resultado = "";
                    for (int i = 0; i < rows; i++)
                    {
                        resultado = resultado + reader.GetValue(i) + "_____";
                    }
                    Console.WriteLine(resultado);

                    contador++;
                }
                reader.Close();
                comand.Dispose();
       

            }
            catch (Exception e)
            {

            }
        }

        public void insertar(string us, string pw)
        {
            string sql = "INSERT INTO [dbo].[usuarios] ([usuario],[contraseña]) VALUES(@user,@pass)";

            string connectionString = @"Data Source = C09PC07\SQLEXPRESS; Initial Catalog = AdventureWorksLT2019; Integrated Security = True";
            SqlConnection connection;
            SqlCommand comand;

            connection = new SqlConnection(connectionString);
            
            try
            {
                
                comand = new SqlCommand(sql, connection);
                comand.Parameters.Add("@user", SqlDbType.VarChar, 30).Value = us;
                comand.Parameters.Add("@pass",SqlDbType.VarChar,30).Value = pw;

                connection.Open();
                int resultado = comand.ExecuteNonQuery();
                Console.WriteLine(resultado);

                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("salio mal el añadido");
            }

        }
    }
}
