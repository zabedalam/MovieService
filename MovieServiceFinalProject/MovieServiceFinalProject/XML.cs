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
        private string Sourcefile { get; set; }
        private string Xsltfile { get; set; }
        private string Destinationfile { get; set; }

        public XML(string xml, string xslt, string destination)
        {
            this.Sourcefile = xml;
            this.Xsltfile = xslt;
            this.Destinationfile = destination;
        }
     public void Transform() {
                FileStream fist = new FileStream(Destinationfile, FileMode.Create);
                XslCompiledTransform xct = new XslCompiledTransform();
                xct.Load(Xsltfile);
                xct.Transform(Sourcefile, null, fist);
                fist.Close();
            }
        }
    }
