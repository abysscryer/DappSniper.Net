using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DappSniper.Net.Models
{
    public class DappCreateModel
    {
        [Required]
        public string Address { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LogoPath { get; set; }

        public string Description { get; set; }

        [Required]
        public int Category { get; set; }

        [Required]
        public int Protocol { get; set; }
    }
}
