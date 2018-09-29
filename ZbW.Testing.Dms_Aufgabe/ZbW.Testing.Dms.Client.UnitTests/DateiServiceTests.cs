using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Services;


namespace ZbW.Testing.Dms.Client.UnitTests
{
    [TestFixture]
    class DateiServiceTests
    {

        [Test]
        public void getDateiName_Normalfall_RichtigerFileName()
        {
            var dS = new DateiService();
            var dateityp = ".pdf"; 
            var docId = new Guid("126f26a3-722b-5b62-52e4-51557f6ab412");

            var resultat = dS.getDateiName(docId, dateityp);

            Assert.That(resultat,Is.EqualTo(docId + "_Content" + dateityp));
        }



        [Test]
        public void getMetaDateiName_NormallFall_RichtigerFileName()
        {
            var dS = new DateiService();
            var docId = new Guid("126f26a3-722b-5b62-52e4-51557f6ab412");

            var resultat = dS.getDateiNamenMetaFile(docId);

            Assert.That(resultat,Is.EqualTo(docId + "Metadata.xml"));
        }


        [Test]
        public void serealisieren_Normallfall_GibtNichtNull()
        {
            var dS = new DateiService();
            var seri_Mock = A.Fake<SerialisierenTestable>();
            var md_Stub = A.Fake<MetadataItem>();

            var resultat = dS.serealisiereMetaData(seri_Mock, md_Stub);

            Assert.That(resultat, Is.Not.Null);
        }

        [Test]

        public void deserealisieren_Normalfall_GibtNichtNull()
        {
            var dS = new DateiService();
            var seri_Mock = A.Fake<SerialisierenTestable>();

            var resultat = dS.deserealisiereMetadataItem(seri_Mock, "Test");

            Assert.That(resultat, Is.Not.Null);

        }




        }

    }

