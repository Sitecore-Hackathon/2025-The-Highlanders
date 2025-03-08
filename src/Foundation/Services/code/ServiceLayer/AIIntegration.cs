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

namespace Highlanders.Foundation.Services.ServiceLayer
{
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
                    var url = Settings.GetSetting("ChatGPTApiUrl");

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", idTokenCookie);

                    var question = GetQuestionModel(input);
                    var jsonQuestion = JsonConvert.SerializeObject(question, Formatting.Indented);
                    StringContent content = new StringContent(jsonQuestion, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        model = JsonConvert.DeserializeObject<AiAnswer>(data);
                    }
                    else
                    {
                        Log.Error("An error occured in fetching getBulletinsSearchData: " + response.StatusCode, this);
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