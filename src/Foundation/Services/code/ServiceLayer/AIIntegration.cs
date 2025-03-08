using Highlanders.Foundation.Services.Models;
using Newtonsoft.Json;
using Sitecore.Configuration;
using Sitecore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Highlanders.Foundation.DependencyInjection;

namespace Highlanders.Foundation.Services.ServiceLayer
{
    [Service(typeof(IAIIntegration))]
    public class AIIntegration : IAIIntegration
    {
        public async Task<AiAnswer> GetAIResponse(string input)
        {
            var model = new AiAnswer();
            try
            {
                using (var client = new HttpClient())
                {
                    var idTokenCookie = Settings.GetSetting("ChatGPTApiKey");
                    var url = Settings.GetSetting("ChatGPTUrl");

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", idTokenCookie);

                    var question = GetQuestionModel(input);
                    var jsonQuestion = JsonConvert.SerializeObject(question, Formatting.Indented);
                    //var jsonBody = $@"{{""model"": ""gpt-4o"",""messages"": [{{ ""role"": ""system"", ""content"": ""you are a content editor in sitecore"" }},{{ ""role"": ""user"", ""content"": ""Transform the given variable by replacing each word separated by pipes (|) with its corresponding Sitecore field type. Allowed Sitecore field types: Date,Datetime,Number,Single-Line Text,Rich Text.Classification Rules: If the word contains only numbers, classify it as Number. If the word matches a date format like dd/MM/yyyy or yyyy-MM-dd, classify it as Date. If the word matches a datetime format (including time), classify it as Datetime. If the word has more than 50 characters or has html tags, classify it as Rich Text. Respond only the replaced variable. Use this variable: abc|123"" }}]}}";

                    StringContent content = new StringContent(jsonQuestion, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(url, content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        model = JsonConvert.DeserializeObject<AiAnswer>(data);
                    }
                    else
                    {
                        Log.Error("An error occured in fetching OpenAI: " + response.StatusCode, this);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error in AIIntegration.GetResponse", ex, this);
            }

            return model;
        }

        private AIQuestion GetQuestionModel(string input)
        {
            var question = new AIQuestion
            {
                Model = "gpt-4o",
                Messages = new List<Message>
                {
                    new Message
                    {
                        Role = "user",
                        Content = new List<Content>
                        {
                            new Content
                            {
                                Type = "text",
                                Text = input
                            }
                        }
                    }
                },
                Temperature = 1,
                MaxTokens = 10000,
                TopP = 1,
                FrequencyPenalty = 0,
                PresencePenalty = 0,
                ResponseFormat = new ResponseFormat
                {
                    Type = "text"
                }
            };
            return question;
        }
    }
}