using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    using RazorEngine.Configuration;
    class RazorSample
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public bool Create()
        {
            var config = new TemplateServiceConfiguration();

            return true;
        }
    }
}
