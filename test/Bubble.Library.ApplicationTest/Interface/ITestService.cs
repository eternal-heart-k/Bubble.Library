using System.Threading.Tasks;

namespace Bubble.Library.ApplicationTest.Interface
{
    public interface ITestService
    {
        Task<string> TestOperationIdAsync(bool error);

        Task<string> TestRequestContextAsync(string userId, string remark);
    }
}
