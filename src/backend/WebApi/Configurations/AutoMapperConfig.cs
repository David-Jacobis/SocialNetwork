using AutoMapper;
using Business.ViewModels;
using Business.ViewModels.User;
using DataAccess.Context;
using Models.Models;

namespace WebApi.Configuration
{
    public class AutoMapperConfig : AutoMapper.Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User, UserRequest>().ReverseMap();
        }
    }
}
