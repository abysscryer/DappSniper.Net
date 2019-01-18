using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DappSniper.Net.Models
{
    public class DappSearchModel
    {
        private int _pageNumber = 1;

        public string SearchString { get; set; }

        public int PageNumber
        {
            get { return _pageNumber; }
            set { _pageNumber = value == 0 ? 1 : value; }
        }

        public int PageSize { get; } = 10;
    }
}
