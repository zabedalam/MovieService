using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace MovieServiceFinalProject
{
    public class APIConnection
    {
        public string SearchAPI(string query)
        {
            WebClient client = new WebClient();
            string reply = "";
            reply = client.DownloadString("http://www.omdbapi.com/?t=" + query + "&r=xml&apikey=" + Token.token);
            return reply;
        }
        public string SearchTrailerAPI(string query, int year)
        {
           
            WebClient client = new WebClient();
            string clearquery = query.Replace(" ", "+");
            string searchWord = clearquery + year + "Movie Trailer";
            string result = "";
            string youtubeAPI = $"https://www.googleapis.com/youtube/v3/search?&part=snippet&q={searchWord}&type=trailer&key={Token.trailerToken}";
            result = client.DownloadString(youtubeAPI);
            return result;
        }
    }
}