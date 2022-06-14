using System.Collections.Generic;
using System.Threading.Tasks;

namespace Region.Service
{
    public interface IAutoFillService
    {
       Task<List<string>> GetPostalCodes(string postCode);
    }
}
