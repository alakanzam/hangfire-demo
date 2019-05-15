using System;
using System.IO;
using System.Threading.Tasks;
using Hangfire;
using HangfireShared.Services.Interfaces;
using HangfireWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HangfireWeb.Controllers
{
    [Route("api/queue")]
    public class QueueController : Controller
    {
        #region Properties

        private readonly IBackgroundJobClient _backgroundJobClient;

        #endregion

        #region Constructor

        public QueueController(IBackgroundJobClient backgroundJobClient)
        {
            _backgroundJobClient = backgroundJobClient;
        }

        #endregion

        #region Methods

        [HttpGet("")]
        public IActionResult Get()
        {
            _backgroundJobClient.Enqueue((IUserService userService) => userService.ImportUserAsync("Hello world"));
            return Ok();
        }

        [HttpPost]
        public IActionResult UploadBinaryAsync(UploadBinaryUserTemplateViewModel model)
        {
            using (var memoryStream = new MemoryStream())
            {
                model.Template.CopyTo(memoryStream);
                var binaries = memoryStream.ToArray();
                _backgroundJobClient.Enqueue((IUserService userService) => userService.ImportUserAsync(binaries));
            }

            return Ok();
        }

        #endregion
    }
}