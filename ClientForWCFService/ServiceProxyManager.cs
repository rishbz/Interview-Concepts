using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WcfService1;

namespace ClientForWCFService
{
    public class ServiceProxyManager: ClientBase<IService1>
    {
        public void test(int a)
        {
            var final = base.Channel.GetData(a);
        }
    }
}
