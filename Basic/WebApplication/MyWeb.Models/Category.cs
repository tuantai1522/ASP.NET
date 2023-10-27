using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyWeb.Models
{
    public class Category
    {
        //If priamary key is named as Id or "Model name" + Id, it will set as primary key automatically
        [Key]
        public int CategoryID { get; set; }
        [Required]
        [DisplayName("Category Name")] // to show on Views
        public string? CategoryName { get; set; }

        [DisplayName("Display Order")] // to show on Views
        [Range(1, 100, ErrorMessage = "Invalid. The range must be from 1 - 100")] //to set errorMessage like my custom
        public int DisplayOrder { get; set; }
    }
}
