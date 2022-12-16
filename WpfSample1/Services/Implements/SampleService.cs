using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary1.Services.Models;
using WpfLibrary1.Services.Services.Interfaces;
using WpfSample1.Data;
using WpfSample1.Data.Models;
using WpfSample1.Models;
using WpfSample1.Services.Interfaces;

namespace WpfSample1.Services.Implements
{
    public class SampleService : ISampleService
    {

        private readonly SampleDbContext _dbContext;
        private readonly IMapper _mapper;

        private readonly IBODServices _bodServices;

        public SampleService(SampleDbContext dbContext, IMapper mapper, IBODServices bodServices)
        {
            _dbContext = dbContext; 
            _mapper = mapper;
            _bodServices = bodServices;
        }

        public List<SeaFoodWithCheckBox> GetSeaFoods()
        {            
            var data = _dbContext.SeaFoods.ToList();
            if (data.Count > 0)
            {
                List<SeaFoodWithCheckBox> _result = new List<SeaFoodWithCheckBox>();
                for (int i = 0; i < data.Count; i++)
                {
                    var _item = _mapper.Map<SeaFoodWithCheckBox>(data[i]);
                    _result.Add(_item);
                }
                return _result;
            }
            else
            {
                return null;
            }
        }

        public int UpdateSeaFood(SeaFoodWithCheckBox seaFoodWithCheckBox)
        {
            SeaFood _seaFood = _mapper.Map<SeaFood>(seaFoodWithCheckBox);
            EntityEntry< SeaFood> _result;
            if (_seaFood.Ma == 0)
            {
                _result = _dbContext.SeaFoods.Add(_seaFood);
            }
            else
            {
                _result = _dbContext.SeaFoods.Update(_seaFood);   
            }
            _dbContext.SaveChanges();
            return _result.Entity.Ma; 
        }

        public int RemoveSeaFood(int ma)
        {
            EntityEntry<SeaFood> _result;
            if (ma != 0)
            {
                var _currItem = _dbContext.SeaFoods.Where(w => w.Ma == ma).FirstOrDefault();   
                if (_currItem != null)
                {
                    _result = _dbContext.SeaFoods.Remove(_currItem);
                    _dbContext.SaveChanges();
                    return _result.Entity.Ma;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        public List<PosInfoViewModel> GetPosList(string branchCode)
        {
            var _response = _bodServices.GetPosInfoList(branchCode);
            if (_response.IsSuccess)
            {
                return _response.Result;
            }
            else
            {
                return null;
            }
        }
    }
}
