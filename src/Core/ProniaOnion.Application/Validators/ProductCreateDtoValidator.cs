using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ProniaOnion.Application.DTOs.Products;

namespace ProniaOnion.Application.Validators
{
    internal class ProductCreateDtoValidator:AbstractValidator<ProductCreateDTO>
    {
        public ProductCreateDtoValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Name is required").MaximumLength(100).WithMessage("Name may contains maximum 100 characters").MinimumLength(2);
            RuleFor(x => x.SKU).NotEmpty().MaximumLength(10);
            RuleFor(x=>x.Price).NotEmpty().LessThanOrEqualTo(999999.9m).GreaterThanOrEqualTo(10);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(1000);
        }
    }
}
