using Application.DTOs;
using Application.Service.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using System;

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

        public async Task<ResultService<PersonDTO>> Delete(int id)
        {
            var person = await _personRepository.FindById(id);
            if(person == null) return ResultService.Fail<PersonDTO>("Person not found");
            await _personRepository.Delete(id);
            return ResultService.Ok(_mapper.Map<PersonDTO>(person));      
        }

        public async Task<ResultService<ICollection<PersonDTO>>> FindByAll()
        {
            var people = await _personRepository.FindByAll();
            return ResultService.Ok<ICollection<PersonDTO>>(_mapper.Map<ICollection<PersonDTO>>(people));
        }

        public async Task<ResultService<PersonDTO>> FindById(int id)
        {
            var person = await _personRepository.FindById(id);
            if (person == null) return ResultService.Fail<PersonDTO>("Person not found");
            return ResultService.Ok(_mapper.Map<PersonDTO>(person));
        }

        public async Task<ResultService<PersonDTO>> Update(PersonDTO personDTO)
        {
            if (personDTO == null) return (ResultService<PersonDTO>)ResultService.Fail("Person must be informed");
            var result = new PersonDTOValidator().Validate(personDTO);
            if (!result.IsValid) return ResultService.RequestError<PersonDTO>("Problems in valdiation", result);
            var person = await _personRepository.FindById(personDTO.Id);
            if (person == null) return (ResultService<PersonDTO>)ResultService.Fail("Person not found");
            person = _mapper.Map<PersonDTO, Person>(personDTO,person);
            var data = await _personRepository.Update(person);
            return ResultService.Ok(_mapper.Map<PersonDTO>(data));
        }
    }
}
