using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfSample1.Data.Models;

namespace WpfSample1.Services.Interfaces
{
    public interface ISampleService
    {
        public List<SeaFood> GetSeaFoods();
    }
}
