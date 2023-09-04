using ChessChallenge.API;

public class MyBot : IChessBot
{
    /* Rough overview of what the Bot is doing..

    - Starts with some uncommon 'book' opening
    - Once out of the opening, determine the best move!
        - Minmax with Alpha-Beta pruning? Monte Carlo Tree Search? Stochastic Gradient Descent?
        - We will need to define some cost function to minimise?
    - Once queens are off the board, enter 'end game' mode..?
    */

    // Piece values: null, pawn, knight, bishop, rook, queen, king
    int[] pieceValues = { 0, 100, 300, 300, 500, 900, 10000 };

    public Move Think(Board board, Timer timer)
    {
        Move[] moves = board.GetLegalMoves();
        System.Random rng = new ();
        return moves[rng.Next(moves.Length)];
    }
}
