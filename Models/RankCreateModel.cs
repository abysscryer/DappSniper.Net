using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DappSniper.Net.Models
{
    public class RankCreateModel
    {
        /// <summary>
        /// 기준 시간 yyyyMMddHH
        /// </summary>
        //[Required, MinLength(10), MaxLength(10)]
        //public string RecordId { get; set; }

        /// <summary>
        /// Users24h 기준
        /// </summary>
        [Required, Range(1, 100)]
        public int No { get; set; }

        /// <summary>
        /// dapp id
        /// </summary>
        [Required]
        public string DappId { get; set; }

        /// <summary>
        /// amount
        /// </summary>
        public decimal Balance { get; set; }

        public int Users24h { get; set; }

        public int Volume24h { get; set; }

        public int Volume7d { get; set; }

        public int Tx24h { get; set; }

        public int Tx7d { get; set; }
    }
}
