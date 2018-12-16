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
using System.Data.SqlClient;

namespace MovieServiceFinalProject
{
    public class XML
    {
        private string v1;
        private string v2;

        private string Sourcefile { get; set; }
        private string Xsltfile { get; set; }
        private string Destinationfile { get; set; }

        public XML(string xml, string xslt, string destination)
        {
            this.Sourcefile = xml;
            this.Xsltfile = xslt;
            this.Destinationfile = destination;
        }

        public XML(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public void Transform() {
                FileStream fist1 = new FileStream(Destinationfile, FileMode.Create);
                XslCompiledTransform xct = new XslCompiledTransform();
                xct.Load(Xsltfile);
                xct.Transform(Sourcefile, null, fist1);
                fist1.Close();
            }
       }
    }
    
