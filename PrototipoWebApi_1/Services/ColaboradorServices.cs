using AutoMapper;
using PrototipoWebApi_1.Dtos;
using PrototipoWebApi_1.Interfaces;
using PrototipoWebApi_1.Modelos;
using PrototipoWebApi_1.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototipoWebApi_1.Services
{
    public class ColaboradorServices : IColaboradoreServices
    {
        private readonly RepositoryBase _colaboradorServices;
        private readonly IMapper _mapper;

        public ColaboradorServices( RepositoryBase colaboradorServices, IMapper mapper)
        {
            _colaboradorServices = colaboradorServices;
            _mapper = mapper;
        }
        public IEnumerable<Colaborador> GetColaboradors()
        {
            var colaboradores = _colaboradorServices.Colaboradors;

           var modelo = _mapper.Map<IEnumerable<Colaborador>> (colaboradores);
             return modelo;
            
        }

        public async Task<Colaborador> GetColaboradorAsyncbyId(int id)
        {
            var colaborador = await _colaboradorServices.Colaboradors.FindAsync(id);
            //var model = _mapper.Map<ColaboradorDto>(colaborador);

            return colaborador;
        }

        public async Task<Colaborador> SaveColaborator(Colaborador colaborador)
        {
          var result =  _colaboradorServices.Colaboradors.AddAsync(colaborador);
             await _colaboradorServices.SaveChangesAsync();

            return colaborador;
           
        }

        public async Task<Colaborador> DeleteColaborador(int id)
        {
            var result = await
                _colaboradorServices.Colaboradors.FindAsync(id);
           
            _colaboradorServices.Colaboradors.Remove(result);
            await _colaboradorServices.SaveChangesAsync();
            return result;
        }
    }
}
