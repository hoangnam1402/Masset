using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Dtos.SettingDtos
{
    public class UpdateSettingDto
    {
        [Required(ErrorMessage = "Name is required")] 
        public string? Name { get; set; }
        [Required(ErrorMessage = "Department is required")]
        public string? Department { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "FormatDate is required")]
        public string? FormatDate { get; set; }
        [Required(ErrorMessage = "Currency is required")]
        public string? Currency { get; set; }
        [Required(ErrorMessage = "Language is required")]
        public string? Language { get; set; }
        public IFormFile? Image { get; set; }

    }
}
