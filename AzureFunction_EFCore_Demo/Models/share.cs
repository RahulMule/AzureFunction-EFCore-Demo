using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunction_EFCore_Demo.Models
{
    public class Share
    {
        [Key]
        public int shareID { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime Created { get; set; }= DateTime.Now;
        public int quantity { get; set; }

        public int CurrentPrice { get; set; } 


    }
}
