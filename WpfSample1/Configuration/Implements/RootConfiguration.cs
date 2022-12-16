using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfSample1.Configuration.Interfaces;

namespace WpfSample1.Configuration.Implements
{
    public class RootConfiguration : IRootConfiguration
    {
        public AdminConfiguration AdminConfiguration { get; set; } = new AdminConfiguration();
    }
}
