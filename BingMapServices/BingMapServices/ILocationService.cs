using System.ServiceModel;
using System.Threading.Tasks;

namespace BingMapServices
{
    [ServiceContract()]
    public interface ILocationService
    {
        [OperationContract]
        Task<string> GetLocationByLocality(string locality);
        [OperationContract]
        Task<string> GetLocationByZip(string zip);
    }
}