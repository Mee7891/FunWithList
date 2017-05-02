using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithList
{
    class LinkedListCompar<T>: SellLinkedList<T> where T: IComparable
    {
        public LinkedListCompar(T sentinelValue) : base(sentinelValue) { }

        public T getMax()
        {
            Sell<T> current = sentinel.Next;

            if (current == null) throw new Exception("Попытка найти максимальный элемент впустом списке.");

            T max = current.Value;
            while(current.Next != null)
            {
                if (max.CompareTo(current.Next.Value) < 0)
                    max = current.Next.Value;
                current = current.Next;
            }

            return max;
        }

        public bool isSorted()
        {
            Sell<T> current = sentinel.Next;

            while(current != null)
            {
                if (current.Value.CompareTo(current.Next.Value) > 0) return false;
            }

            return true;
        }
    }
}
