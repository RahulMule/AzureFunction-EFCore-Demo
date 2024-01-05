using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunction_EFCore_Demo.Models
{
    public class StockTransaction
    {
        [Key]
        public int StockTransactionID { get; set; }
        public DateTime TransactionTime { get; set; } =  DateTime.UtcNow;
      
        [Required]
        public int Quantity { get; set; }
        public int StockID { get; set; }
        public Stock Stock { get; set; }
    }
}
