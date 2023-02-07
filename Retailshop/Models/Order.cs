using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Retailshop.Models
{
    [Table("tbl_Orders")]

    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }
        public int ProdID { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
    }
}
