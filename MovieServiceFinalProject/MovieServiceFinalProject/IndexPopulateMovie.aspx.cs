using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Data;
using System.Data.SqlClient;

namespace MovieServiceFinalProject
{
    public partial class IndexPopulateMovie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateList();
        }
        public void UpdateList()
        {
            SqlConnection conn = new SqlConnection(@"data source = .\sqlexpress; integrated security = true; database = MovieFlex");
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            string sqlsel = "select MovieName from Movie";

            try
            {
                //conn.Open(); SqlDataAdapter opens connection by itself
                //da = new SqlDataAdapter();
                //da.SelectCommand = new SqlCommand(sqlsel, conn);

                //ds = new DataSet();
                //da.Fill(ds, "MyMovie");

                //dt = ds.Tables["MyMovie"];

                //ListBoxPopulateMovie.DataSource = dt;
                //ListBoxPopulateMovie.DataBind();
                conn.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = "SELECT MovieName FROM Movie ";
                    //whenever you want to get some data from the database
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListBoxPopulateMovie.Items.Add(reader["MovieName"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LabelMessages.Text = ex.Message;
            }
            finally
            {
                conn.Close(); // SqlDataAdapter closes connection by itself; but can fail in case of errors
            }
        }
    }
}