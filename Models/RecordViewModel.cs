using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DappSniper.Net.Models
{
    public class RecordViewModel
    {
        /// <summary>
        /// 기준 시간 yyyyMMddHH
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 공개 여부
        /// </summary>
        public bool IsPublish { get; set; }
    }
}
