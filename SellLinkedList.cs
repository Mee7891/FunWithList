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

        public bool HasCircle(bool tear)
        {
            //Проверка наличия цикла в односвязном списке
            //методом кролика и черепахи
            Sell<T> rabbit = sentinel.Next;
            Sell<T> turtle = sentinel.Next;

            bool firstMeet = false;

            while(rabbit != null)
            {
                turtle = turtle.Next; //черепаха делает 1 шаг

                if (!firstMeet)                   //а кролик 1 или 2, в зав. от встретился с черепахой или нет
                    rabbit = rabbit.Next.Next;
                else 
                    rabbit = rabbit.Next;

                if (turtle == rabbit)
                {
                    if (!tear) return true; //мы нашли цикл, если его не надо рвать, то выходим

                    if (!firstMeet)
                    {
                        firstMeet = true;
                        rabbit = sentinel.Next;  //первая встреча, запускаем кролика из начала списка
                    }
                    else break;                 //вторая встреча, выходим из while
                }
            }
                  
            if(rabbit == null ) return false; //нету значит цикла

            //если мы сюда добрались, то цикл есть, его надо рвать, и кролик стоит в начале цикла
            //гоним черепаху к кролику
            while (turtle.Next != rabbit)
                turtle = turtle.Next;
            turtle.Next = null;       //рвем цикл
            return true;
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
