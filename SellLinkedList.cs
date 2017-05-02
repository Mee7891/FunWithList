using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithList
{
    class SellLinkedList<T>: IEnumerable<T>
    {
        protected Sell<T> sentinel;

        public SellLinkedList(T sentinelValue)
        {
            sentinel = new Sell<T>(sentinelValue);
            sentinel.Next = null;
        }

        public void AddAtBeginning(T value)
        {
            Sell<T> newSell = new Sell<T>(value);
            newSell.Next = sentinel.Next;
            sentinel.Next = newSell;
        }

        public void AddAtEnd(T value)
        {
            Sell<T> newSell = new Sell<T>(value);

            Sell<T> current = sentinel;
            while (current.Next != null)
                current = current.Next;
            current.Next = newSell;
            newSell.Next = null;
        }

        public Sell<T> FindSellBefore(T value)
        {
            Sell<T> current = sentinel;
            while(current.Next != null)
            {
                if (current.Next.Value.Equals(value)) return current; 
                current = current.Next;
            }
            return null;
        }

        protected void AddAfter(Sell<T> afterMe, Sell<T> newSell)
        {
            newSell.Next = afterMe.Next;
            afterMe.Next = newSell;
        }

        protected void DeleteAfter(Sell<T> afterMe)
        {
            afterMe.Next = afterMe.Next.Next;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Sell<T> current = sentinel.Next;
            while(current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
