using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DappSniper.Net.Models
{
    public class Rank
    {
        public string Id { get; set; }

        /// <summary>
        /// 기준 시간 yyyyMMddHH
        /// </summary>
        public string RecordId { get; set; }

        /// <summary>
        /// Users24h 기준
        /// </summary>
        public int No { get; set; }

        /// <summary>
        /// Dapp Id
        /// </summary>
        public string DappId { get; set; }

        /// <summary>
        /// satoshi
        /// </summary>
        public long Balance { get; set; }

        public int Users24h { get; set; }

        public int Volume24h { get; set; }

        public int Volume7d { get; set; }

        public int Tx24h { get; set; }

        public int Tx7d { get; set; }

        public virtual Record Record { get; set; }
        public virtual Dapp Dapp { get; set; }
    }
}
