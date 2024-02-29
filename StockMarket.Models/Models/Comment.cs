using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Models.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Title length must be between 1 and 100 characters")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Content is required")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "Content length must be between 1 and 500 characters")]
        public string Content { get; set; } = string.Empty;

        [Required(ErrorMessage = "Created on date is required")]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;


        // navigation property
        [ForeignKey("Stock")]
        public int StockId { get; set; }
        public Stock? Stock { get; set; }

        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


    }
}
