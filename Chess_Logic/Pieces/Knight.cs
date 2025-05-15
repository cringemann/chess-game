using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Logic
{
    public class Knight : Piece
    {
        public override PieceType Type => PieceType.Knight;
        public override Player Color { get; }

        public Knight(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            Knight Copy = new Knight(Color);
            Copy.HasMoved = HasMoved;
            return Copy;
        }

        private static IEnumerable<Position> PotentialToPosition(Position from)
        {
            foreach (Direction Vdir in new Direction[] { Direction.North, Direction.South })
            {
                foreach (Direction Hdir in new Direction[] { Direction.West, Direction.East })
                {
                    yield return from + 2 * Vdir + Hdir;
                    yield return from + 2 * Hdir + Vdir;
                }
            }
        }

        private IEnumerable<Position> MovePositions(Position from, Board board)
        {
            return PotentialToPosition(from).Where(pos => Board.IsInside(pos) && (board.IsEmpty(pos) || board[pos].Color != Color));
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return MovePositions(from, board).Select(to =>  new NormalMove(from, to));
        }
    }
}
