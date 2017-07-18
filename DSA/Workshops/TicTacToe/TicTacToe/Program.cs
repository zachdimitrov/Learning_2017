using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    using playerFunc = Func<GameState, Tuple<int, int>>;
    class Program
    {
        static void Main()
        {
            var tree = new Dictionary<GameState, GameEdge>();

            var sw = new Stopwatch();
            sw.Start();

            BuildTree(tree, new GameState(), GameCell.Player1, GameCell.Player2);
            var result = GamePlay(KeyBoardPlayer, state => CPUPlayer(tree, state));
            switch (result)
            {
                case 0: Console.WriteLine("The game is draw!"); break;
                case 1: 
                case 2: Console.WriteLine($"Player {result} wins!"); break;
                default: throw new SomethingIsSeriouslyWrongException("");
            }

            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }

        static Tuple<int, int> KeyBoardPlayer(GameState state)
        {
            Console.WriteLine(state);
            Console.Write("Enter coordinates: ");
            var strs = Console.ReadLine()
                .Split(' ');

            var row = 0;
            var col = 0;

            if (strs.Length != 2)
            {
                return new Tuple<int, int>(-1, -1);
            }
            else
            {
                if (!int.TryParse(strs[0], out row))
                {
                    row = -1;
                }

                if (!int.TryParse(strs[1], out col))
                {
                    col = -1;
                }
            }

            return new Tuple<int, int>(row, col);
        }

        static Tuple<int, int> CPUPlayer(Dictionary<GameState, GameEdge> tree, GameState state)
        {
            var edge = tree[state];
            return new Tuple<int, int>(edge.Row, edge.Column);
        }

        static int GamePlay(playerFunc p1func, playerFunc p2func)
        {
            var state = new GameState();
            var pFuncs = new playerFunc[] { p1func, p2func };
            var players = new GameCell[] { GameCell.Player1, GameCell.Player2 };

            var currentPlayer = 0;
            var movesCount = 0;

            while (movesCount < 9)
            {
                var move = pFuncs[currentPlayer](state);
                var newState = state.MakeMove(move.Item1, move.Item2, players[currentPlayer]);
                if (newState == null)
                {
                    if (movesCount == 0)
                    {
                        Console.WriteLine("Skipping...");
                        currentPlayer ^= 1;
                    }
                    else
                    {
                        Console.WriteLine("Invalid mowe! Play again!");
                    }

                    continue;
                }

                state = newState;

                if(state.IsWinning(players[currentPlayer]))
                {
                    Console.WriteLine(state);
                    return currentPlayer + 1;
                }

                currentPlayer ^= 1; // 1 - current player
                ++movesCount;
            }

            return 0;
        }

        static GameResult BuildTree(Dictionary<GameState, GameEdge> tree, GameState state, GameCell currentPlayer, GameCell nextPlayer)
        {
            if (tree.ContainsKey(state))
            {
                return tree[state].Result;
            }

            if (state.IsWinning(nextPlayer))
            {
                tree[state] = new GameEdge(-1, -1, GameResult.Losing);
                return GameResult.Losing;
            }

            GameEdge drawEdge = null;
            GameEdge loseEdge = null;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var newState = state.MakeMove(i, j, currentPlayer);
                    if (newState == null)
                    {
                        continue;
                    }

                    var result = BuildTree(tree, newState, nextPlayer, currentPlayer);

                    if (result == GameResult.Losing)
                    {
                        tree[state] = new GameEdge(i, j, GameResult.Winning);
                        return GameResult.Winning;
                    }

                    if (drawEdge == null && result == GameResult.Draw)
                    {
                        drawEdge = new GameEdge(i, j, GameResult.Draw);
                    }

                    if (loseEdge == null && result == GameResult.Winning)
                    {
                        loseEdge = new GameEdge(i, j, GameResult.Losing);
                    }
                }
            }

            if (drawEdge != null)
            {
                tree[state] = drawEdge;
                return GameResult.Draw;
            }

            if (loseEdge != null)
            {
                tree[state] = loseEdge;
                return GameResult.Losing;
            }

            tree[state] = new GameEdge(-1, -1, GameResult.Draw);
            return GameResult.Draw;
        }
    }
}
