using Application.DTOs;

namespace Application.Service.Interfaces
{
    public interface IPersonService
    {
        Task<ResultService<PersonDTO>> Create(PersonDTO personDTO);
    }
}
