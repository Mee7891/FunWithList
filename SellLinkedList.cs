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
        protected     int count;

        public SellLinkedList(T sentinelValue)
        {
            sentinel = new Sell<T>(sentinelValue);
            sentinel.Next = null;
            count = 0;
        }

        public void AddAtBeginning(T value)
        {
            Sell<T> newSell = new Sell<T>(value);
            newSell.Next = sentinel.Next;
            sentinel.Next = newSell;
            count++;
        }

        public void AddAtEnd(T value)
        {
            //работает, если нет цикла
            Sell<T> newSell = new Sell<T>(value);

            Sell<T> current = sentinel;
            while (current.Next != null)
                current = current.Next;
            current.Next = newSell;
            newSell.Next = null;
            count++;
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
            count++;
        }

        protected void DeleteAfter(Sell<T> afterMe)
        {
            if (afterMe.Next != null)
            {
                afterMe.Next = afterMe.Next.Next;
                count--;
            }
            
        }

        public bool HasCircle(bool tear)
        {
            //Проверка наличия цикла в односвязном списке
            //методом кролика и черепахи
            //if (sentinel.Next == null) return false;
            if (count == 0) return false;
            Sell<T> rabbit = sentinel.Next;
            Sell<T> turtle = rabbit;

            bool firstMeet = false;

            while(rabbit.Next != null )
            {
                turtle = turtle.Next; //черепаха делает 1 шаг

                if (!firstMeet)  //а кролик 1 или 2, в зав. от встретился с черепахой или нет
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
                  
            if(rabbit.Next == null ) return false; //нету значит цикла

            //если мы сюда добрались, то цикл есть, его надо рвать, и кролик стоит в начале цикла
            //гоним черепаху к кролику
            while (turtle.Next != rabbit)
                turtle = turtle.Next;
            turtle.Next = null;       //рвем цикл
            return true;
        }

        public int MakeCircle(int index)
        {
            //делает цикл, index - начало цикла
            if (count < 1)     return -1;
            if (index > count) return -1;

            Sell<T> circleStart = sentinel;
            Sell<T> current = sentinel;
            int n = 0;
            while (current.Next != null)
            {
                current = current.Next;
                if (n == index) circleStart = current;
                n++;
            }

            current.Next = circleStart;

            return 1;
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
