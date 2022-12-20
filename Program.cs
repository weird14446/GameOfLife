namespace GameOfLife
{
    class GameOfLife
    {
        static void Main(string[] args)
        {
            int[,] board =
            {
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            };

            Run(board);
        }

        static bool Rule(int[,] board, int[] pos)
        {
            int n = board.GetLength(0), m = board.GetLength(1);
            int cnt = 0;
            int[,] N =
            {
                {-1, -1},
                {-1, 0},
                {-1, 1},
                {0, -1},
                {0, 1},
                {1, -1},
                {1, 0},
                {1, 1}
            };

            for (int i = 0; i < 8; i++)
            {
                if (-1 < pos[0] - N[i, 0] &&
                    pos[0] - N[i, 0] < n &&
                    -1 < pos[1] - N[i, 1] &&
                    pos[1] - N[i, 1] < m)
                {
                    if (board[pos[0] - N[i, 0], pos[1] - N[i, 1]] == 1)
                    {
                        cnt++;
                    }
                }
            }

            if (board[pos[0], pos[1]] == 0 && cnt == 3) { return true; }
            else if (board[pos[0], pos[1]] == 1 && cnt == 2 || cnt == 3) { return true; }
            else { return false; }
        }
        static int[,] Next(int[,] board)
        {
            int n = board.GetLength(0), m = board.GetLength(1);
            int[,] nextBoard = new int[n, m];
            int[] pos = { 0, 0 };

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    pos[0] = i; pos[1] = j;

                    if (Rule(board, pos))
                    {
                        nextBoard[i, j] = 1;
                    }
                    else
                    {
                        nextBoard[i, j] = 0;
                    }
                }
            }

            return nextBoard;
        }

        static void Run(int[,] board)
        {
            ulong num = 0;

            while (true)
            {
                Console.Clear();

                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        Console.Write(board[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("\n" + num + "\ns is stop");

                board = Next(board);
                num++;

                string? cmd = Console.ReadLine();

                if (cmd == "s") { break; }
            }
        }
    }
}
