using Highlanders.Feature.GenerateTemplates.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Highlanders.Feature.GenerateTemplates.Repository
{
    public class CreateTemplatesRepository
    {
        public void CreateYmlFiles(string jsonYmlStructure)
        {
            string json = "{\r\n  \"ymlFiles\": [\r\n    {\r\n      \"path\": \"/serialization/Feature/Library/Templates/Book/_Common.yml\",\r\n      \"content\": \"---\\nID: \\\"{GUID}\\\"\\nParent: \\\"{GUID}\\\"\\nTemplate: \\\"{GUID}\\\"\\nPath: \\\"/sitecore/templates/Feature/Library/_Common\\\"\\nItemName: \\\"_Common\\\"\"\r\n    },\r\n    {\r\n      \"path\": \"/serialization/Feature/Library/Templates/Book/Book.yml\",\r\n      \"content\": \"---\\nID: \\\"{GUID}\\\"\\nParent: \\\"{GUID}\\\"\\nTemplate: \\\"{3E2A6DE6-35D1-4565-B6B7-AC0D4F2839DB}\\\"\\nPath: \\\"/sitecore/templates/Feature/Library/Book\\\"\\nItemName: \\\"Book\\\"\\nSharedFields: []\\nUnversionedFields: []\\nVersionedFields: []\"\r\n    },\r\n    {\r\n      \"path\": \"/serialization/Feature/Library/Template Sections/Book/Book Information.yml\",\r\n      \"content\": \"---\\nID: \\\"{GUID}\\\"\\nParent: \\\"{GUID}\\\"\\nTemplate: \\\"{GUID}\\\"\\nPath: \\\"/sitecore/templates/Feature/Library/Book/__Sections/Book Information\\\"\\nItemName: \\\"Book Information\\\"\"\r\n    },\r\n    {\r\n      \"path\": \"/serialization/Feature/Library/Template Sections/Book/Publishing Details.yml\",\r\n      \"content\": \"---\\nID: \\\"{GUID}\\\"\\nParent: \\\"{GUID}\\\"\\nTemplate: \\\"{GUID}\\\"\\nPath: \\\"/sitecore/templates/Feature/Library/Book/__Sections/Publishing Details\\\"\\nItemName: \\\"Publishing Details\\\"\"\r\n    },\r\n    {\r\n      \"path\": \"/serialization/Feature/Library/Template Fields/Book/Book Information/Title.yml\",\r\n      \"content\": \"---\\nID: \\\"{GUID}\\\"\\nParent: \\\"{GUID}\\\"\\nTemplate: \\\"{GUID}\\\"\\nPath: \\\"/sitecore/templates/Feature/Library/Book/__Sections/Book Information/Title\\\"\\nItemName: \\\"Title\\\"\\nSharedFields:\\n- ID: \\\"{1930BBEB-7805-471A-A3BE-4858AC7CF696}\\\"\\n  Value: \\\"Single-Line Text\\\"\"\r\n    },\r\n    {\r\n      \"path\": \"/serialization/Feature/Library/Template Fields/Book/Book Information/Author.yml\",\r\n      \"content\": \"---\\nID: \\\"{GUID}\\\"\\nParent: \\\"{GUID}\\\"\\nTemplate: \\\"{GUID}\\\"\\nPath: \\\"/sitecore/templates/Feature/Library/Book/__Sections/Book Information/Author\\\"\\nItemName: \\\"Author\\\"\\nSharedFields:\\n- ID: \\\"{1930BBEB-7805-471A-A3BE-4858AC7CF696}\\\"\\n  Value: \\\"Single-Line Text\\\"\"\r\n    },\r\n    {\r\n      \"path\": \"/serialization/Feature/Library/Template Fields/Book/Book Information/ISBN.yml\",\r\n      \"content\": \"---\\nID: \\\"{GUID}\\\"\\nParent: \\\"{GUID}\\\"\\nTemplate: \\\"{GUID}\\\"\\nPath: \\\"/sitecore/templates/Feature/Library/Book/__Sections/Book Information/ISBN\\\"\\nItemName: \\\"ISBN\\\"\\nSharedFields:\\n- ID: \\\"{1930BBEB-7805-471A-A3BE-4858AC7CF696}\\\"\\n  Value: \\\"Single-Line Text\\\"\"\r\n    },\r\n    {\r\n      \"path\": \"/serialization/Feature/Library/Template Fields/Book/Book Information/Summary.yml\",\r\n      \"content\": \"---\\nID: \\\"{GUID}\\\"\\nParent: \\\"{GUID}\\\"\\nTemplate: \\\"{GUID}\\\"\\nPath: \\\"/sitecore/templates/Feature/Library/Book/__Sections/Book Information/Summary\\\"\\nItemName: \\\"Summary\\\"\\nSharedFields:\\n- ID: \\\"{1930BBEB-7805-471A-A3BE-4858AC7CF696}\\\"\\n  Value: \\\"Multi-Line Text\\\"\"\r\n    },\r\n    {\r\n      \"path\": \"/serialization/Feature/Library/Template Fields/Book/Publishing Details/Publisher.yml\",\r\n      \"content\": \"---\\nID: \\\"{GUID}\\\"\\nParent: \\\"{GUID}\\\"\\nTemplate: \\\"{GUID}\\\"\\nPath: \\\"/sitecore/templates/Feature/Library/Book/__Sections/Publishing Details/Publisher\\\"\\nItemName: \\\"Publisher\\\"\\nSharedFields:\\n- ID: \\\"{1930BBEB-7805-471A-A3BE-4858AC7CF696}\\\"\\n  Value: \\\"Single-Line Text\\\"\"\r\n    },\r\n    {\r\n      \"path\": \"/serialization/Feature/Library/Template Fields/Book/Publishing Details/PublishedDate.yml\",\r\n      \"content\": \"---\\nID: \\\"{GUID}\\\"\\nParent: \\\"{GUID}\\\"\\nTemplate: \\\"{GUID}\\\"\\nPath: \\\"/sitecore/templates/Feature/Library/Book/__Sections/Publishing Details/PublishedDate\\\"\\nItemName: \\\"PublishedDate\\\"\\nSharedFields:\\n- ID: \\\"{1930BBEB-7805-471A-A3BE-4858AC7CF696}\\\"\\n  Value: \\\"Date\\\"\"\r\n    }\r\n  ]\r\n}";
            
            var ymlFilesContainer = JsonConvert.DeserializeObject<YmlFileContainer>(json);

            foreach (var file in ymlFilesContainer.YmlFiles)
            {
                string directoryPath = Path.GetDirectoryName(file.Path);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                File.WriteAllText(file.Path, file.Content);
            }


        }
    }
}