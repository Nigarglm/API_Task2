using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ProniaOnion.Application.DTOs.Categories;

namespace ProniaOnion.Application.Validators
{
    public class CategoryCreateDtoValidator:AbstractValidator<CategoryCreateDTO>
    {
        public CategoryCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).MinimumLength(1).Matches(@"^[a-zA-Z0-9\s]*$");
        }
    }
}
