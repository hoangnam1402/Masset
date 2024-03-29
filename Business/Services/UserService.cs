﻿using AutoMapper;
using Business.Extensions;
using Business.Interfaces;
using Contracts;
using Contracts.Dtos.UserDtos;
using DataAccess.Entities;
using DataAccess.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserService(IBaseRepository<User> userRepository, IMapper mapper, UserManager<User> userManager)
        {
            _userRepository=userRepository;
            _mapper=mapper;
            _userManager=userManager;
        }

        public async Task<PagedResponseModel<UserDto>> GetByPageAsync(
            BaseQueryCriteria baseQueryCriteria,
            CancellationToken cancellationToken,
            string id)
        {
            var userRole = _userRepository.Entities
            .Where(x => x.Id == id)
            .Select(x => x.Role)
            .FirstOrDefault();

            var userQuery = UserFilter(
                _userRepository.Entities.AsQueryable(),
                baseQueryCriteria,
                userRole);

            var result = await userQuery
                .AsNoTracking()
                .PaginateAsync(
                    baseQueryCriteria,
                    cancellationToken);

            var usersDto = _mapper.Map<IEnumerable<UserDto>>(result.Items);

            return new PagedResponseModel<UserDto>
            {
                CurrentPage = result.CurrentPage,
                TotalPages = result.TotalPages,
                TotalItems = result.TotalItems,
                Items = usersDto
            };
        }

        public async Task<UserDto?> GetById(string id)
        {
            var user = await _userRepository.GetById(id);
            if (user != null)
                return _mapper.Map<UserDto>(user);
            return null;
        }

        public async Task<UserDto?> RegisterUser(UserCreateDto userCreateRequest)
        {
            var password = "abc123";

            var newUser = _mapper.Map<User>(userCreateRequest);
            newUser.UserName = userCreateRequest.UserName;
            newUser.IsActive = true;
            newUser.FirstLogin = true;
            newUser.CreateDay = newUser.UpdateDay = DateTime.Now;

            var result = await _userManager.CreateAsync(newUser, password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, userCreateRequest.Role == UserRoleEnums.Manager ? "MANAGER" : "STAFF");
                return _mapper.Map<UserDto>(newUser);
            }
            return null;
        }

        public async Task<UserDto?> UpdateAsync(string id, UserUpdateDto userRequest)
        {
            var user = await _userRepository.Entities.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
            if (user == null)
                return null;
            user = _mapper.Map(userRequest, user);
            user.UpdateDay = DateTime.Now;
            var result = await _userRepository.Update(user);
            await _userManager.UpdateAsync(user);
            if (result == null)
                return null;
            return _mapper.Map<UserDto>(result);
        }

        public async Task<bool> IsExistById(string id)
        {
            if (await _userRepository.Entities.FirstOrDefaultAsync(x => x.Id == id) == null)
                return false;
            else
                return true;
        }

        public async Task<bool> IsExist(string userName)
        {
            if (await _userRepository.Entities.FirstOrDefaultAsync(x => x.UserName == userName) == null)
                return false;
            else
                return true;
        }

        public async Task<bool> IsActive(string id)
        {
            var user = await _userRepository.Entities.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null && user.IsActive)
                return true;
            else
                return false;
        }

        public async Task<bool> DisableUserAsync(string id)
        {
            var user = await _userRepository.Entities.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
            if (user == null)
                return false;
            user.IsActive = false;

            var result = await _userRepository.Update(user);
            if (result == null)
                return false;
            return true;
        }

        public async Task<IList<UserDto>> GetAll()
        {
            var result = await _userRepository.GetAll();
            result = result.Where(x => x.IsActive == true && x.Role != UserRoleEnums.Admin);
            return _mapper.Map<IList<UserDto>>(result);
        }

        #region Private Method
        private IQueryable<User> UserFilter(
            IQueryable<User> query,
            BaseQueryCriteria baseQueryCriteria,
            UserRoleEnums userRole)
        {
            if (!string.IsNullOrEmpty(baseQueryCriteria.Search))
            {
                query = query.Where(b =>
                    b.UserName.Contains(baseQueryCriteria.Search) || b.Email.Contains(baseQueryCriteria.Search));
            }

            query = query.Where(x => x.IsActive == true);

            return query;
        }

        #endregion

    }
}
