using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsTer
{
    class NewsSitePairs
    {
        public String  _Key { get; set; }
        public String _Value { get; set; }

        public NewsSitePairs(String key, String value)
        {
            this._Key = key;
            this._Value = value;
        }
    }
}
