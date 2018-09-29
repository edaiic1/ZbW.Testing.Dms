using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ZbW.Testing.Dms.Client.Services
{
    public class SerialisierenTestable
    {

        public virtual void OpenFile(MetadataItem mdI)
        {
            Process.Start(mdI._pfadNeu);
        }


        public virtual String SerialisiereMetadataItem(SerialisierenTestable seriTestable, MetadataItem mdI)
        {

            XmlSerializer xmlseri = new XmlSerializer(typeof(MetadataItem));
            StringWriter stringwriter = new StringWriter();
            XmlWriter writer = XmlWriter.Create(stringwriter);

            xmlseri.Serialize(writer, mdI);

            var seriXml = stringwriter.ToString();

            writer.Close();

            return seriXml;
        }

        public virtual MetadataItem DeserealisiereMetadataItem(String pfad)
        {
            XmlSerializer seri = new XmlSerializer(typeof(MetadataItem));

            StreamReader lesen = new StreamReader(pfad);
            var mdI = (MetadataItem)seri.Deserialize(lesen);
            lesen.Close();

            return mdI;
        }


    }
}

