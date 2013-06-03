using ApiExplorer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLibraryApi;

namespace ApiExplorer.AcceptanceTest
{
    public static class TestInstance
    {
        public static dynamic ControllerExtractor = new ControllerNameExtractor();

        public static dynamic HtmlOutputGenerator = new HtmlOutputGenerator(typeof(ValueController).Assembly);
    }
}
