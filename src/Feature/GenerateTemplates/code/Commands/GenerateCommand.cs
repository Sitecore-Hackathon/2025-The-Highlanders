using Highlanders.Feature.GenerateTemplates.Repository;
using Sitecore.DependencyInjection;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using System.Collections.Specialized;

namespace Highlanders.Feature.GenerateTemplates.Commands
{
	public class GenerateCommand: Command
    {
        private readonly ICreateTemplatesRepository _CreateTemplatesRepository;
        public GenerateCommand()
        {
            _CreateTemplatesRepository = (ICreateTemplatesRepository)ServiceLocator.ServiceProvider.GetService(typeof(ICreateTemplatesRepository));
        }

        public override void Execute(CommandContext context)
        {
            Sitecore.Context.ClientPage.Start(this, "Run", new NameValueCollection
            {
            });
        }

        protected void Run(ClientPipelineArgs args)
        {
            if(!args.IsPostBack)
            {
                SheerResponse.Input("Describe the template you want to create. e.g: The data I want to register in this template is related to Blogs.", "Pront", string.Empty);
                args.WaitForPostBack();
            }
            else
            {
                if (args.HasResult)
                {
                    string prontInput = args.Result;
                    _CreateTemplatesRepository.CreateYmlFiles(prontInput);
                }
            }
        }
    }
}