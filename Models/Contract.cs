using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DappSniper.Net.Models
{
    public class Contract
    {
        public string Address { get; set; }

        public string DappId { get; set; }

        public virtual Dapp Dapp { get; set; }
    }
}
