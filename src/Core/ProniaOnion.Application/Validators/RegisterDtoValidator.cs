using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ProniaOnion.Application.DTOs.Users;

namespace ProniaOnion.Application.Validators
{
    public class RegisterDtoValidator:AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        { 
            RuleFor(x=>x.Email)
                .NotEmpty()
                .MaximumLength(256);
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(16);
            RuleFor(x => x.UserName)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(50);
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(50);
            RuleFor(x => x.Surname)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength (50);
            RuleFor(x => x).Must(x => x.ConfirmPassword == x.Password);
        }
    }
}
