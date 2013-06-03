using ApiExplorer.Core;
using NSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;
using TestLibraryApi;


namespace ApiExplorer.AcceptanceTest
{
    public class Get_all_the_resource_Spec:nspec
    {
       
        public void Given_the_Api_Controller_Classes()
        {
            it["Should Get all the names of the Class"] = () =>
            {
                dynamic ControllerExtractor = TestInstance.ControllerExtractor;
                IList<ResourceName> ResourceNames=ControllerExtractor.Extract(Assembly.GetAssembly(typeof(ValueController)));
                ResourceNames.should_contain(p=>p.Name=="Value");
            };
        }
    }
}
