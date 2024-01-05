using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunction_EFCore_Demo.Models
{
    public class Stock
    {
        [Key]
        public int StockID { get; set; }
        [Required]
        public string StockName { get; set; }
        [Required]
        public string StockType { get; set; }
        public int Price { get; set; }
        public ICollection<StockTransaction> StockTransactions { get; set; } 
    }
}
