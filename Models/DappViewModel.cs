using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DappSniper.Net.Models
{
    public class DappViewModel
    {
        public string Id { get; set; }

        public string[] Addresses { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string LogoPath { get; set; }

        public int Category { get; set; }

        public int Protocol { get; set; }
    }
}
