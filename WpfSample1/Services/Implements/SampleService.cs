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
    }
}
