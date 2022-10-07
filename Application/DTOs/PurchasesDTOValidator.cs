using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PurchasesDTOValidator :AbstractValidator <PurchasesDTO>    
    {
        public PurchasesDTOValidator()
        {
            RuleFor(x => x.Cod).NotEmpty().NotNull().WithMessage("Cod must be informed");
            RuleFor(x => x.Document).NotEmpty().NotNull().WithMessage("Document must be informed");
           

        }
    }
}
