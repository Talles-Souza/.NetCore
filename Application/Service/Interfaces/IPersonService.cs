using Application.DTOs;

namespace Application.Service.Interfaces
{
    public interface IPersonService
    {
        Task<ResultService<PersonDTO>> Create(PersonDTO personDTO); 
        Task<ResultService<ICollection<PersonDTO>>> FindByAll();
        Task<ResultService<PersonDTO>> FindById(int id);
        Task<ResultService<PersonDTO>> Update(PersonDTO personDTO);
        Task<ResultService<PersonDTO>> Delete(int id);

    }
}
