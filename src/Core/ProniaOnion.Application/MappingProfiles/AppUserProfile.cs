using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProniaOnion.Application.DTOs.Users;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.MappingProfiles
{
    internal class AppUserProfile:Profile
    {
        public AppUserProfile() 
        {
            CreateMap<RegisterDto, AppUser>();
        }
    }
}
