using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace MovieServiceFinalProject
{
    public class ActionMovie
    {
        private String Title { get; set; }
        public void Action(ListBox lb)
        {
            SqlConnection conn = new SqlConnection(@"data source = .\Sqlexpress; integrated security = true; database = MovieFlex");
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string sqlsel = "";
            try
            {
                conn.Open();

                sqlsel = "select MovieName from Movie,Info where info.FilmCategoryID=1 and Movie.FilmCategoryID=1 ";
                cmd = new SqlCommand(sqlsel, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //ListBoxrdr.Items.Add("Product = " + rdr[0] + ", Id of category =" + rdr["categoryid"]);
                    lb.Items.Add(rdr["MovieName"].ToString());
                }
                rdr.Close();
            }
            catch (Exception)
            {
                Title = "not found";
                //LabelMessages.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            //    SqlConnection conn = new SqlConnection(@"data source = .\sqlexpress; integrated security = true; database = MovieFlex");

            //    conn.Open();
            //    using (SqlCommand command = new SqlCommand())
            //    {
            //        command.Connection = conn;
            //        command.CommandText = "select MovieName from Movie,Info where info.FilmCategoryID=1 and Movie.FilmCategoryID=1 ";
            //        //whenever you want to get some data from the database
            //        using (SqlDataReader reader = command.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                lb.Items.Add(reader["MovieName"].ToString());
            //            }
            //        }
            //    }
            //    conn.Close();
            //}
            ////catch (Exception ex)
            ////{
            ////    LabelMessages.Text = ex.Message;
            ////}
            ////finally
            ////{
            ////    conn.Close(); // SqlDataAdapter closes connection by itself; but can fail in case of errors
            ////}
        }
    }
}