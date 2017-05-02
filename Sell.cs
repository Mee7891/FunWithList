using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithList
{
    class Sell<T>
    {
       public       T Value { get; set; }
       public Sell<T> Next  { get; set; }

        public Sell(T value)
        {
            Value = value;
        }

    }
}
