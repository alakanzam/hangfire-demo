using System;
using System.Text;
using System.Threading.Tasks;
using HangfireShared.Services.Interfaces;

namespace HangfireConsole.Services.Implementations
{
    public class UserService : IUserService
    {
        public Task<string> ImportUserAsync(string templateName)
        {
            Console.WriteLine($"Template name = {templateName}");
            return Task.FromResult(templateName);
        }

        public Task ImportUserAsync(byte[] bytes)
        {
            var base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            Console.WriteLine(base64String);
            return Task.FromResult(base64String);
        }
    }
}