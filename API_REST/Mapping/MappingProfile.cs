using API_REST.DTOs;
using API_REST.Models;
using AutoMapper;

namespace API_REST.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {

            CreateMap<LibroCreateDTO, Libro>();
            CreateMap<PrestamoCreateDTO,Prestamo>();

        }
    }
}
