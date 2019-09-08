using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int row;
            int column;
            for(column=0; column<8; column++)
            {
                for(row=0;row<8;row++)
                {
                    if ((row + column) % 2 == 0)
                    {
                        Console.WriteLine("X");
                    }
                    else if ((row + column) % 2 == 1)
                    {
                        Console.WriteLine("O");
                    }
                    else
                    {
                        Console.WriteLine("none");
                    }
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
