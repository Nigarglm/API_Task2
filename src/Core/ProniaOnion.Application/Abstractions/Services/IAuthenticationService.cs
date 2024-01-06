using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.DTOs.Users;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface IAuthenticationService
    {
        public Task Register(RegisterDto dto);

    }
}
