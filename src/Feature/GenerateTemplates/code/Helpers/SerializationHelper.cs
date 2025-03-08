using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Sitecore.Configuration;

namespace Highlanders.Feature.GenerateTemplates.Helpers
{
    public class SerializationHelper
    {
        public static void PushSerialization()
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                WorkingDirectory = Settings.GetSetting("SitecoreSolutionBasePath"), //"C:\\Projects\\2025-The-Highlanders",
                FileName = "dotnet",
                Arguments = "sitecore ser push",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process { StartInfo = psi })
            {
                process.OutputDataReceived += (sender, args) => Debug.WriteLine(args.Data);
                process.ErrorDataReceived += (sender, args) => Debug.WriteLine("ERROR: " + args.Data);

                process.Start();
            }
        }
    }
}