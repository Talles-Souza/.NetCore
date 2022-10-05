﻿using Application.DTOs;
using Application.Service;
using Application.Service.Interfaces;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCourseTwo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]  
        public async Task<ActionResult> Create([FromBody]PersonDTO personDTO)
        {
            var result = await _personService.Create(personDTO);
            if(result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]   
        public async Task<ActionResult> FindByAll()
        {
            var result =  await _personService.FindByAll();
            if(result.IsSuccess) return Ok(result);
            return BadRequest(result);
            
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> FindById(int id)
        {
            var result = await _personService.FindById(id);
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }
    }
}
