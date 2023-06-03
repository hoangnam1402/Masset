using Contracts.Dtos.SettingDtos;
using Microsoft.AspNetCore.Http;

namespace Business.Interfaces
{
    public interface ISettingService
    {
        Task<SettingDto?> GetAsync();
        Task<SettingDto?> UpdateAsync(UpdateSettingDto updateRequest);
        Task<bool?> UpdateLogoAsync(IFormFile image);

    }
}
