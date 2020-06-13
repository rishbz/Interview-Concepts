using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClientForWCFService
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServiceProxyManager proxy = new ServiceProxyManager();
            proxy.test(5);
        }
    }
}
