using Highlanders.Foundation.Services.Models;
using System.Threading.Tasks;

namespace Highlanders.Foundation.Services.ServiceLayer
{
    public interface IAIIntegration
    {
        Task<AiAnswer> GetAIResponse(string input);
    }
}
