using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13253020HW1
{
    class Stack<T>
    {
        T[] values;
        int top;

        public Stack(int size)
        {
            values = new T[size];
            top = -1;
        }

        public int Size()
        {
            return values.Length;
        }
        public bool IsEmpty()
        {
            return top == -1;
        }

        public bool IsFull()
        {
            return top == values.Length - 1;
        }

        public void Push(T val)
        {
            if (!IsFull())
            {
                values[++top] = val;
            }
            else
                Console.WriteLine("stack is full");

        }
        public T Pop()
        {
            if (!IsEmpty())
            {
                T temp = values[top--];
                return temp;
            }
            else
            {
                Console.WriteLine("stack is empty");
                return default(T);
            }
        }

        public void Display()
        {
            if (!IsEmpty())
            {
                for (int i = top; i >= 0; i--)
                {
                    Console.WriteLine(values[i]);
                }

            }
            else
                Console.WriteLine("stack is empty");
            Console.WriteLine();

        }
        public int Count()
        {
            return top + 1;
        }
    }
}





