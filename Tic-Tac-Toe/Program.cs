using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace ConsoleApp52
{
    class Program
    {
        static char[] spaces = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int choice;
        static int flag;

        static void DrawBoard()
        {

            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |   {1}  |  {2}  ", spaces[0], spaces[1], spaces[2]);
            Console.WriteLine("     |     |     ");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |   {1}  |  {2}  ", spaces[3], spaces[4], spaces[5]);
            Console.WriteLine("     |     |     ");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |   {1}  |  {2}  ", spaces[6], spaces[7], spaces[8]);
            Console.WriteLine("     |     |     ");
        }

        static int checkwin()
        {
            if (spaces[0] == spaces[1] &&
               spaces[1] == spaces[2] ||
               spaces[3] == spaces[4] &&
               spaces[4] == spaces[5] ||
               spaces[6] == spaces[7] &&
               spaces[7] == spaces[8] ||
               spaces[0] == spaces[3] &&
               spaces[3] == spaces[6] ||
               spaces[1] == spaces[4] &&
               spaces[4] == spaces[7] ||
               spaces[2] == spaces[5] &&
               spaces[5] == spaces[8] ||
               spaces[0] == spaces[4] &&
               spaces[4] == spaces[8] ||
               spaces[2] == spaces[4] &&
               spaces[4] == spaces[6])
            {
                return 1;
            }
            else if (spaces[0] != '1' &&
                    spaces[1] != '2' &&
                    spaces[2] != '3' &&
                    spaces[3] != '4' &&
                    spaces[4] != '5' &&
                    spaces[5] != '6' &&
                    spaces[6] != '7' &&
                    spaces[7] != '8' &&
                    spaces[8] != '9')
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        static void DrawX(int pos)
        {
            spaces[pos] = 'X';
        }

        static void DrawO(int pos)
        {
            spaces[pos] = 'O';
        }

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("player 1 : X and player 2 : O " + "\n");
                if (player % 2 == 0)
                {
                    Console.WriteLine("player 2 turns");
                }
                else
                {
                    Console.WriteLine("player 1 turns");
                }
                Console.WriteLine("\n");
                DrawBoard();
                choice = int.Parse(Console.ReadLine()) - 1;

                if (spaces[choice] != 'X' && spaces[choice] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        DrawO(choice);
                    }
                    else
                    {
                        DrawX(choice);
                    }
                    player++;
                }
                else
                {
                    Console.WriteLine("sorry the number is already marked with {1}", choice, spaces[choice]);
                    Console.WriteLine("please wait 2 sec Board is Loading");
                    Thread.Sleep(2000);
                }

                flag = checkwin();
            }
            while (flag != 1 && flag != -1);
            Console.Clear();
            DrawBoard();

            if (flag == 1)
            {
                Console.WriteLine("player {0} has won", (player % 2) + 1);

            }
            else
            {
                Console.WriteLine("tie game");
            }
            Console.ReadLine();
        }
    }
}