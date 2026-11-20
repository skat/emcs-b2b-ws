using System.Threading.Tasks;
using System.Xml.Linq;

namespace UFSTWSSecuritySample
{
    public interface IApiClient
    {
        Task<XElement> CallService(IPayloadWriter payloadWriter, string endpoint);
    }
}
