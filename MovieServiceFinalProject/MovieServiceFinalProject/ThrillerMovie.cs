using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace MovieServiceFinalProject
{
    public class ThrillerMovie
    {
        public void Thriller(ListBox lb)
        {

            SqlConnection conn = new SqlConnection(@"data source = .\sqlexpress; integrated security = true; database = MovieFlex");

            conn.Open();
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = "select MovieName from Movie,Info where info.FilmCategoryID=3 and Movie.FilmCategoryID=3 ";
                //whenever you want to get some data from the database
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lb.Items.Add(reader["MovieName"].ToString());
                    }
                }
            }
        }
        //catch (Exception ex)
        //{
        //    LabelMessages.Text = ex.Message;
        //}
        //finally
        //{
        //    conn.Close(); // SqlDataAdapter closes connection by itself; but can fail in case of errors
        //}
    }
}
