using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsQuery;
using Newtonsoft.Json;

namespace ApiExplorer.Core
{
    public class HtmlOutputGenerator
    {
        private readonly Assembly OutputAssembly;
        private CQ Dom;
        public HtmlOutputGenerator(Assembly assembly)
        {
            this.OutputAssembly = assembly;
            InitializeDomFromTemplate();
        }


        private void InitializeDomFromTemplate()
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ApiExplorer.Core.Template.html"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    Dom = CQ.Create(reader.ReadToEnd());
                }
            }
        }

        public HtmlOutputGenerator AddTitle()
        {
            string Output = this.OutputAssembly.ToString();
            string[] assemblyName = Output.Split(',');
            Dom.Select("title").Val(assemblyName[0]);
            return this;
        }

        public HtmlOutputGenerator AddResourceScript(ControllerNameExtractor Extractor)
        {
            IEnumerable<ResourceName> ResourceNames = Extractor.Extract(this.OutputAssembly);
            string value = JsonConvert.SerializeObject(ResourceNames);
            Dom.Select("#Resource").Text(value);
            return this;
        }

        public override string ToString()
        {
            return this.Dom.Render();
        }
    }
}
