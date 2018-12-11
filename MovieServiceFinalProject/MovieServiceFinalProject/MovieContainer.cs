using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MovieServiceFinalProject
{
    public class MovieContainer
    {
        public void ScienceMovie(ListBox lb)
        {
            //SCIENCE MOVIE CONTAINER
            DBUtility science = new DBUtility();
            SqlDataReader rdr = science.GetReader("select MovieName from Movie,Info where info.FilmCategoryID=4 and Movie.FilmCategoryID=4 ");

            while (rdr.Read())
            {
                //ListBoxrdr.Items.Add("Product = " + rdr[0] + ", Id of category =" + rdr["categoryid"]);
                lb.Items.Add(rdr["MovieName"].ToString());
            }

            science.CloseConnection();
        }

        public void ThrillerMovie(ListBox lb)
        {
            
                //THRILLER MOVIE CONTAINER
                DBUtility thriller = new DBUtility();
                SqlDataReader rdr = thriller.GetReader("select MovieName from Movie,Info where info.FilmCategoryID=4 and Movie.FilmCategoryID=3 ");

                while (rdr.Read())
                {
                    //ListBoxrdr.Items.Add("Product = " + rdr[0] + ", Id of category =" + rdr["categoryid"]);
                    lb.Items.Add(rdr["MovieName"].ToString());
                }

                thriller.CloseConnection();
            }

        public void ActionMovie(ListBox lb)
        {
            //ACTION MOVIE CONTAINER

            DBUtility action = new DBUtility();
            SqlDataReader rdr = action.GetReader("select MovieName from Movie,Info where info.FilmCategoryID=4 and Movie.FilmCategoryID=1 ");

            while (rdr.Read())
            {
                //ListBoxrdr.Items.Add("Product = " + rdr[0] + ", Id of category =" + rdr["categoryid"]);
                lb.Items.Add(rdr["MovieName"].ToString());
            }

            action.CloseConnection();
        }

        public void AnimationMovie(ListBox lb)
        {
            //ANIMATION MOVIE CONTAINER
            DBUtility animation = new DBUtility();
            SqlDataReader rdr = animation.GetReader("select MovieName from Movie,Info where info.FilmCategoryID=4 and Movie.FilmCategoryID=2 ");

            while (rdr.Read())
            {
                //ListBoxrdr.Items.Add("Product = " + rdr[0] + ", Id of category =" + rdr["categoryid"]);
                lb.Items.Add(rdr["MovieName"].ToString());
            }

            animation.CloseConnection();

        }
        }

    }
