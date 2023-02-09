using Contracts.Dtos.EmployeeDtos;
using Contracts.Dtos.UserDtos;
using DataAccess.Entities;

namespace Business
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            FromDataAccessorLayer();
            FromPresentationLayer();
        }

        private void FromPresentationLayer()
        {
            //Employee
            CreateMap<EmployeeDto, Employee>(memberList: AutoMapper.MemberList.None);
            CreateMap<EmployeeLoginDto, Employee>(memberList: AutoMapper.MemberList.None);
            CreateMap<EmployeeCreateDto, Employee>(memberList: AutoMapper.MemberList.None);
            CreateMap<EmployeeResponseDto, Employee>(memberList: AutoMapper.MemberList.None);

            //User
            CreateMap<UserDto, User>(memberList: AutoMapper.MemberList.None);
            CreateMap<UserCreateDto, User>(memberList: AutoMapper.MemberList.None);
            CreateMap<UserUpdateDto, User>(memberList: AutoMapper.MemberList.None);
        }

        private void FromDataAccessorLayer()
        {
            //Employee
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Employee, EmployeeLoginDto>();
            CreateMap<Employee, EmployeeCreateDto>();
            CreateMap<Employee, EmployeeResponseDto>(memberList: AutoMapper.MemberList.None);

            //User
            CreateMap<User, UserDto>();
            CreateMap<User, UserCreateDto>();
            CreateMap<User, UserUpdateDto>();
        }
    }
}
