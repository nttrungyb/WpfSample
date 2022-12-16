using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLibrary1.Services.Models;

namespace WpfLibrary1.Services.Services.Interfaces
{
    public interface IBODServices
    {
        public GenericResult<List<PosInfoViewModel>> GetPosInfoList(string branchCode);
    }
}
