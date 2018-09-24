using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.Model
{
    internal class MetadataItem
    {
        public string _pfadAlt { get; set; }
        public string _pfadNeu { get; set; }
        public DateTime _datum { get; set; }
        public string _dateityp { get; set; }
        public string _dateiname { get; set; }
        public Guid _docID { get; set; }

        public string _bezeichnung { get; set; }

        public string stichwoerter { get; set; }
        public DateTime hinzugefuegtAm { get; set; }

        public bool loeschungAktiv { get; set; }



        private RepoService _repoService;
        private DateiService _dateiService;

        public MetadataItem()
        {
            _repoService = new RepoService();
            _dateiService = new DateiService();
        }

        public void Dateihinzufuegen(MetadataItem mdI, bool loeschungAktiv)
        {
            var repoDir = _repoService.getRepo();
            var docId = Guid.NewGuid();
            var jahr = mdI._datum.Year;
            var dateityp = Path.GetExtension(mdI._pfadAlt);
            var zielDir = Path.Combine(repoDir, jahr.ToString());
            var metaDateiName = _dateiService.getDateiNamenMetaFile(docId);
            var dateiName = _dateiService.getDateiName(docId, dateityp);

            
            File.Copy(mdI._pfadAlt, Path.Combine(zielDir, dateiName));


        }


 

    }
}