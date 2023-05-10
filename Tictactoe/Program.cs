using System;

namespace TicTacToe
{
    class Program
    {
        static char[,] deska = new char[3, 3];
        static char AktualniHrac = 'X';

        static void Main(string[] args)
        {
            InitializeBoard();
            PrintBoard();

            while (!IsGameOver())
            {
                TakeTurn();
                PrintBoard();
            }

            Console.WriteLine(GetGameResult());
            Console.ReadLine();
        }

        static void InitializeBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    deska[row, col] = ' ';
                }
            }
        }

        static void PrintBoard()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\r\n ____  _     _                     _          \r\n|  _ \\(_)___| | ____   _____  _ __| | ___   _ \r\n| |_) | / __| |/ /\\ \\ / / _ \\| '__| |/ / | | |\r\n|  __/| \\__ \\   <  \\ V / (_) | |  |   <| |_| |\r\n|_|   |_|___/_|\\_\\  \\_/ \\___/|_|  |_|\\_\\\\__, |\r\n                                        |___/ ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   |   |   ");
            Console.WriteLine($" {deska[0, 0]} | {deska[0, 1]} | {deska[0, 2]} ");
            Console.WriteLine("___|___|___");
            Console.WriteLine("   |   |   ");
            Console.WriteLine($" {deska[1, 0]} | {deska[1, 1]} | {deska[1, 2]} ");
            Console.WriteLine("___|___|___");
            Console.WriteLine("   |   |   ");
            Console.WriteLine($" {deska[2, 0]} | {deska[2, 1]} | {deska[2, 2]} ");
            Console.WriteLine("   |   |   ");
        }

        static void TakeTurn()
        {
            Console.WriteLine($"Hráč {AktualniHrac}, zadej řadu (0,1,2):");
            int row = int.Parse(Console.ReadLine());

            Console.WriteLine($"Hráč {AktualniHrac}, zadej slopec (0,1,2):");
            int col = int.Parse(Console.ReadLine());

            if (deska[row, col] != ' ')
            {
                Console.WriteLine("Toto políčko už je zabrané, zkus to znovu.");
                TakeTurn();
            }
            else
            {
                deska[row, col] = AktualniHrac;
                AktualniHrac = AktualniHrac == 'X' ? 'O' : 'X';
            }
        }

        static bool IsGameOver()
        {
            if (deska[0, 0] != ' ' && deska[0, 0] == deska[0, 1] && deska[0, 1] == deska[0, 2]) return true;
            if (deska[1, 0] != ' ' && deska[1, 0] == deska[1, 1] && deska[1, 1] == deska[1, 2]) return true;
            if (deska[2, 0] != ' ' && deska[2, 0] == deska[2, 1] && deska[2, 1] == deska[2, 2]) return true;
            if (deska[0, 0] != ' ' && deska[0, 0] == deska[1, 0] && deska[1, 0] == deska[2, 0]) return true;
            if (deska[0, 1] != ' ' && deska[0, 1] == deska[1, 1] && deska[1, 1] == deska[2, 1]) return true;
            if (deska[0, 2] != ' ' && deska[0, 2] == deska[1, 2] && deska[1, 2] == deska[2, 2]) return true;
            if (deska[0, 0] != ' ' && deska[0, 0] == deska[1, 1] && deska[1, 1] == deska[2, 2]) return true;
            if (deska[0, 2] != ' ' && deska[0, 2] == deska[1, 1] && deska[1, 1] == deska[2, 0]) return true;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (deska[row, col] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static string GetGameResult()
        {
            if (IsGameOver())
            {
                if (AktualniHrac == 'X')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    return "\nHráč O vyhrává!";
                }
                else if (AktualniHrac == 'O')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    return "\nHráč X vyhrává!";
                }
                else
                {
                    return "\nJe to remíza!";
                }
            }
            else
            {
                return "\nHra ještě není u konce";
            }
        }
    }
}
