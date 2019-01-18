using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DappSniper.Net.Models
{
    public class DappUpdateModel
    {
        /// <summary>
        /// name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// logo image path
        /// </summary>
        [Required]
        public string LogoPath { get; set; }


        public string Description { get; set; }

        /// <summary>
        /// category
        /// </summary>
        [Required]
        public int Category { get; set; }

        /// <summary>
        /// protocol
        /// </summary>
        [Required]
        public int Protocol { get; set; }
    }
}
