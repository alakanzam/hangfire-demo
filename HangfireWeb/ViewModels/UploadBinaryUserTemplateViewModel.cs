using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace HangfireWeb.ViewModels
{
    public class UploadBinaryUserTemplateViewModel
    {
        #region Properties

        [Required]
        public IFormFile Template { get; set; }

        #endregion
    }
}