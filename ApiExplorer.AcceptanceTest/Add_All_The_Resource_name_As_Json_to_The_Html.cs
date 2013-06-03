using ApiExplorer.Core;
using CsQuery;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiExplorer.AcceptanceTest
{
    public class Add_All_The_Resource_name_As_Json_to_The_Html : nspec
    {
        public void Given_the_Assembly_Name()
        {
            it["Should add a JSON Object to the Resource Script Tag "] = () =>
            {
                
                dynamic HtmlGenerator = TestInstance.HtmlOutputGenerator;
                HtmlGenerator = HtmlGenerator.AddResourceScript(TestInstance.ControllerExtractor);
                CQ dom = CQ.Create(HtmlGenerator.ToString());
                string value = dom.Select("#Resource").Text();
                IEnumerable<ResourceName> Resources = JsonConvert.DeserializeObject<IEnumerable<ResourceName>>(value);
                Resources.should_not_be_null();
            };
        }
    }
}
