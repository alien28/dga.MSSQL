using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace dga.MSSQL.TestRun
{
    class MainClass
    {
        static SqlConnection conn;

        static void Connection()
        {
            string strcon = System.Configuration.ConfigurationManager.AppSettings["DBConnectionSimple"].ToString();

            conn = new SqlConnection(strcon);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!!!");
            Console.WriteLine("test commit to repo GitHub1");

            //test print out connectionString
            Connection();
            Console.WriteLine("read Connection-string: {0}", conn.ConnectionString);

            using(SqlConnection con = conn)
            {
                string ssql = @"SELECT * FROM person";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(ssql, con);
                da.Fill(dt);
                
               foreach(DataRow ro in dt.Rows)
                {
                    Console.WriteLine("Full Name: {0}\t{1}", ro["name"].ToString().TrimEnd(),ro["lastname"].ToString().TrimEnd());
                }

            }

        }
    }
}
