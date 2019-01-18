using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DappSniper.Net.Models
{
    public class RankViewModel
    {
        /// <summary>
        /// rank id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 기준 시간 yyyyMMddHH
        /// </summary>
        public string RecordId { get; set; }

        /// <summary>
        /// Users24h 기준
        /// </summary>
        public string No { get; set; }

        public string DappId { get; set; }

        /// <summary>
        /// dapp name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// dapp logo path
        /// </summary>
        public string LogoPath { get; set; }

        /// <summary>
        /// dapp category
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// dapp protocol
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        /// amount
        /// </summary>
        public string Balance { get; set; }

        public string Users24h { get; set; }

        public string Volume24h { get; set; }

        public string Volume7d { get; set; }

        public string Tx24h { get; set; }

        public string Tx7d { get; set; }
    }
}
