using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;
using System.Configuration;

namespace MovieServiceFinalProject
{
    public class Commercial
    {
        
        public object LabelMessages { get; private set; }
       

        public void commercialShow(GridView grid)
        {
            SqlConnection conn = new SqlConnection(@"data source = .\sqlexpress; integrated security = true; database = MovieFlex");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader rdr = null;
            

            try
            {
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "commercial_purpose";

                rdr = cmd.ExecuteReader();
                grid.DataSource = rdr;
                grid.DataBind();

                rdr.Close();
                
            }
            catch (Exception )
            {
                LabelMessages = "Nothing";
            }
            
            finally
            {
                conn.Close();
            }

           // updateCommercial();
        }
        public void updateCommercial()
        {
           
           
        }
    }
}