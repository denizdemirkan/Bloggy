using AutoMapper;
using Bloggy.Core.DTOs;
using Bloggy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloggy.Service.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Blog, BlogDto>().ReverseMap();

        }
    }
}
