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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Sitecore.Configuration;
using Highlanders.Feature.GenerateTemplates.Helpers;
using System.Text;

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
            string prompt = Settings.GetSetting("BasePrompt");
            prompt = prompt.Replace("{0}", requirement);
            Task<AiAnswer> json = _iAIIntegration.GetAIResponse(prompt);
                        
            AiAnswer answer = json.Result;

            var finalJson = answer.Choices[0].MessageAnswer.Content.Replace("```json", "").Replace("```", "").Trim();
            
            var guidMappings = new Dictionary<string, string>();
            
            var guidPattern = new Regex(@"\{(GUID\d+)\}");
            
            finalJson = guidPattern.Replace(finalJson, match =>
            {
                string key = match.Groups[1].Value;
                if (!guidMappings.ContainsKey(key))
                {
                    guidMappings[key] = Guid.NewGuid().ToString();
                }
                return guidMappings[key];
            });

            var ymlFilesContainer = JsonConvert.DeserializeObject<YmlFileContainer>(finalJson);
                        
            string mainPath = Settings.GetSetting("SitecoreTemplatesPath");
            foreach (var file in ymlFilesContainer.YmlFiles)
            {
                string directoryPath = Path.GetDirectoryName(file.Path);
                if (!Directory.Exists(mainPath+directoryPath))
                {
                    Directory.CreateDirectory(mainPath+ directoryPath);
                }

                File.WriteAllText(mainPath + file.Path, "---\n"+file.Content);
            }

            SerializationHelper.PushSerialization();
        }
    }
}