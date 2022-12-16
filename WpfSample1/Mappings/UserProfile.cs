using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfSample1.Data.Models;
using WpfSample1.Models;

namespace WpfSample1.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<SeaFood, SeaFoodWithCheckBox>();
            CreateMap<SeaFoodWithCheckBox, SeaFood>();
        }
    }
}
