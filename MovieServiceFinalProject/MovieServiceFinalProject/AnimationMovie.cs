using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI;
using System.Web.UI.WebControls;


using System.Drawing;
using System.Net;
using System.IO;
using System.Xml;



using System.Data;
using System.Data.SqlClient;



namespace MovieServiceFinalProject
{
    public class AnimationMovie
    {
        //private object LabelMessages { get; set; }
        //private object ListBoxPopulateMovie { get; set; }
        //private object Items { get; set; }

        public void Animation(ListBox lb)
        {

            SqlConnection conn = new SqlConnection(@"data source = .\sqlexpress; integrated security = true; database = MovieFlex");
           
                conn.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = "select MovieName from Movie,Info where info.FilmCategoryID=2 and Movie.FilmCategoryID=2 ";
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
