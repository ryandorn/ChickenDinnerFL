using ChickenDinnerFL.Framework.Common;
using ChickenDinnerFL.Framework;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenDinnerFL.Framework.SQL
{
    public class SQLExecutor
    {
        private static readonly string connectionString = Constants.DB_CONNECTION_STRING;

        internal static void executeSQL(string query)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                SqlDataReader reader;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                if (query.ToLower().Contains("exec"))
                {
                    cmd.CommandTimeout = 600;
                }

                conn.Open();

                reader = cmd.ExecuteReader();

                do
                {
                    int count = reader.FieldCount;
                    while (reader.Read())
                    {
                        for (int i = 0; i < count; i++)
                        {
                            query = reader.GetValue(i).ToString();
                        }
                    }
                } while (reader.NextResult());
                cmd.CommandTimeout = 120;

                conn.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message + ": " + query);
            }
            finally
            {
                conn.Close();
            }
        }

        internal static string executeSQL_ReturnResult(string query)
        {
            string results = "";
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                conn.Open();

                reader = cmd.ExecuteReader();

                do
                {
                    int count = reader.FieldCount;
                    while (reader.Read())
                    {
                        for (int i = 0; i < count; i++)
                        {
                            results = reader.GetValue(i).ToString();
                        }
                    }
                } while (reader.NextResult());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message + ": " + query);
                results = e.Message;
            }
            finally
            {
                conn.Close();
            }

            return results;
        }
    }
}
