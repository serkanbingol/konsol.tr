using System.Threading.Tasks;
namespace Fundamentals.S3.Core
{
    public interface IFundamentalService
    {
         Task RunCode();
         string GetHints(string serviceName);
    }
}