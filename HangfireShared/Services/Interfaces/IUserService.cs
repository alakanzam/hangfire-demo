using System.Threading.Tasks;

namespace HangfireShared.Services.Interfaces
{
    public interface IUserService
    {
        #region Methods

        Task<string> ImportUserAsync(string templateName);

        Task ImportUserAsync(byte[] bytes);

        #endregion
    }
}