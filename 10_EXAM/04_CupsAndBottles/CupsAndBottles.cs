using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_CupsAndBottles
{
    class CupsAndBottles
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>();
            Stack<int> bottles = new Stack<int>();
            int wastedWater = 0;

            // get input
            int[] incomingCups = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] incomingBottles = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            // fill stacks
            foreach (var item in incomingCups)
            {
                cups.Enqueue(item);
            }
            foreach (var item in incomingBottles)
            {
                bottles.Push(item);
            }

            // game
            //while ((cups.Count > 0) && (bottles.Count > 0))
            while (bottles.Count > 0)
            {
                if (cups.Count == 0)
                {
                    break;
                }
                int crrCup = cups.Dequeue();
                int crrBottle = bottles.Pop();

                while ((crrCup > 0) && (crrBottle > 0))
                {
                    // more water in the bottle
                    if (crrBottle >= crrCup)
                    {
                        wastedWater += crrBottle - crrCup;
                        crrCup = 0;
                    }
                    else
                    {
                        crrCup -= crrBottle;
                        crrBottle = bottles.Pop();
                    }
                }
            }
            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {String.Join(' ', bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {String.Join(' ', cups)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
