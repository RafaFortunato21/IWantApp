using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWantApp.Application.DTO
{
    public class ProductDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
