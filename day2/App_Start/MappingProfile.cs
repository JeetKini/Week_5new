using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlysProject.Dtos;
using VidlysProject.Models;

namespace VidlysProject.App_Start
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<MembershipType, MembershipTypeDto>();
            CreateMap<Movie, MoviesDto>();
            CreateMap<MoviesDto, Movie>();
            CreateMap<MovieGenre, MovieGenreDto>();

        }
    }
}