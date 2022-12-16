using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary1.Services.Models;
using WpfSample1.Data.Models;
using WpfSample1.Models;

namespace WpfSample1.Services.Interfaces
{
    public interface ISampleService
    {
        public List<SeaFoodWithCheckBox> GetSeaFoods();

        public int UpdateSeaFood(SeaFoodWithCheckBox seaFood);

        public int RemoveSeaFood(int ma);

        public List<PosInfoViewModel> GetPosList(string branchCode);
    }
}
