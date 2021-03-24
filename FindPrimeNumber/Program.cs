using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeNumber
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Task task1 = TaskOne();
            await task1;

        }

        private static bool checkPrime(int num)
        {
            if (num <= 1) return false;
            for (int index = 2; index < num; index++)
            {
                if (num % index == 0)
                {
                    return false;
                }
            }
            return true;
        }
        private static async Task TaskOne()
        {
            // await Task.Delay(1000);
            for (int i = 1; i <= 100; i++)
            {
                await Task.Delay(1000);
                if (checkPrime(i))
                {
                    Console.WriteLine("Prime Number is : " + i);
                }
            }
        }
    }
}
