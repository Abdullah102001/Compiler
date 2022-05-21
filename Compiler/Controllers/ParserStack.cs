using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerS
{
    public class ParserStack<T>
    {

        private int top;
        private List<T> stack = new List<T>();

       
        public ParserStack()
        {
            top = -1;
        }

        public bool IsEmpty()
        {
            return (top < 0);
        }
        public void Push(T data)
        {
            stack.Add(data);
            ++top;
        }

        public T Pop()
        {
            T value = stack[top];
            stack.RemoveAt(top--);
            return value;
        }
    }
}
     

