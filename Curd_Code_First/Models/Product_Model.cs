using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel;
namespace Curd_Code_First.Models
{
    public class Product_Model
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }


        [Display(Name = "Category_model")]
        public virtual int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category_model Category_model { get; set; }

        public static implicit operator int(Product_Model v)
        {
            throw new NotImplementedException();
        }
    }
}