using CsQuery;
using NSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLibraryApi;

namespace ApiExplorer.AcceptanceTest
{
    public class Adding_the_Title_To_Html:nspec
    {
        public void Given_the_Api_Assembly()
        {
            it["Assembly Name should be title for the Help page"] = () =>
            { 
                dynamic OutputGenerator = TestInstance.HtmlOutputGenerator;
                OutputGenerator=OutputGenerator.AddTitle();
                CQ html=CQ.Create(OutputGenerator.ToString());
                html.Select("title").Val().should_be("TestLibraryApi");
            };
        }

      
    }
}
