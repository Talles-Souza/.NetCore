using Application.DTOs;
using Application.Service.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Service
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<PersonDTO>> Create( PersonDTO personDTO)
        {
            
            if(personDTO == null) return ResultService.Fail<PersonDTO>("Object must be informed");    
            var result = new PersonDTOValidator().Validate(personDTO);
            if (!result.IsValid) return ResultService.RequestError<PersonDTO>("Problems in valdiation", result);
            var person = _mapper.Map<Person>(personDTO);
            var data = await _personRepository.Create(person);
            return ResultService.Ok(_mapper.Map<PersonDTO>(data));

        }
    }
}
