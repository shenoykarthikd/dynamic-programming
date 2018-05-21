using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class FibonacciSeries
    {
        const int num = 5;
        static int numOfCallsWithoutMem = 0;
        static int numOfCallsWithMem = 0;
        static int numOfCallsIteratively = 0;

        static void Main(string[] args)
        {
            FibonacciSeries fib = new FibonacciSeries();

            Console.WriteLine("Fibonacci Series Without Memoization - ");
            int fibNumber = fib.GenerateNextElement(num);
            Console.WriteLine("Fibonacci Series Element {0}: {1}", num, fibNumber);

            Console.WriteLine("\n\nFibonacci Series With Memoization - ");
            fibNumber = fib.GenerateNextElementWithMem(num, new int[num + 1]);
            Console.WriteLine("Fibonacci Series Element {0}: {1}", num, fibNumber);

            Console.WriteLine("\n\nFibonacci Series Iteratively - ");
            fibNumber = fib.GenerateNextElementIteratively(num);
            Console.WriteLine("Fibonacci Series Element {0}: {1}", num, fibNumber);
        }

        //Recursion with worst case O(2^n)
        int GenerateNextElement(int num)
        {
            numOfCallsWithoutMem += 1;
            Console.WriteLine("\t\t Call: " + numOfCallsWithoutMem);
            if (num == 0 || num == 1)
            {
                return num;
            }

            return this.GenerateNextElement(num - 1) + this.GenerateNextElement(num - 2);
        }

        //Recursion with worst case O(n)
        int GenerateNextElementWithMem(int num, int[] arr)
        {
            numOfCallsWithMem += 1;
            Console.WriteLine("\t\t Call: " + numOfCallsWithMem);
            if (num == 0 || num == 1)
            {
                return num;
            }

            if(arr[num] == 0)
            {
                arr[num] = this.GenerateNextElementWithMem(num - 2, arr) + this.GenerateNextElementWithMem(num - 1, arr);
            }

            return arr[num];
        }

        //Iterative approach with worst case O(n)
        int GenerateNextElementIteratively(int num)
        {
            if (num == 0 || num == 1)
            {
                numOfCallsIteratively += 1;
                Console.WriteLine("\t\t Call: " + numOfCallsIteratively);
                return num;
            }

            int a = 0;
            int b = 1;
            int c = 0;
            for(int i = 2; i <= num; i++)
            {
                numOfCallsIteratively += 1;
                Console.WriteLine("\t\t Call: " + numOfCallsIteratively);
                c = a + b;
                a = b;
                b = c;
            }

            return c;
        }
    }
}
