using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class GameEdge
    {
        public GameEdge(int row, int column, GameResult result)
        {
            this.Row = row;
            this.Column = column;
            this.Result = result;
        }

        public int Row { get; private set; }

        public int Column { get; private set; }

        public GameResult Result { get; private set; }
    }
}
