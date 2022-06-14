using Region.Entities;
using System.Threading.Tasks;

namespace Region.Service
{
    public interface ILocationService
    {
        public Task<LocationDetails> GetAsync(string postalCode);
    }
}
