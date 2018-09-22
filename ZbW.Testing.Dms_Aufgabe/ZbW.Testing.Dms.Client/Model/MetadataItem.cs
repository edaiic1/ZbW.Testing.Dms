using System;

namespace ZbW.Testing.Dms.Client.Model
{
    internal class MetadataItem
    {
        public string _pfad { get; set; }
        public DateTime _datum { get; set; }
        public string _dateityp { get; set; }
        public string _dateiname { get; set; }
        public Guid _docID { get; set; }
        
        public DateTime hinzugefuegtAm { get; set; }

        public bool loeschungAktiv { get; set; }
        
        

    }
}