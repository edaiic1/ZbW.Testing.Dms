using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.Services
{
    public class SuchService
    {
        private List<MetadataItem> _mdIs;
        private RepoService _repoService;
        private DateiService _dateiService;
        private string _zielPfad;


        public SuchService()
        {
            _repoService = new RepoService();
            _dateiService = new DateiService();
            _zielPfad = _repoService.getRepo();
        }

        public List<MetadataItem> MetadataItems
        {
            get { return _mdIs; }
            set { _mdIs = value; }
        }

        public List<MetadataItem> FilterMetadataItems(string type, string searchParam)
        {
            if (String.IsNullOrEmpty(searchParam) && String.IsNullOrEmpty(type))
            {
                return this.MetadataItems;
            }

            if (String.IsNullOrEmpty(searchParam))
            {
                searchParam = "";
            }

            var gefilterteItems = this.MetadataItems.Where(item =>
            {
                return (item._bezeichnung.Contains(searchParam) ||
                        item.stichwoerter.Contains(searchParam) ||
                        item.hinzugefuegtAm.ToString().Contains(searchParam) ||
                        item._datum.ToString().Contains(searchParam)) &&
                       (String.IsNullOrEmpty(type) || item._dateityp.Equals(type));
            }).ToList();

            return gefilterteItems;
        }


        private String[] GetAlleOrdnerPfade(String targetPath)
        {
            return Directory.GetDirectories(targetPath);
        }

        private ArrayList GetAlleXmlPfade(String folderPath)
        {
            ArrayList xmlPfade = new ArrayList();
            foreach (string file in Directory.EnumerateFiles(folderPath, "*.xml"))
            {
                xmlPfade.Add(file);
            }

            return xmlPfade;
        }


        public List<MetadataItem> GetAlleMetadataItems()
        {
            var OrdnerPfade = this.GetAlleOrdnerPfade(this._zielPfad);
            ArrayList xmlPfadeVonAllenOrdnern = new ArrayList();
            ArrayList metadataItemListe = new ArrayList();

            foreach (string folderPath in OrdnerPfade)
            {
                var XmlPfadVonEinemOrdner = this.GetAlleXmlPfade(folderPath);
                xmlPfadeVonAllenOrdnern.AddRange(XmlPfadVonEinemOrdner);
            }

            foreach (var xmlPath in xmlPfadeVonAllenOrdnern)
            {

                metadataItemListe.Add(this._dateiService.deserealisiereMetadataItem(_dateiService.seriTestable, (String)xmlPath));
            }

            this.MetadataItems = metadataItemListe.Cast<MetadataItem>().ToList();
            return this.MetadataItems;
        }


    }



}
