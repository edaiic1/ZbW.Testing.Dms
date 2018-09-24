using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.Testing.Dms.Client.Services
{
    class RepoService
    {
        private String repoDir;

        public string getRepo()
        {
            repoDir = ConfigurationManager.AppSettings.Get("RepositoryDir").ToString();
            return repoDir;
        }
    }
}
