using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSample1
{
    public class ApplicationContext
    {
        public static string AppName { get; set; }

        public static string AppVersion { get; set; }
        
        public static bool IsLogged { get; set; }
    }
}
