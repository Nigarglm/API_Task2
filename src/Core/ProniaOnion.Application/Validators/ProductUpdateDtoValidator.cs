using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ProniaOnion.Application.DTOs.Products;

namespace ProniaOnion.Application.Validators
{
    public class ProductUpdateDtoValidator:AbstractValidator<ProductUpdateDTO>
    {
        public ProductUpdateDtoValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").MaximumLength(100).WithMessage("Name may contains maximum 100 characters").MinimumLength(2);
            RuleFor(x => x.SKU).NotEmpty().MaximumLength(10);
            RuleFor(x => x.Price).NotEmpty().LessThanOrEqualTo(999999.9m).GreaterThanOrEqualTo(10);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(1000);
            RuleFor(x => x.CategoryId).Must(c => c > 0);
            RuleForEach(x => x.ColorIds).Must(c => c > 0);
            RuleFor(x => x.ColorIds).NotNull();
        }
    }
}
