namespace Chess_Logic
{
    public enum Player // stores winner and looser
    {
        None,
        White,
        Black
    }
    public static class PlayerExtensions
    {
        public static Player Opponent(this Player player)
        {
            switch(player)
            {
                case Player.White:
                    return Player.Black;
                case Player.Black:
                    return Player.White;
                default:
                    return Player.None;
            }
        }
    }
}
