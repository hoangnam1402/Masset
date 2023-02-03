using AutoMapper;
using Business.Extensions;
using Business.Interfaces;
using Contracts;
using Contracts.Dtos.UserDtos;
using Contracts.Exceptions;
using DataAccess.Entities;
using EnsureThat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpcontext;
        public async Task<PagedResponseModel<UserDto>> GetByPageAsync(
            BaseQueryCriteria baseQueryCriteria,
            CancellationToken cancellationToken)
        {

            var userQuery = UserFilter(
                _userRepository.Entities.AsQueryable(),
                baseQueryCriteria);

            var users = await userQuery
                .AsNoTracking()
                .PaginateAsync(
                    baseQueryCriteria,
                    cancellationToken);

            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users.Items);

            return new PagedResponseModel<UserDto>
            {
                CurrentPage = users.CurrentPage,
                TotalPages = users.TotalPages,
                TotalItems = users.TotalItems,
                Items = usersDto
            };
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user != null)
            {
                var userDto = _mapper.Map<UserDto>(user);

                return userDto;
            }
            return null;
        }

        public async Task<UserDto> RegisterUser(UserCreateDto userCreateRequest)
        {
            Ensure.Any.IsNotNull(userCreateRequest);

            var claims = _httpcontext.HttpContext.User.Claims.ToList();
            Dictionary<string, string> claimsDictionary = new Dictionary<string, string>();
            foreach (var claim in claims)
            {
                claimsDictionary.Add(claim.Type, claim.Value);
            }

            var password = "123456";

            var newUser = _mapper.Map<User>(userCreateRequest);
            newUser.UserName = userCreateRequest.UserName;
            newUser.Status = DataAccess.Enums.UserStatusEnums.Active;
            newUser.NewAccount = true;

            var result = await _userManager.CreateAsync(newUser, password);
            if (result.Succeeded)
            {
                return _mapper.Map<UserDto>(newUser);
            }
            return null;

        }

        public async Task<UserDto> UpdateAsync(int id, UserUpdateDto userRequest)
        {
            var user = await _userRepository.Entities.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                throw new NotFoundException("Not Found!");
            }

            user.Status = userRequest.Status;

            var userUpdated = await _userRepository.Update(user);

            var userUpdatedDto = _mapper.Map<UserDto>(userUpdated);

            return userUpdatedDto;
        }

        #region Private Method
        private IQueryable<User> UserFilter(
            IQueryable<User> userQuery,
            BaseQueryCriteria baseQueryCriteria)
        {
            if (!String.IsNullOrEmpty(baseQueryCriteria.Search))
            {
                userQuery = userQuery.Where(b =>
                    b.UserName.Contains(baseQueryCriteria.Search) || b.Email.Contains(baseQueryCriteria.Search));
            }

            return userQuery;
        }

        #endregion


    }
}
