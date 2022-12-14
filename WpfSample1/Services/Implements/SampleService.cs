using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfSample1.Data;
using WpfSample1.Data.Models;
using WpfSample1.Services.Interfaces;

namespace WpfSample1.Services.Implements
{
    public class SampleService : ISampleService
    {

        private readonly SampleDbContext _dbContext;

        public SampleService(SampleDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public List<SeaFood> GetSeaFoods()
        {
            return _dbContext.SeaFoods.ToList();
        }

        public int UpdateSeaFood(SeaFood seaFood)
        {
            EntityEntry< SeaFood> _result;
            if (seaFood.Ma == 0)
            {
                _result = _dbContext.SeaFoods.Add(seaFood);
            }
            else
            {
                _result = _dbContext.SeaFoods.Update(seaFood);   
            }
            _dbContext.SaveChanges();
            return _result.Entity.Ma; 
        }
    }
}
