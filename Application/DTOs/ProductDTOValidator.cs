using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {


        public ProductDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name must be informed");
            RuleFor(x => x.Cod).NotEmpty().NotNull().WithMessage("Cod must be informed");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Value must be greater than zero");


        }
    }
}
