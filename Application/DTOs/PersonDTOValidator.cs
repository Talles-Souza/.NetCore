using FluentValidation;

namespace Application.DTOs
{
    public class PersonDTOValidator : AbstractValidator<PersonDTO>  
    {
        public PersonDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name must be informed");
            RuleFor(x => x.Document).NotEmpty().NotNull().WithMessage("Document must be informed");
            RuleFor(x => x.Phone).NotEmpty().NotNull().WithMessage("Phone must be informed");
            

        }
    }
}
