using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace MovieServiceFinalProject
{
    public class MovieCounter
    {
        public int UpdateMovie(SqlConnection Conn, string name, int stateNew, int stateOld)
        {
            
            using (var updMovie = new SqlCommand("update Movie set Visit_Counter = " + stateNew + " where Visit_Counter = " + stateOld + " and MovieName =" + name, Conn))
            {
                
                int affectedRows = updMovie.ExecuteNonQuery();


                return affectedRows;
            }
        }

        internal void UpdateMovie()
        {
            throw new NotImplementedException();
        }
    }

   
}