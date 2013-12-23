using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecurityDemo.Web
{
    class OurPolicyProvider : Microsoft.Owin.Cors.ICorsPolicyProvider
    {
        public System.Threading.Tasks.Task<System.Web.Cors.CorsPolicy> GetCorsPolicyAsync(Microsoft.Owin.IOwinRequest request)
        {
            var task = new System.Threading.Tasks.Task<System.Web.Cors.CorsPolicy>();

            return task;
        }
    }
}
