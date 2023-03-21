using Nursery.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nursery.view
{
    internal class View
    {
        public View() { }

        internal void Print(string message)
        {
            Console.WriteLine(message);
        }
        internal string GetString()
        {
            return  Console.ReadLine();
        }
        internal string ReadKey()
        {
            return Console.ReadKey(true);
        }
    }
}
