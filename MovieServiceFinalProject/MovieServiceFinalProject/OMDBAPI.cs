//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;


using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Drawing;
using System.IO;
using System.Xml;

namespace MovieServiceFinalProject
{
    public class OMDBAPI
    { private string id { get; set; }
        public  OMDBAPI()
        {
            WebClient client = new WebClient();
            string imageurl = string.Empty;
            string apiUrl = $"http://www.omdbapi.com/?t={id}&apikey={Token.token}";
            var result = client.DownloadString(apiUrl);


            File.WriteAllText(HttpContext.Current.Server.MapPath("~/MyFiles/Latestresult.json"), result);

            // A simple example. Treat json as a string
            string[] separatingChars = { "\":\"", "\",\"", "\":[{\"", "\"},{\"", "\"}]\"", "{\"", "\"}" };
            string[] mysplit = result.Split(separatingChars, System.StringSplitOptions.RemoveEmptyEntries);

            if (mysplit[1] != "False")
            {
                for (int i = 0; i < mysplit.Length; i++)
                {
                    if (mysplit[i] == "Poster")
                    {
                        imageurl = mysplit[++i];
                        break;
                    }
                }
            }

            //return imageurl;
        }
    }
}
