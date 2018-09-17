using AutoMapper;
using Lapis.Api.Models.Dtos;
using Lapis.DAL.Models;

namespace Lapis.Api.Infrastructure
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
