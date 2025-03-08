using Highlanders.Feature.GenerateTemplates.Models;
using Highlanders.Foundation.DependencyInjection;
using Highlanders.Foundation.Services;
using Highlanders.Foundation.Services.Models;
using Highlanders.Foundation.Services.ServiceLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Highlanders.Feature.GenerateTemplates.Repository
{
    [Service(typeof(ICreateTemplatesRepository))]
    public class CreateTemplatesRepository: ICreateTemplatesRepository
    {
        IAIIntegration _iAIIntegration;

        public CreateTemplatesRepository(IAIIntegration iAIIntegration)
        {
            _iAIIntegration = iAIIntegration;
        }

        public void CreateYmlFiles(string requirement)
        {
            string prompt = "create and provide the Sitecore templates ymls based in Helix convention for items, remember that the template name is the main folder and its yml at the same level, after that, comes folders with the section name, with their corresponding ymls, and inside the section folders there are the fields with their corresponding ymls. The structure of the json result is {  'ymlFiles': [    {      'path': '',      'content': ''    }]} no explanations only the json as asked. The content part of the ymls of folders needs these fields with the pattern {GUID},  ID : {GUID}, Parent : {GUID}, Template : {GUID}, Path: [path/name.yml] (Different to the first path). The fields ymls needs SharedFields:  -ID: {GUID}, Hint: \"Type\", Value: Type of field (you have to give me a valid Sitecore type field), it is important the hyphen next to ID field because the next fields after SharedFields are indented inside it.. You have to mark which field is child of a folder, example Field1.Parent: {GUID1}, Field2.Parent:{GUID2}, I need this to create the GUIDs dynamically and map to the respective fields. "+ requirement+". This information will be used to create yml files with the following structure for fields ID: \"5ed51867-63a9-4152-b325-5c229fd03c00\" \r\nParent: \"e5f585ba-bea8-4b82-b8ec-a55a9a34fe9e\"\r\nTemplate: \"ab86861a-6030-46c5-b394-e8f99e8b87db\"\r\nPath: /sitecore/templates/Feature/Highlanders/Test\r\nSharedFields:\r\n- ID: \"12c33f3f-86c5-43a5-aeb4-5598cec45116\"\r\n  Hint: __Base template\r\n  Value: \"{1930BBEB-7805-471A-A3BE-4858AC7CF696}\" and for folder's yml ID: \"6a6226ff-0e94-4aa6-a1a9-a434d0941099\"\r\nParent: \"69d4a0c3-1482-4eaf-8237-a63344fc03a1\"\r\nTemplate: \"e269fbb5-3750-427a-9149-7aa950b49301\"\r\nPath: /sitecore/templates/Feature/Highlanders/Sample/General Be sure maintain both the folder and fields structure as asked. Every content should have also a path, see the examples well.";
            Task<AiAnswer> json = _iAIIntegration.GetAIResponse(prompt);

            AiAnswer answer = json.Result;

            var ymlFilesContainer = JsonConvert.DeserializeObject<YmlFileContainer>(answer.Choices[0].MessageAnswer.Content.Replace("```json","").Replace("```","").Trim());

            string mainPath = "C:\\Projects\\2025-The-Highlanders\\src\\Feature\\GenerateTemplates\\serialization\\Templates\\Highlanders\\";
            foreach (var file in ymlFilesContainer.YmlFiles)
            {
                string directoryPath = Path.GetDirectoryName(file.Path);
                if (!Directory.Exists(mainPath+directoryPath))
                {
                    Directory.CreateDirectory(mainPath+ directoryPath);
                }

                File.WriteAllText(mainPath + file.Path, file.Content);
            }


        }
    }
}