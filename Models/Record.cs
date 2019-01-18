using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DappSniper.Net.Models
{
    public class Record
    {
        public Record()
        {
            Ranks = new HashSet<Rank>();
        }

        /// <summary>
        /// 기준 시간 yyyyMMddHH
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 공개 여부
        /// </summary>
        public bool IsPublish { get; set; }

        public virtual ICollection<Rank> Ranks { get; set; }
    }
}
