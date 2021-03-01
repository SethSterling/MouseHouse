using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MouseHouse.Models
{
    /// <summary>
    /// Represents a generic item for sale
    /// </summary>
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string Title { get; set; }
        public double Price { get; set; }
        /// <summary>
        /// Type of item (eg. chair, table, sofa...)
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Where item belongs (eg. living room, dining room, bedroom...)
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// URL to an image of the item 
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Image of the item
        /// </summary>
        [NotMapped] // Tell Entity Framework to ignore property
        public IFormFile Image { get; set; }

        /// <summary>
        /// Weight measured in lbs
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Height measured in inches
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// Length (or depth) measured in inches
        /// </summary>
        public double Length { get; set; }
        /// <summary>
        /// Width measured in inches
        /// </summary>
        public double Width { get; set; }
        /// <summary>
        /// Color of the item
        /// </summary>
        public string Color { get; set; }
    }
}
