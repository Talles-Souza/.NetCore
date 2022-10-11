using Application.DTOs;
using Domain.FiltersDb;

namespace Application.Service.Interfaces
{
    public interface IPersonService
    {
        Task<ResultService<PersonDTO>> Create(PersonDTO personDTO); 
        Task<ResultService<ICollection<PersonDTO>>> FindByAll();
        Task<ResultService<PersonDTO>> FindById(int id);
        Task<ResultService<PersonDTO>> Update(PersonDTO personDTO);
        Task<ResultService> Delete(int id);
        Task<ResultService<PagedResponseDTO<PersonDTO>>> FindPaged(PersonFilterDb personFilterDb);

    }
}
