using AutoMapper;
using Business.Interfaces;
using Contracts.Dtos.SettingDtos;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class SettingService : ISettingService
    {
        private readonly IBaseRepository<Setting> _settingRepository;
        private readonly IMapper _mapper;

        public SettingService(IBaseRepository<Setting> settingRepository, IMapper mapper)
        {
            _settingRepository = settingRepository;
            _mapper=mapper;
        }

        public async Task<SettingDto?> GetAsync()
        {
            var setting = await _settingRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == 1);
            if (setting != null)
            {
                var result = _mapper.Map<SettingDto>(setting);
                if (setting.Logo != null)
                {
                    result.Image = Convert.ToBase64String(setting.Logo);
                }
                return result;
            }
            return null;
        }

        public async Task<SettingDto?> UpdateAsync(UpdateSettingDto updateRequest)
        {
            var setting = await _settingRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == 1);
            if (setting == null)
                return null;
            setting = _mapper.Map(updateRequest, setting);

            var success = await _settingRepository.Update(setting);

            if (success != null)
            {
                var result = _mapper.Map<SettingDto>(success);
                if (success.Logo != null)
                {
                    result.Image = Convert.ToBase64String(success.Logo);
                }
                return result;
            }
            return null;
        }

        public async Task<bool?> UpdateLogoAsync(IFormFile image)
        {
            var setting = await _settingRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == 1);
            if (setting == null)
                return null;

            using var ms = new MemoryStream();
            {
                await image.CopyToAsync(ms);
                setting.Logo = ms.ToArray();
            }
            var result = await _settingRepository.Update(setting);
            return null!=result;
        }

    }
}
