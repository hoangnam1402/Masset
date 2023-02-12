using AutoMapper;
using Business.Extensions;
using Business.Interfaces;
using Contracts;
using Contracts.Dtos.UserDtos;
using DataAccess.Entities;
using EnsureThat;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private UserManager<User> _userManager;

        public UserService(IBaseRepository<User> userRepository, IMapper mapper, UserManager<User> userManager)
        {
            _userRepository=userRepository;
            _mapper=mapper;
            _userManager=userManager;
        }

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
                return _mapper.Map<UserDto>(user);
            //throw new NotFoundException("Not Found!");
            return null;
        }

        public async Task<UserDto> RegisterUser(UserCreateDto userCreateRequest)
        {
            Ensure.Any.IsNotNull(userCreateRequest);

            var password = "abc123";

            var newUser = _mapper.Map<User>(userCreateRequest);
            newUser.UserName = userCreateRequest.UserName;
            newUser.Status = DataAccess.Enums.UserStatusEnums.Active;
            newUser.NewAccount = true;

            var result = await _userManager.CreateAsync(newUser, password);
            if (result.Succeeded)
                return _mapper.Map<UserDto>(newUser);
            return null;
        }

        public async Task<UserDto> UpdateAsync(int id, UserUpdateDto userRequest)
        {
            var user = await _userRepository.Entities.FirstOrDefaultAsync(x => x.Id == id);

            user.Status = userRequest.Status;
            user.Email = userRequest.Email;
            user.PhoneNumber = userRequest.PhoneNumber;

            var userUpdated = await _userRepository.Update(user);
            return _mapper.Map<UserDto>(userUpdated);
        }

        public async Task<bool> IsExist(int id)
        {
            if (await _userRepository.GetById(id) == null)
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
