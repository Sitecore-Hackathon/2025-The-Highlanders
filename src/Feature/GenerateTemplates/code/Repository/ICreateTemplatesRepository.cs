using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Highlanders.Feature.GenerateTemplates.Repository
{
    public interface ICreateTemplatesRepository
    {
        void CreateYmlFiles(string jsonYmlStructure);
    }
}