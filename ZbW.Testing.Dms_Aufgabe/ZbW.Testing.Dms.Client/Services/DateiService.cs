using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Services
{
    class DateiService
    {

        public String getDateiNamenMetaFile(Guid docId)
        {
            string dateiname = String.Concat(docId, "Metadata.xml");
            return dateiname;
        }

        public string getDateiName(Guid docId, string dateiTyp)
        {
            string dateiname = String.Concat(docId, "_Content", dateiTyp);
            return dateiname;
        }

        public void oeffneDatei(MetadataItem mdI)
        {
            Process.Start(mdI._pfadAlt);
        }

        public String serealisieren(MetadataItem mdI)
        {
            XmlSerializer xmlseri = new XmlSerializer(typeof(MetadataItem));
            StringWriter stringwrite = new StringWriter();
            XmlWriter xmlwrite = XmlWriter.Create(stringwrite);
            xmlseri.Serialize(xmlwrite, mdI);
            var seriXml = stringwrite.ToString();
            xmlwrite.Close();
            return seriXml;

        }

        public MetadataItem deseralisiereMetaData(string path)
        {
            XmlSerializer xmlseri = new XmlSerializer(typeof(MetadataItem));
            StreamReader lesen = new StreamReader(path);
            var mdI = (MetadataItem) xmlseri.Deserialize(lesen);
            lesen.Close();
            return mdI;
        }
    }
}
