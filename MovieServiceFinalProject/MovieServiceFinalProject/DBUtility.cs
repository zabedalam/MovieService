using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace MovieServiceFinalProject
{
    public class DBUtility
    {
        private SqlConnection conn;
        public SqlConnection GetConnection()
        {
            //CONNECT TO DB
            String StrConn = @"data source = .\Sqlexpress; integrated security = true; database = MovieFlex";
            conn = new SqlConnection(StrConn);
            conn.Open();
            return conn;

        }

        public SqlDataReader GetReader(String query)
        {
            //CREATE A COMMAND
            SqlCommand cmd = new SqlCommand(query);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = this.GetConnection();

            //READ FROM DB

            SqlDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }

        public void CloseConnection()
        {
            //CONNECTION CLOSE
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                this.conn.Close();
            }
        }
    }
}