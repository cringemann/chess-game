﻿namespace Chess_Logic
{
    public class Pawn : Piece
    {
        public override PieceType Type => PieceType.Pawn;
        public override Player Color { get; }

        private readonly Direction forward;
        public Pawn(Player color)
        {
            Color = color;
            if (Color == Player.White)
                forward = Direction.North;
            else if (Color == Player.Black)
                forward = Direction.South;
        }


        public override Piece Copy()
        {
            Pawn copy = new Pawn(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private static bool CanMoveTo(Position pos, Board board)
        {
            return Board.IsInside(pos) && board.IsEmpty(pos);
        }

        private bool CanCaptureAt(Position pos, Board board)
        {
            if (!Board.IsInside(pos) || board.IsEmpty(pos))
                return false;
            return board[pos].Color != Color;
        }

        private IEnumerable<Move> ForwardMoves(Position from, Board board)
        {
            Position OneMovePos = from + forward;
            if (CanMoveTo(OneMovePos, board))
            {
                if (OneMovePos.Row == 0 || OneMovePos.Row == 7)
                {
                    foreach (Move proMove in PromotionMoves(from, OneMovePos))
                    {
                        yield return proMove;
                    }
                }
                else
                {
                    yield return new NormalMove(from, OneMovePos);
                }

                Position TwoMovesPos = OneMovePos + forward;

                if (!HasMoved && CanMoveTo(TwoMovesPos, board))
                {
                    yield return new DoublePawn(from, TwoMovesPos);
                }
            }

        }

        private IEnumerable<Move> DiagonalMoves(Position from, Board board)
        {
            foreach (Direction dir in new Direction[] { Direction.West, Direction.East })
            {
                Position to = from + forward + dir;

                if (to == board.GetPawnSkipPoisition(Color.Opponent()))
                {
                    yield return new EnPassant(from, to);
                }
                else if (CanCaptureAt(to, board))
                {
                    if (to.Row == 0 || to.Row == 7)
                    {
                        foreach (Move proMove in PromotionMoves(from, to))
                        {
                            yield return proMove;
                        }
                    }
                    else
                    {
                        yield return new NormalMove(from, to);
                    }
                }
            }
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return ForwardMoves(from, board).Concat(DiagonalMoves(from, board));
        }

        public override bool CanCaptureOpponentKing(Position from, Board board)
        {
            return DiagonalMoves(from, board).Any(move =>
            {
                Piece piece = board[move.ToPos];
                return piece != null && piece.Type == PieceType.King;
            });
        }
        private static IEnumerable<Move> PromotionMoves(Position from, Position to)
        {
            yield return new PawnPromotion(from, to, PieceType.Knight);
            yield return new PawnPromotion(from, to, PieceType.Bishop);
            yield return new PawnPromotion(from, to, PieceType.Rook);
            yield return new PawnPromotion(from, to, PieceType.Queen);
        }
    }
}
