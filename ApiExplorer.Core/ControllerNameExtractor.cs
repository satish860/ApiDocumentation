using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace ApiExplorer.Core
{
    public class ControllerNameExtractor
    {
        public IEnumerable<ResourceName> Extract(Assembly assembly)
        {
            IEnumerable<Type> types = assembly.GetTypes().Where(p => p.IsSubclassOf(typeof(ApiController)));
            return types.Select(p => {
                return new ResourceName(p.Name.Replace("Controller", string.Empty));
            }).ToList();
        }
    }
}
