﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrototipoWebApi_1.Dtos;
using PrototipoWebApi_1.Interfaces;
using PrototipoWebApi_1.Modelos;
using PrototipoWebApi_1.Repositorios;

namespace PrototipoWebApi_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
       
        private readonly IColaboradoreServices _colaboradoreServices;
        private readonly IMapper _mapper;
        public ColaboradorController(
            IColaboradoreServices colaboradoreServices,
            IMapper mapper)
        {
            _colaboradoreServices = colaboradoreServices;
            _mapper = mapper;
            
        }

        // GET: api/Colaboradors
        [EnableQuery]
        [Route("GetColaboradores")]
        [HttpGet]
        public IEnumerable<Colaborador> GetColaboradors()
        {
            
           var result = _colaboradoreServices.GetColaboradors();
            var model = _mapper.Map<IEnumerable<Colaborador>>(result);

            return model;
        }

       

        // GET: api/Colaboradors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetColaborador([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var colaborador = await   _colaboradoreServices.GetColaboradorAsyncbyId(id);
            var model = _mapper.Map<ColaboradorDto>(colaborador);

            if (colaborador == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

       

        // POST: api/Colaboradors
        [HttpPost]
        public async Task<IActionResult> PostColaborador([FromBody] Colaborador colaborador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await
             _colaboradoreServices.SaveColaborator(colaborador);
        

            return CreatedAtAction("GetColaborador", new { id = colaborador.Col_I_Codigo }, colaborador);
        }

        // DELETE: api/Colaboradors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColaborador([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var colaborador = await  _colaboradoreServices.DeleteColaborador(id);
            if (colaborador == null)
            {
                return NotFound();
            }

            return Ok(colaborador);
        }

    }
}