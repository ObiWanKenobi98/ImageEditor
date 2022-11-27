using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Core
{
    public interface ConfigurationChain
    {
        public IHostBuilder addConfiguration(IHostBuilder hostBuilder);
    }
}
