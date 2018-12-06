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
        private string Title { get;  set; }

        public void Thriller(ListBox lb)
        {
            SqlConnection conn = new SqlConnection(@"data source = .\Sqlexpress; integrated security = true; database = MovieFlex");
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string sqlsel = "";
            try
            {
                conn.Open();

                sqlsel = "select MovieName from Movie,Info where info.FilmCategoryID=3 and Movie.FilmCategoryID=3 ";
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
           
           
        }
        
    }
}
