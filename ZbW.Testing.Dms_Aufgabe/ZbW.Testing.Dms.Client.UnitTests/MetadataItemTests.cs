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
    class MetadataItemTests
    {
        

        [Test]
        public void DateiHinzuFuegen_Normalfall_DateiwirdHinzugefuegt()
        {
            var metaDataItem = new MetadataItem();
            

            var repoDirFake = A.Fake<RepoService>();
            


        }
    }
}
