using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Xsl;
using System.IO;
using Microsoft.SqlServer;
using System.Xml;
using Microsoft.SqlServer.Server;
using System.Data;
using System.Net;





namespace MovieServiceFinalProject
{
    public class XML
    {
        private string sourcefile { get; set; }
        private string xsltfile { get; set; }
        private string Destinationfile { get; set; }

        public XML(string xml, string xslt, string destination)
        {
            this.sourcefile = xml;
            this.xsltfile = xslt;
            this.Destinationfile = destination;
        }
     public void TransformXslt() {
                FileStream fist = new FileStream(Destinationfile, FileMode.Create);
                XslCompiledTransform xct = new XslCompiledTransform();
                xct.Load(xsltfile);
                xct.Transform(sourcefile, null, fist);
                fist.Close();
            }
        }
    }
}