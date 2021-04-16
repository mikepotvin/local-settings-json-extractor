using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace LocalSettingsJsonExtractor
{
    class Program
    {

        static void Main(string[] args)
        {
            // Go to your azure function and open its app settings.
            // Hit Advanced Edit and copy paste all the contents into "data.json"
            dynamic data = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(@"PATH TO data.json"));

            StringBuilder sb = new StringBuilder();

            foreach (var d in data)
            {
                sb.AppendLine($"\"{d.name}\": \"{d.value}\",");
            }

            // Use included local.settings.json file 

            var localSettings = File.ReadAllText(@"PATH TO local.settings.json");

            localSettings = localSettings.Replace("{REPLACEME}", sb.ToString());

            File.WriteAllText("local.settings.json", localSettings);
        }
    }
}
