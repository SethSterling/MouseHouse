using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MouseHouse.Models
{
    /// <summary>
    /// This class tracks summary and delivery infomation for an order
    /// </summary>
    public class Order
    {
        [Key]
        public int OrderNumber { get; set; }


        /// <summary>
        /// Username of the user making the order
        /// </summary>
        public string Username { get; set; }


        /// <summary>
        /// First name of the user making the order
        /// </summary>
        [DisplayName("First Name")]
        [StringLength(160)]
        public string FirstName { get; set; }


        /// <summary>
        /// Last name of the user making the order
        /// </summary>
        [DisplayName("Last Name")]
        [StringLength(160)]
        public string LastName { get; set; }


        /// <summary>
        /// Address of the user making the order
        /// </summary>
        [StringLength(70)]
        public string Address { get; set; }

        [StringLength(70)]
        /// <summary>
        /// City of the user making the order
        /// </summary>
        public string City { get; set; }

        [StringLength(70)]
        /// <summary>
        /// State of the user making the order
        /// </summary>
        public string State { get; set; }

        [DisplayName("ZIP Code")]
        [StringLength(70)]
        /// <summary>
        /// ZIP code of the user making the order
        /// </summary>
        public string ZIPCode { get; set; }

        [StringLength(70)]
        /// <summary>
        /// Country of the user making the order
        /// </summary>
        public string Country { get; set; }

        [StringLength(70)]
        /// <summary>
        /// Phone number of the user making the order
        /// </summary>
        public string Phone { get; set; }

        [StringLength(160)]
        /// <summary>
        /// Email of the user making the order
        /// </summary>
        public string Email { get; set; }


        /// <summary>
        /// Total price of the user's entire order
        /// </summary>
        public decimal Total { get; set; }


        /// <summary>
        /// Date of the order made by the user
        /// </summary>
        public System.DateTime OrderDate { get; set; }


        /// <summary>
        /// List of the products the user is ordering
        /// </summary>
        public List<Product> PurchasedProducts { get; set; }
    }
}
