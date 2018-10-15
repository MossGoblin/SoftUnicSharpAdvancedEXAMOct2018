using System;
using System.Linq;

namespace _03_Miner
{
    class Miner
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            char[,] field = new char[size,size];
            int startRow = 0;
            int startCol = 0;
            int collected = 0;
            int available = 0;
            bool ended = false;
            //bool collectedAll = false;

            for (int rr = 0; rr < size; rr++)
            {
                string[] fieldLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int cc = 0; cc < size; cc++)
                {
                    field[rr, cc] = fieldLine[cc][0];
                    if (field[rr, cc] == 's')
                    {
                        startRow = rr;
                        startCol = cc;
                    }
                    else if (field[rr, cc] == 'c')
                    {
                        available++;
                    }
                }
            }

            // execute commands
            int row = startRow;
            int col = startCol;

            for (int counter = 0; counter < commands.Length; counter++)
            {
                bool stillMoving = true;
                switch (commands[counter].ToLower())
                {
                    case "up":
                        // check for end of field
                        stillMoving = MoveMiner(field, size, ref row, ref col, -1, 0, ref collected, ref available);
                        break;
                    case "down":
                        stillMoving = MoveMiner(field, size, ref row, ref col, 1, 0, ref collected, ref available);
                        break;
                    case "left":
                        stillMoving = MoveMiner(field, size, ref row, ref col, 0, -1, ref collected, ref available);
                        break;
                    case "right":
                        stillMoving = MoveMiner(field, size, ref row, ref col, 0, 1, ref collected, ref available);
                        break;
                    default:
                        break;
                }
                if (available == 0)
                {
                    // print Done
                    Console.WriteLine($"You collected all coals! ({row}, {col})");
                    break;
                }
                if (!stillMoving)
                {
                    // print End
                    Console.WriteLine($"Game over! ({row}, {col})");
                    ended = true;
                    break;
                }
            }
            // print Collected
            if ((available > 0) && !ended)
            {
                Console.WriteLine($"{available} coals left. ({row}, {col})");
            }
        }

        private static bool MoveMiner(char[,] field, int size, ref int row, ref int col, int dr, int dc, ref int collected, ref int available)
        {
            if ((row + dr >= 0) && (row + dr < size) && (col + dc >= 0) && (col + dc < size))
            {
                row += dr;
                col += dc;
                // check for coal
                if (field[row, col] == 'c')
                {
                    collected++;
                    available--;
                    field[row, col] = '*';
                }
                // check for end
                else if (field[row, col] == 'e')
                {
                    // END GAME
                    return false;
                }
            }
            return true;
        }
    }
}
