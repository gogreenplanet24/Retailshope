using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Retailshop.Models
{
    [Table("tbl_Products")]

    public class Product
    {
        [Key]
        public int ProdID { get; set; }

        public string ProdName { get; set; }
        public decimal ListPrice { get; set; }
        public int Quantity { get; set; }
    }
}
