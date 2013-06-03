using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiExplorer.Core
{
    public class ResourceName
    {
        public string Name { get; private set; }
        public ResourceName(string name)
        {
            this.Name = name;
        }


    }
}
