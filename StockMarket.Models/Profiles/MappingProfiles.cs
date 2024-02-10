using AutoMapper;
using StockMarket.Models.DTO_s.StockDtos;
using StockMarket.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Models.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Stock, StockDto>().ReverseMap();
            CreateMap<Stock, CreateStockDto>().ReverseMap();

        }
    }
}
