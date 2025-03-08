using Newtonsoft.Json;
using System.Collections.Generic;

namespace Highlanders.Foundation.Services.Models
{
    public partial class AIQuestion
    {
        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("messages")]
        public List<Message> Messages { get; set; }

        [JsonProperty("temperature")]
        public long Temperature { get; set; }

        [JsonProperty("max_tokens")]
        public long MaxTokens { get; set; }

        [JsonProperty("top_p")]
        public long TopP { get; set; }

        [JsonProperty("frequency_penalty")]
        public long FrequencyPenalty { get; set; }

        [JsonProperty("presence_penalty")]
        public long PresencePenalty { get; set; }

        [JsonProperty("response_format")]
        public ResponseFormat ResponseFormat { get; set; }

        public AIQuestion()
        {
            ResponseFormat = new ResponseFormat();
        }
    }

    public partial class Message
    {
        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("content")]
        public List<Content> Content { get; set; }

        public Message()
        {
            Content = new List<Content>();
        }
    }

    public partial class Content
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public partial class ResponseFormat
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }



    public partial class AiAnswer
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("created")]
        public long Created { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("choices")]
        public List<Choice> Choices { get; set; }

        [JsonProperty("usage")]
        public Usage Usage { get; set; }

        [JsonProperty("service_tier")]
        public string ServiceTier { get; set; }

        [JsonProperty("system_fingerprint")]
        public string SystemFingerprint { get; set; }

        public AiAnswer()
        {
            Usage = new Usage();
            Choices = new List<Choice>();
        }
    }

    public partial class Choice
    {
        [JsonProperty("index")]
        public long Index { get; set; }

        [JsonProperty("message")]
        public MessageAnswer MessageAnswer { get; set; }

        [JsonProperty("logprobs")]
        public object Logprobs { get; set; }

        [JsonProperty("finish_reason")]
        public string FinishReason { get; set; }

        public Choice()
        {
            MessageAnswer = new MessageAnswer();
        }
    }

    public partial class MessageAnswer
    {
        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("refusal")]
        public object Refusal { get; set; }
    }

    public partial class Usage
    {
        [JsonProperty("prompt_tokens")]
        public long PromptTokens { get; set; }

        [JsonProperty("completion_tokens")]
        public long CompletionTokens { get; set; }

        [JsonProperty("total_tokens")]
        public long TotalTokens { get; set; }

        [JsonProperty("prompt_tokens_details")]
        public PromptTokensDetails PromptTokensDetails { get; set; }

        [JsonProperty("completion_tokens_details")]
        public CompletionTokensDetails CompletionTokensDetails { get; set; }

        public Usage()
        {
            PromptTokensDetails = new PromptTokensDetails();
            CompletionTokensDetails = new CompletionTokensDetails();
        }
    }

    public partial class CompletionTokensDetails
    {
        [JsonProperty("reasoning_tokens")]
        public long ReasoningTokens { get; set; }

        [JsonProperty("audio_tokens")]
        public long AudioTokens { get; set; }

        [JsonProperty("accepted_prediction_tokens")]
        public long AcceptedPredictionTokens { get; set; }

        [JsonProperty("rejected_prediction_tokens")]
        public long RejectedPredictionTokens { get; set; }
    }

    public partial class PromptTokensDetails
    {
        [JsonProperty("cached_tokens")]
        public long CachedTokens { get; set; }

        [JsonProperty("audio_tokens")]
        public long AudioTokens { get; set; }
    }
}