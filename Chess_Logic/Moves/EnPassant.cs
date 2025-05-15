using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Logic
{
    public class EnPassant : Move
    {
        public override MoveType Type => MoveType.EnPassant;
        public override Position FromPos { get; }
        public override Position ToPos { get; }
        private readonly Position capturePos;

        public EnPassant(Position from, Position to)
        {
            FromPos = from;
            ToPos = to;
            capturePos = new Position(from.Row, to.Column);
        }

        public override bool Execute(Board board)
        {
            new NormalMove(FromPos, ToPos).Execute(board);
            board[capturePos] = null;

            return true;
        }

        public override bool IsLegal(Board board)
        {
            Player player = board[FromPos].Color;
            Board boardCopy = board.Copy();
            Execute(boardCopy);
            if (boardCopy[new Position(FromPos.Row, ToPos.Column)] == null)
            {
                return true;
            }
            else
                return false;
        }
    }
}
