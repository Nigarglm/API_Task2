using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Users;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Persistence.Implementations.Services
{
    public class AuthenticationService:IAuthenticationService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public AuthenticationService(IMapper mapper, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task Register(RegisterDto dto)
        {
            AppUser user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == dto.UserName || u.Email == dto.Email);
            if (user != null) throw new Exception("exception");
            user=_mapper.Map<AppUser>(dto);

            var result = await _userManager.CreateAsync(user,dto.Password);
            if(!result.Succeeded)
            {
                StringBuilder message = new StringBuilder();

                foreach (var error in result.Errors)
                {
                    message.AppendLine(error.Description);
                }
                throw new Exception(message.ToString());
            }
        }
    }
}
