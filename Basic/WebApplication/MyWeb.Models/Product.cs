using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.Models
{
    public class Product
    {
        //If priamary key is named as Id or "Model name" + Id, it will set as primary key automatically
        [Key]
        public int ProductID { get; set; }
        [Required]
        [DisplayName("Product Name")] // to show on Views
        public string ProductName { get; set; }
        public string Description { get; set; }

        [Required]
        [DisplayName("List Price")] // to show on Views
        [Range(1, 1000, ErrorMessage = "Invalid. The range must be from 1 - 1000")] //to set errorMessage like my custom
        public double ListPrice { get; set; }

        [Required]
        [DisplayName("Price for 1-1000")] // to show on Views
        [Range(1, 1000, ErrorMessage = "Invalid. The range must be from 1 - 1000")] //to set errorMessage like my custom
        public double Price { get; set; }

        [Required]
        [DisplayName("Price for 1-100")] // to show on Views
        [Range(1, 1000, ErrorMessage = "Invalid. The range must be from 1 - 1000")] //to set errorMessage like my custom
        public double Price50 { get; set; }

        [Required]
        [DisplayName("Price for 100+")] // to show on Views
        [Range(1, 1000, ErrorMessage = "Invalid. The range must be from 1 - 1000")] //to set errorMessage like my custom
        public double Price100 { get; set; }

        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]

        [ValidateNever]
        public Category Category { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
