using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopBridge.Models
{
    public class Product
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Pid { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Descripiton { get; set; }
        [Required]
        [Range(500, 5000, ErrorMessage = "Price should be greater than 500")]
        public double Price { get; set; }
        [Required]
        [MaxLength(2)]
        [Range(1,100,ErrorMessage ="Quantity should be greater 1 and less than 100")]
        public int Quantity { get; set; }
    }
}