using StockMarket.Models.DTO_s.AccountDtos;
using StockMarket.Models.DTO_s.CommentDtos;
using StockMarket.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Models.ManualMappingUsingExtensionMethods
{
    public static class AccountMapping
    {
        public static ApplicationUser ToAppUSerFromCreation(this RegisterDto registerDto)
        {
            return new ApplicationUser
            {
                FName = registerDto.FName,
                LName = registerDto.LName,
                UserName = registerDto.UserName,
                Email = registerDto.Email,
            };
        }

        public static NewUserDto ToAppUserFromLogin(this LoginDto loginDto)
        {
            return new NewUserDto
            {
                Email = loginDto.Email,
            };
        }

    }
}
