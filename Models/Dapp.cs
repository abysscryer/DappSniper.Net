using System.Collections.Generic;

namespace DappSniper.Net.Models
{
    public class Dapp
    {
        public Dapp()
        {
            Ranks = new HashSet<Rank>();
            Contracts = new HashSet<Contract>();
        }

        /// <summary>
        /// guid
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// logo image path
        /// </summary>
        public string LogoPath { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// category
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// protocol
        /// </summary>
        public Protocol Protocol { get; set; }

        /// <summary>
        /// address
        /// </summary>
        public virtual ICollection<Contract> Contracts { get; set; }

        /// <summary>
        /// ranks
        /// </summary>
        public virtual ICollection<Rank> Ranks { get; set; }
    }

    
}
