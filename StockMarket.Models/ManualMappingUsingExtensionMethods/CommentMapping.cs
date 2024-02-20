using StockMarket.Models.DTO_s.CommentDtos;
using StockMarket.Models.DTO_s.StockDtos;
using StockMarket.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Models.ManualMappingUsingExtensionMethods
{
    public static class CommentMapping
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
               Id = commentModel.Id,
               Title = commentModel.Title,
               Content = commentModel.Content,
               CreatedOn = commentModel.CreatedOn,
               StockId = commentModel.StockId,
            };
        }
        public static Comment ToCommentFromCreation(this CreateCommentDto createCommentDto)
        {
            return new Comment
            {
                Title = createCommentDto.Title,
                Content = createCommentDto.Content,
                CreatedOn = createCommentDto.CreatedOn,
                StockId =createCommentDto.StockId,
            };
        }
        public static Comment ToCommetnFromUpdating(this UpdateCommentDto updateCommentDto)
        {
            return new Comment
            {
                Title = updateCommentDto.Title,
                Content = updateCommentDto.Content,
                CreatedOn = updateCommentDto.CreatedOn,
                StockId = updateCommentDto.StockId,
            };
        }
    }
}
